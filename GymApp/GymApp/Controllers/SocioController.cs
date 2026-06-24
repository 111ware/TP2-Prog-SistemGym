using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Models;

namespace GymApp.Controllers
{
    // controla todo el ABM (dar de alta, baja o modificaciones) de los socios
    public class SocioController
    {
        // en vez de una lista simple, ahora usa el repository para leer y guardar
        private readonly IRepository<Socio> _repo;
        private List<Socio> members;

        // inicializo el repository y cargo la lista desde el json
        public SocioController(IRepository<Socio> repo)
        {
            _repo = repo;
            members = _repo.LeerTodos();
        }

        // meto un socio nuevo a la lista, guardo en el json y aviso que salio todo bien
        public void Agregar(Socio socio)
        {
            members.Add(socio);
            _repo.GuardarTodos(members);
            Console.WriteLine("Socio agregado correctamente.");
        }

        // recorro y muestro la info de todos los socios, si no hay nadie tiro un aviso
        public void Listar()
        {
            if (members.Count == 0)
            {
                Console.WriteLine("No hay socios registrados.");
                return;
            }
            foreach (Socio socio in members)
            {
                Console.WriteLine(socio.MostrarDatos());
            }
        }

        // busco al socio usando el criterio pasandolo a minusculas
        public Socio Buscar(string criterio)
        {
            foreach (Socio s in members)
            {
                if (s.ObtenerCriterioBusqueda().ToLower().Contains(criterio.ToLower()))
                {
                    return s;
                }
            }
            Console.WriteLine("Socio no encontrado.");
            return null;
        }

        // encuentro al socio por criterio y pido ver el estado de su pase
        public void VerMembresia(string criterio)
        {
            Socio member = Buscar(criterio);
            if (member != null)
            {
                member.VerMembresia();
            }
        }

        // busco al socio en la lista y si esta le agrego el pago del mes, guardo en el json
        public void RegistrarPago(string criterio, decimal monto)
        {
            Socio member = Buscar(criterio);
            if (member != null)
            {
                member.RegistrarPago(monto);
                _repo.GuardarTodos(members);
            }
        }

        // registro la asistencia del socio buscando por criterio, guardo en el json
        public void RegistrarAsistencia(string criteria)
        {
            Socio member = Buscar(criteria);
            if (member != null)
            {
                member.RegistrarAsistencia();
                _repo.GuardarTodos(members);
            }
        }
    }
}