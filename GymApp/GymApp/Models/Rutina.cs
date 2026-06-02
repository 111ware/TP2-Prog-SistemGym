using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Models
{
    // representa una rutina de entrenamiento que contiene ejercicios
    public class Rutina
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Objetive { get; private set; }

        // lista de ejercicios que forman parte de esta rutina
        private List<Ejercicio> Exercises;


        // cosntructor para crear una rutina con su id, nombre y objetivo, inicializo la lista de ejercicios vacia
        public Rutina(int id, string name, string objetive)
        {
            Id = id;
            Name = name;
            Objetive = objetive;
            Exercises = new List<Ejercicio>();
        }

        // agrego un ejercicio a la rutina
        public void AgregarEjercicio(Ejercicio ejercicio)
        {
            Exercises.Add(ejercicio);
        }

        // busco el ejercicio por id y lo elimino si lo encuentro
        public void EliminarEjercicio(int id)
        {
            foreach (Ejercicio e in Exercises)
            {
                if (e.Id == id)
                {
                    Exercises.Remove(e);
                    break;
                }
            }
        }

        // muestro todos los ejercicios de la rutina
        public void ListarEjercicios()
        {
            if (Exercises.Count == 0)
            {
                Console.WriteLine("No hay ejercicios en esta rutina.");
                return;
            }
            foreach (Ejercicio e in Exercises)
                Console.WriteLine(e.MostrarEjercicio());
        }
    }
}
