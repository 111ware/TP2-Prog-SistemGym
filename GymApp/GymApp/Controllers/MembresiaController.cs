using GymApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Controllers
{
    // controlo todos los planes y membresias del gym, guardo los distintos tipos de pases y gestiono los pagos y el estado de cada uno
    public class MembresiaController
    {
        private List<Membresia> memberships;

        // armo la lista para ir guardando los distintos tipos de membresia
        public MembresiaController()
        {
            memberships = new List<Membresia>();
        }

        // guardo una membresia nueva y aviso por pantalla
        public void Agregar(Membresia membership)
        {
            memberships.Add(membership);
            Console.WriteLine("Membresía agregada correctamente.");
        }

        // muestro todas las membresias que hay con el precio y si estan activos o no
        public void Listar()
        {
            if (memberships.Count == 0)
            {
                Console.WriteLine("No hay membresías registradas.");
                return;
            }
            foreach (Membresia m in memberships)
                Console.WriteLine($"[{m.Id}] {m.Type} - Costo: ${m.Cost} - Vigente: {(m.EstaVigente() ? "Sí" : "No")}");
        }

        // busco una membresia por el nombre pasandolo a minusculas para que no falle por mayusculas o minusculas, si la encuentro la devuelvo sino aviso que no se encontro
        public Membresia Buscar(string criteria)
        {
            foreach (Membresia m in memberships)
            {
                if (m.Type.ToLower().Contains(criteria.ToLower()))
                    return m;
            }
            Console.WriteLine("Membresía no encontrada.");
            return null;
        }

        // busco la membresia primero y si existe le mando el pago para que se registre, si no existe aviso que no se encontro la membresia
        public void RegistrarPago(string criteria, decimal amount)
        {
            Membresia membership = Buscar(criteria);
            if (membership != null)
                membership.RegistrarPago(amount);
        }

        // me fijo el estado de la membresia de alguien y muestro cuando se vence
        public void VerEstado(string criteria)
        {
            Membresia membership = Buscar(criteria);
            if (membership != null)
                Console.WriteLine($"Membresía: {membership.Type} - Vigente: {(membership.EstaVigente() ? "Sí" : "No")} - Vencimiento: {membership.ExpirationDate:dd/MM/yyyy}");
        }
    }
}

