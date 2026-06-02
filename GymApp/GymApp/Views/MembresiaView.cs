using GymApp.Controllers;
using GymApp.Models;
using System;
using System.Linq;

namespace GymApp.Views
{
    // armo toda la view para que el usuario pueda interactuar con las membresias y mostrar los menus en la consola
    public class MembresiaView
    {
        private MembresiaController controller;

        // levanto la view y preparo el controlador para empezar a manejar las membresias y mostrar los menus
        public MembresiaView()
        {
            controller = new MembresiaController();
        }

        // control para que lo que pongan sea un numero entero para evitar romper el programa
        private int PedirEntero(string mensaje)
        {
            int resultado;
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out resultado))
                    return resultado;
                Console.WriteLine("Error: ingrese un numero entero valido.");
            }
        }

        //  control para pedir los precios de las cuotas con coma o decimales
        private decimal PedirDecimal(string mensaje)
        {
            decimal resultado;
            while (true)
            {
                Console.Write(mensaje);
                if (decimal.TryParse(Console.ReadLine(), out resultado))
                    return resultado;
                Console.WriteLine("Error: ingrese un numero valido.");
            }
        }

        // control que asegura de que el tipo de pase que ingresen tenga letras y no simbolos raros
        private string PedirTexto(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string texto = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(texto) && texto.All(c => char.IsLetter(c) || c == ' '))
                    return texto;
                Console.WriteLine("Error: ingrese solo letras.");
            }
        }

        // control para que ingrese bien el formato de fecha para que el sistema calcule los vencimientos
        private DateTime PedirFecha(string mensaje)
        {
            DateTime resultado;
            while (true)
            {
                Console.Write(mensaje);
                if (DateTime.TryParse(Console.ReadLine(), out resultado))
                    return resultado;
                Console.WriteLine("Error: ingrese una fecha valida (dd/MM/yyyy).");
            }
        }

        // menu principal de las membresias para navegar entre las opciones de la consola
        public void MostrarMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("\n--- MENU MEMBRESIAS ---");
                Console.WriteLine("1. Agregar Membresia");
                Console.WriteLine("2. Listar Membresias");
                Console.WriteLine("3. Buscar Membresia");
                Console.WriteLine("4. Registrar Pago");
                Console.WriteLine("5. Ver Estado");
                Console.WriteLine("0. Volver al menu principal");
                Console.Write("Seleccione una opcion: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AgregarMembresia();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "2":
                        controller.Listar();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "3":
                        BuscarMembresia();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "4":
                        RegistrarPago();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "5":
                        VerEstado();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // pido los datos limpios para armar el plan de pase y guardarlo en el sistema
        private void AgregarMembresia()
        {
            int id = PedirEntero("ID: ");
            string type = PedirTexto("Tipo (Mensual/Trimestral/Anual): ");
            decimal cost = PedirDecimal("Costo: ");
            DateTime startDate = PedirFecha("Fecha de inicio (dd/MM/yyyy): ");
            DateTime expirationDate = PedirFecha("Fecha de vencimiento (dd/MM/yyyy): ");

            Membresia membresia = new Membresia(id, type, cost, startDate, expirationDate);
            controller.Agregar(membresia);
        }

        // busco un pase por texto y muestro los detalles por consola
        private void BuscarMembresia()
        {
            Console.Write("Ingrese tipo de membresia: ");
            string criteria = Console.ReadLine();
            Membresia membresia = controller.Buscar(criteria);
            if (membresia != null)
                Console.WriteLine($"[{membresia.Id}] {membresia.Type} - Costo: ${membresia.Cost} - Vencimiento: {membresia.ExpirationDate:dd/MM/yyyy}");
        }

        // pido cual es la membresia y cuanta plata entra para mandarselo al controlador
        private void RegistrarPago()
        {
            Console.Write("Ingrese tipo de membresia: ");
            string criteria = Console.ReadLine();
            decimal amount = PedirDecimal("Monto: ");
            controller.RegistrarPago(criteria, amount);
        }

        // pido el timpo de membresia y muestro si esta vigente o no y cuando se vence
        private void VerEstado()
        {
            Console.Write("Ingrese tipo de membresia: ");
            string criteria = Console.ReadLine();
            controller.VerEstado(criteria);
        }
    }
}