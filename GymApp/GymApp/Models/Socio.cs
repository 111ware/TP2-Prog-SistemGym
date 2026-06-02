using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Models
{
    //  maneja los datos de los socios del gym y sus asistencias
    public class Socio : Persona, IPagable
    {
        public DateTime RegistrationDate { get; private set; }

        public bool Status { get; private set; }

        public Membresia Membresia { get; private set; }

        private List<Asistencia> Attendance;

        // constructor para crear un socio con toda su info, asigno la fecha de registro al dia de hoy, el estado a activo y la lista de asistencias vacia
        public Socio(int id, string name, string lastName, string dni, string phoneNumber, Membresia membresia) : base(id, name, lastName, dni, phoneNumber)
        {
            RegistrationDate = DateTime.Today;
            Status = true;
            Membresia = membresia;
            Attendance = new List<Asistencia>();
        }

        // armo una nueva asistencia y la meto en la lista del socio
        public void RegistrarAsistencia()
        {
            Asistencia asistencia = new Asistencia(Attendance.Count + 1);
            Attendance.Add(asistencia);
            asistencia.RegistrarIngreso();
        }

        // muestro rapido por consola que plan tiene y si esta al dia
        public void VerMembresia()
        {
            Console.WriteLine($"Membresia: {Membresia.Type} | Estado: {(Membresia.EstaVigente() ? "Si" : "No")}");
        }

        // le paso el monto a la membresia para que procese el pago
        public void RegistrarPago(decimal monto)
        {
            Membresia.RegistrarPago(monto);
        }

        // devuelvo los datos principales del socio en una sola linea para mostrar en consola
        public override string MostrarDatos()
        {
            return $"[{Id}] {Name} {LastName} | DNI: {Dni} | Estado: {(Status ? "Activo" : "Inactivo")}";
        }

        // junto nombre, apellido y dni en un solo string para el buscador
        public override string ObtenerCriterioBusqueda()
        {
            return $"{Name} {LastName} {Dni}";
        }

    }
}
