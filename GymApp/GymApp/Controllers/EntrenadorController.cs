using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GymApp.Models;
using GymApp.Views;

namespace GymApp.Controllers
{
    // controlo todo lo que es la lista y las acciones de los entrenadores
    public class EntrenadorController
    {
        // el repository es el unico que maneja los datos, ya no necesitamos la lista en el controller
        private readonly IRepository<Entrenador> _repo;

        // la view es creada por el controller, no por el program
        private readonly EntrenadorView _view;

        // inicializo el repository y creo la view pasandome a mi mismo
        public EntrenadorController(IRepository<Entrenador> repo)
        {
            _repo = repo;
            _view = new EntrenadorView(this);
        }

        // el controller delega la muestra del menu a su view
        public void MostrarMenu()
        {
            _view.MostrarMenu();
        }

        // le pido al repository que agregue el entrenador y persista directamente
        public void Agregar(Entrenador entrenador)
        {
            _repo.Agregar(entrenador);
            Console.WriteLine("Entrenador agregado correctamente.");
        }

        // le pido al repository la lista completa y la recorro para mostrarla
        public void Listar()
        {
            List<Entrenador> lista = _repo.LeerTodos();
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay entrenadores registrados.");
                return;
            }
            foreach (Entrenador e in lista)
            {
                Console.WriteLine(e.MostrarDatos());
            }
        }

        // le pido al repository la lista y busco por criterio comparando en minusculas
        public Entrenador Buscar(string criterio)
        {
            List<Entrenador> lista = _repo.LeerTodos();
            foreach (Entrenador e in lista)
            {
                if (e.ObtenerCriterioBusqueda().ToLower().Contains(criterio.ToLower()))
                {
                    return e;
                }
            }
            Console.WriteLine("No se encontró ningún entrenador con el criterio proporcionado.");
            return null;
        }

        // busco al entrenador y le pido que muestre sus rutinas
        public void ListarRutinas(string criterio)
        {
            Entrenador entrenador = Buscar(criterio);
            if (entrenador != null)
                entrenador.ListarRutinas();
        }
    }
}