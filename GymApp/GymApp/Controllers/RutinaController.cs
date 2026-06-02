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
        private List<Rutina> routines;

        // preparo la lista para empezar a meter los planes de ejercicio
        public RutinaController()
        {
            routines = new List<Rutina>();
        }

        // guardo una rutina nueva en el sistema y tiro aviso por consola
        public void Agregar(Rutina routine)
        {
            routines.Add(routine);
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

        // busco la rutina por criterio y si existe le agrego el ejercicio nuevo
        public void AgregarEjercicio(string criteria, Ejercicio ejercicio)
        {
            Rutina routine = Buscar(criteria);
            if (routine != null)
                routine.AgregarEjercicio(ejercicio);
        }

        // busco la rutina y le saco un ejercicio usando el criterio que me pasaron
        public void EliminarEjercicio(string criteria, int exerciseId)
        {
            Rutina routine = Buscar(criteria);
            if (routine != null)
                routine.EliminarEjercicio(exerciseId);
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
