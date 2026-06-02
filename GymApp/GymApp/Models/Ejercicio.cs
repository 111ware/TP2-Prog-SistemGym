using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Models
{
    // representa un ejercicio individual dentro de una rutina
    public class Ejercicio
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Sets { get; private set; }
        public int Reps { get; private set; }
        public int RestTimeSeconds { get; private set; }

        //Constructor para crear un ejercicio con toda su info
        public Ejercicio(int id, string name, int sets, int reps, int restTimeSeconds)
        {
            Id = id;
            Name = name;
            Sets = sets;
            Reps = reps;
            RestTimeSeconds = restTimeSeconds;
        }

        // armo una consoleWriteln con toda la info del ejercicio para mostrar en consola
        public string MostrarEjercicio()
        {
            return $"[{Id}] {Name} - Sets: {Sets} | Reps: {Reps} | RestTime: {RestTimeSeconds}s";
        }
    }
}
