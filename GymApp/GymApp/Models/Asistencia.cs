using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Models
{
    // guarda el registro de cuando un socio entra al gimnasio
    public class Asistencia : IEntidad
    {
        public int Id { get;  set; }
        public DateTime Date { get;  set; }
        public TimeSpan CheckInTime { get;  set; }

        //Constructor que asigna el id, la fecha actual y la hora de ingreso
        public Asistencia(int id)
        {
            Id = id;
            Date = DateTime.Today;
            CheckInTime = DateTime.Now.TimeOfDay;
        }

        // muestro el detalle del ingreso en consola
        public void RegistrarIngreso()
        {
            Console.WriteLine($"Ingreso registrado | Fecha: {Date:dd/MM/yyyy} | Hora: {CheckInTime:hh\\:mm}");
        }
    }
}
