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
        // en vez de una lista simple, ahora usamos el repository para leer y guardar
        private readonly IRepository<Membresia> _repo;
        private List<Membresia> memberships;

        // inicializo el repository y cargo la lista desde el json
        public MembresiaController(IRepository<Membresia> repo)
        {
            _repo = repo;
            memberships = _repo.LeerTodos();
        }

        // guardo una membresia nueva, persisto en el json y aviso por pantalla
        public void Agregar(Membresia membership)
        {
            memberships.Add(membership);
            _repo.GuardarTodos(memberships);
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

        // busco una membresia por el nombre pasandolo a minusculas para que no falle por mayusculas o minusculas
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

        // busco la membresia y si existe le mando el pago para que se registre, guardo en el json
        public void RegistrarPago(string criteria, decimal amount)
        {
            Membresia membership = Buscar(criteria);
            if (membership != null)
            {
                membership.RegistrarPago(amount);
                _repo.GuardarTodos(memberships);
            }
        }

        // me fijo el estado de la membresia y muestro cuando se vence
        public void VerEstado(string criteria)
        {
            Membresia membership = Buscar(criteria);
            if (membership != null)
                Console.WriteLine($"Membresía: {membership.Type} - Vigente: {(membership.EstaVigente() ? "Sí" : "No")} - Vencimiento: {membership.ExpirationDate:dd/MM/yyyy}");
        }
    }
}