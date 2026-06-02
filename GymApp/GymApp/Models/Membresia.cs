using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Models
{
    // representa la membresia de un socio, implementa IPagable para gestionar pagos
    public class Membresia : IPagable
    {
        public int Id { get; private set; }
        public string Type { get; private set; }
        public decimal Cost { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        // guardo todos los pagos realizados para esta membresia
        private List<Pago> Payments;

        public Membresia(int id, string type, decimal cost, DateTime startDate, DateTime expirationDate)
        {
            Id = id;
            Type = type;
            Cost = cost;
            StartDate = startDate;
            ExpirationDate = expirationDate;
            Payments = new List<Pago>();
        }

        // comparo la fecha actual con la de vencimiento para saber si sigue activa
        public bool EstaVigente()
        {
            return DateTime.Now <= ExpirationDate;
        }

        // creo un nuevo pago con la fecha de hoy y lo agrego a la lista
        public void RegistrarPago(decimal monto)
        {
            Pago pago = new Pago(Payments.Count + 1, DateTime.Today, monto, "Efectivo");
            Payments.Add(pago);
            Console.WriteLine($"Pago registrado: ${monto}");
        }

        // muestro todos los pagos registrados para esta membresia
        public void MostrarPagos()
        {
            if (Payments.Count == 0)
            {
                Console.WriteLine("No hay pagos registrados para esta membresia.");
                return;
            }
            foreach (Pago p in Payments)
                Console.WriteLine(p.MostrarComprobante());
        }
    }
}