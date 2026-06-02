using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GymApp.Models;

namespace GymApp.Controllers
{
    // controlo todo lo que es la lista y las acciones de los entrenadores
    public class EntrenadorController
    {
        private List<Entrenador> trainer;

        // inicializo la lista para empezar a guardar los profes
        public EntrenadorController()
        {
            trainer = new List<Entrenador>();
        }

        // meto un nuevo entrenador a la lista y aviso que salio todo bien
        public void Agregar(Entrenador entrenador)
        {
            trainer.Add(entrenador);
            Console.WriteLine("Entrenador agregado correctamente.");
        }

        // recorro la lista y muestro los profes, si esta vacia doy aviso de que no hay nada registrado
        public void Listar()
        {
            if (trainer.Count == 0)
            {
                Console.WriteLine("No hay entrenadores registrados.");
                return;
            }
            foreach (Entrenador e in trainer)
            {
                Console.WriteLine(e.MostrarDatos());
            }
        }

        // busco un entrenador por texto comparando todo en minusculas para que no falle por las mayusculas
        public Entrenador Buscar(string criterio)
        {
            foreach (Entrenador e in trainer)
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