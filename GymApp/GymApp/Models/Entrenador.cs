using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Models
{
    // extiende persona con los datos propios de un entrenador
    public class Entrenador : Persona
    {
        public string Specialty { get; private set; }
        public string RegistrationNumber { get; private set; }

        // cada entrenador tiene su propia lista de rutinas asignadas
        private List<Rutina> Routine;


        // constructor para crear un entrenador con toda su info, inicializo la lista de rutinas vacia
        public Entrenador(int id, string name, string lastName, string dni, string phoneNumber, string specialty, string registrationNumber) : base(id, name, lastName, dni, phoneNumber)
        {
            Specialty = specialty;
            RegistrationNumber = registrationNumber;
            Routine = new List<Rutina>();
        }

        // agrego una rutina a la lista del entrenador
        public void AsignarRutina(Rutina routine)
        {
            Routine.Add(routine);
        }

        // devuelvo los datos principales del entrenador en una sola linea
        public override string MostrarDatos()
        {
            return $"[{Id}] {Name} | DNI: {Dni} | Specialty: {Specialty} | RegistrationNumber: {RegistrationNumber}";
        }

        // uso nombre, apellido y dni como criterio para la busqueda
        public override string ObtenerCriterioBusqueda()
        {
            return $"{Name} {LastName} {Dni}";
        }
    }
}
