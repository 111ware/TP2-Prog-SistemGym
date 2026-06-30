using GymApp.Models;
using GymApp.Views;
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
        // el repository es el unico que maneja los datos, ya no necesitamos la lista en el controller
        private readonly IRepository<Membresia> _repo;

        // la view es creada por el controller, no por el program
        private readonly MembresiaView _view;

        // inicializo el repository y creo la view pasandome a mi mismo
        public MembresiaController(IRepository<Membresia> repo)
        {
            _repo = repo;
            _view = new MembresiaView(this);
        }

        // el controller delega la muestra del menu a su view
        public void MostrarMenu()
        {
            _view.MostrarMenu();
        }

        // le pido al repository que agregue la membresia y persista directamente
        public void Agregar(Membresia membership)
        {
            _repo.Agregar(membership);
            Console.WriteLine("Membresía agregada correctamente.");
        }

        // le pido al repository la lista completa y la recorro para mostrarla
        public void Listar()
        {
            List<Membresia> lista = _repo.LeerTodos();
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay membresías registradas.");
                return;
            }
            foreach (Membresia m in lista)
                Console.WriteLine($"[{m.Id}] {m.Type} - Costo: ${m.Cost} - Vigente: {(m.EstaVigente() ? "Sí" : "No")}");
        }

        // le pido al repository la lista y busco por tipo pasandolo a minusculas
        public Membresia Buscar(string criteria)
        {
            List<Membresia> lista = _repo.LeerTodos();
            foreach (Membresia m in lista)
            {
                if (m.Type.ToLower().Contains(criteria.ToLower()))
                    return m;
            }
            Console.WriteLine("Membresía no encontrada.");
            return null;
        }

        // busco la membresia, registro el pago y le pido al repository que actualice
        public void RegistrarPago(string criteria, decimal amount)
        {
            Membresia membership = Buscar(criteria);
            if (membership != null)
            {
                membership.RegistrarPago(amount);
                _repo.Actualizar(membership);
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