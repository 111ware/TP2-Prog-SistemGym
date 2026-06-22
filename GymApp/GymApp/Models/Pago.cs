using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Models
{
    // representa un pago individual realizado por un socio
    public class Pago
    {
        public int Id { get;  set; }
        public DateTime Date { get;  set; }
        public decimal Amount { get;  set; }
        public string PaymentMethod { get;  set; }


        // constructor para crear un pago con toda su info, la fecha se asigna automaticamente al momento de crear el pago
        public Pago(int id, DateTime date, decimal amount, string paymentMethod)
        {
            Id = id;
            Date = date;
            Amount = amount;
            PaymentMethod = paymentMethod;
        }

        // devuelvo los datos del pago en una sola linea para mostrar en consola
        public string MostrarComprobante()
        {
            return $"[{Id}] Fecha: {Date:dd/MM/yyyy} - Monto: ${Amount} - Metodo: {PaymentMethod}";
        }
    }
}