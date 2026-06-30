using GymApp.Models;
using GymApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Controllers
{
    // maneja todas las rutinas de entrenamiento del gym
    public class RutinaController
    {
        // el repository es el unico que maneja los datos, ya no necesitamos la lista en el controller
        private readonly IRepository<Rutina> _repo;

        // la view es creada por el controller, no por el program
        private readonly RutinaView _view;

        // inicializo el repository y creo la view pasandome a mi mismo
        public RutinaController(IRepository<Rutina> repo)
        {
            _repo = repo;
            _view = new RutinaView(this);
        }

        // el controller delega la muestra del menu a su view
        public void MostrarMenu()
        {
            _view.MostrarMenu();
        }

        // le pido al repository que agregue la rutina y persista directamente
        public void Agregar(Rutina routine)
        {
            _repo.Agregar(routine);
            Console.WriteLine("Rutina agregada correctamente.");
        }

        // le pido al repository la lista completa y la recorro para mostrarla
        public void Listar()
        {
            List<Rutina> lista = _repo.LeerTodos();
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay rutinas registradas.");
                return;
            }
            foreach (Rutina r in lista)
                Console.WriteLine($"[{r.Id}] {r.Name} | Objetivo: {r.Objetive}");
        }

        // le pido al repository la lista y busco por nombre ignorando mayusculas
        public Rutina Buscar(string criteria)
        {
            List<Rutina> lista = _repo.LeerTodos();
            foreach (Rutina r in lista)
            {
                if (r.Name.ToLower().Contains(criteria.ToLower()))
                    return r;
            }
            Console.WriteLine("Rutina no encontrada.");
            return null;
        }

        // busco la rutina, le agrego el ejercicio y le pido al repository que actualice
        public void AgregarEjercicio(string criteria, Ejercicio ejercicio)
        {
            Rutina routine = Buscar(criteria);
            if (routine != null)
            {
                routine.AgregarEjercicio(ejercicio);
                _repo.Actualizar(routine);
            }
        }

        // busco la rutina, le saco el ejercicio y le pido al repository que actualice
        public void EliminarEjercicio(string criteria, int exerciseId)
        {
            Rutina routine = Buscar(criteria);
            if (routine != null)
            {
                routine.EliminarEjercicio(exerciseId);
                _repo.Actualizar(routine);
            }
        }

        // busco la rutina y muestro todos sus ejercicios
        public void ListarEjercicios(string criteria)
        {
            Rutina routine = Buscar(criteria);
            if (routine != null)
                routine.ListarEjercicios();
        }
    }
}