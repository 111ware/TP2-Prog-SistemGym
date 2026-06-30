using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Models;
using GymApp.Views;

namespace GymApp.Controllers
{
    // controla todo el ABM (dar de alta, baja o modificaciones) de los socios
    public class SocioController
    {
        // el repository es el unico que maneja los datos, ya no necesitamos la lista en el controller
        private readonly IRepository<Socio> _repo;

        // la view es creada por el controller, no por el program
        private readonly SocioView _view;

        // inicializo el repository y creo la view pasandome a mi mismo
        public SocioController(IRepository<Socio> repo)
        {
            _repo = repo;
            _view = new SocioView(this);
        }

        // el controller delega la muestra del menu a su view
        public void MostrarMenu()
        {
            _view.MostrarMenu();
        }

        // le pido al repository que agregue el socio y persista directamente
        public void Agregar(Socio socio)
        {
            _repo.Agregar(socio);
            Console.WriteLine("Socio agregado correctamente.");
        }

        // le pido al repository la lista completa y la recorro para mostrarla
        public void Listar()
        {
            List<Socio> lista = _repo.LeerTodos();
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay socios registrados.");
                return;
            }
            foreach (Socio socio in lista)
            {
                Console.WriteLine(socio.MostrarDatos());
            }
        }

        // le pido al repository la lista y busco por criterio pasandolo a minusculas
        public Socio Buscar(string criterio)
        {
            List<Socio> lista = _repo.LeerTodos();
            foreach (Socio s in lista)
            {
                if (s.ObtenerCriterioBusqueda().ToLower().Contains(criterio.ToLower()))
                {
                    return s;
                }
            }
            Console.WriteLine("Socio no encontrado.");
            return null;
        }

        // encuentro al socio por criterio y muestro el estado de su membresia
        public void VerMembresia(string criterio)
        {
            Socio member = Buscar(criterio);
            if (member != null)
            {
                member.VerMembresia();
            }
        }

        // busco el socio, registro el pago y le pido al repository que actualice
        public void RegistrarPago(string criterio, decimal monto)
        {
            Socio member = Buscar(criterio);
            if (member != null)
            {
                member.RegistrarPago(monto);
                _repo.Actualizar(member);
            }
        }

        // busco el socio, registro la asistencia y le pido al repository que actualice
        public void RegistrarAsistencia(string criteria)
        {
            Socio member = Buscar(criteria);
            if (member != null)
            {
                member.RegistrarAsistencia();
                _repo.Actualizar(member);
            }
        }
    }
}