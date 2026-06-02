using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Models
{
    // clase base para entrenadores y socios, implementa IBuscable (abtracta porque no se pueden crear personas, solo sus subclases)
    public abstract class Persona : IBuscable
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Dni { get; private set; }
        public string PhoneNumber { get; private set; }

        // constructor para crear una persona con toda su info
        public Persona(int id, string name, string lastName, string dni, string phoneNumber)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Dni = dni;
            PhoneNumber = phoneNumber;
        }

        // cada subclase decide como mostrar sus propios datos
        public abstract string MostrarDatos();

        // cada subclase define por que campos se puede buscar
        public abstract string ObtenerCriterioBusqueda();
    }
}