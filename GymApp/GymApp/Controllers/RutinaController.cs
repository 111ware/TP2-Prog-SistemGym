using GymApp.Models;
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
        // en vez de una lista simple, ahora usamos el repository para leer y guardar
        private readonly IRepository<Rutina> _repo;
        private List<Rutina> routines;

        // inicializo el repository y cargo la lista desde el json
        public RutinaController(IRepository<Rutina> repo)
        {
            _repo = repo;
            routines = _repo.LeerTodos();
        }

        // guardo una rutina nueva en el sistema, persisto en el json y tiro aviso por consola
        public void Agregar(Rutina routine)
        {
            routines.Add(routine);
            _repo.GuardarTodos(routines);
            Console.WriteLine("Rutina agregada correctamente.");
        }

        // muestro en pantalla todas las rutinas que tenemos con su objetivo
        public void Listar()
        {
            if (routines.Count == 0)
            {
                Console.WriteLine("No hay rutinas registradas.");
                return;
            }
            foreach (Rutina r in routines)
                Console.WriteLine($"[{r.Id}] {r.Name} | Objetivo: {r.Objetive}");
        }

        // busco una rutina por el nombre ignorando si pusieron mayusculas o minusculas
        public Rutina Buscar(string criteria)
        {
            foreach (Rutina r in routines)
            {
                if (r.Name.ToLower().Contains(criteria.ToLower()))
                    return r;
            }
            Console.WriteLine("Rutina no encontrada.");
            return null;
        }

        // busco la rutina y si existe le agrego el ejercicio nuevo, guardo en el json
        public void AgregarEjercicio(string criteria, Ejercicio ejercicio)
        {
            Rutina routine = Buscar(criteria);
            if (routine != null)
            {
                routine.AgregarEjercicio(ejercicio);
                _repo.GuardarTodos(routines);
            }
        }

        // busco la rutina y le saco un ejercicio usando el criterio que me pasaron, guardo en el json
        public void EliminarEjercicio(string criteria, int exerciseId)
        {
            Rutina routine = Buscar(criteria);
            if (routine != null)
            {
                routine.EliminarEjercicio(exerciseId);
                _repo.GuardarTodos(routines);
            }
        }

        // muestro por pantalla la lista completa de ejercicios que tiene esa rutina
        public void ListarEjercicios(string criteria)
        {
            Rutina routine = Buscar(criteria);
            if (routine != null)
                routine.ListarEjercicios();
        }
    }
}