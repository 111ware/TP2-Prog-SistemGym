using GymApp.Controllers;
using GymApp.Models;
using System;
using System.Linq;


namespace GymApp.Views
{
    // maneja la view para gestionar las acciones y datos de los socios
    public class SocioView
    {
        private SocioController controller;

        // levanto la view y preparo la conexion con el controlador de socios
        public SocioView()
        {
            controller = new SocioController();
        }

        // controlo que metan numeros enteros nada mas
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

        // controlo que metan numeros decimales para los montos de dinero
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

        // control de que metan solo texto con letras y espacios para no romper el programa
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

        // controlo que metan solo caracteres numericos para campos como el dni o telefono
        private string PedirNumeros(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string texto = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(texto) && texto.All(c => char.IsDigit(c)))
                    return texto;
                Console.WriteLine("Error: ingrese solo numeros.");
            }
        }

        // muestra las opciones de membresia y devuelve el tipo seleccionado en texto
        private string PedirTipoMembresia()
        {
            while (true)
            {
                Console.WriteLine("Tipo de membresia:");
                Console.WriteLine("1. Mensual");
                Console.WriteLine("2. Trimestral");
                Console.WriteLine("3. Anual");
                Console.Write("Seleccione una opcion: ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1": return "Mensual";
                    case "2": return "Trimestral";
                    case "3": return "Anual";
                    default:
                        Console.WriteLine("Error: opcion no valida.");
                        break;
                }
            }
        }

        // menu de la consola para gestionar los datos, asistencias y pagos de los socios
        public void MostrarMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("\n--- MENU SOCIOS ---");
                Console.WriteLine("1. Agregar Socio");
                Console.WriteLine("2. Listar Socios");
                Console.WriteLine("3. Buscar Socio");
                Console.WriteLine("4. Registrar Asistencia");
                Console.WriteLine("5. Ver Membresia");
                Console.WriteLine("6. Registrar Pago");
                Console.WriteLine("0. Volver al menu principal");
                Console.Write("Seleccione una opcion: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AgregarSocio();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "2":
                        controller.Listar();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "3":
                        BuscarSocio();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "4":
                        RegistrarAsistencia();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "5":
                        VerMembresia();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "6":
                        RegistrarPago();
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

        // pide los datos personales del socio mas su plan para crearlo y mandarlo al controlador
        private void AgregarSocio()
        {
            int id = PedirEntero("ID: ");
            string name = PedirTexto("Nombre: ");
            string lastName = PedirTexto("Apellido: ");
            string dni = PedirNumeros("DNI: ");
            string phone = PedirNumeros("Telefono: ");
            string type = PedirTipoMembresia();
            decimal cost = PedirDecimal("Costo: ");

            Membresia membresia = new Membresia(id, type, cost, DateTime.Today, DateTime.Today.AddMonths(1));
            Socio socio = new Socio(id, name, lastName, dni, phone, membresia);
            controller.Agregar(socio);
        }

        // busca un socio por el criterio elegido y muestra los datos del mismo si lo encuentra
        private void BuscarSocio()
        {
            Console.Write("Ingrese nombre, apellido o DNI: ");
            string criteria = Console.ReadLine();
            Socio socio = controller.Buscar(criteria);
            if (socio != null)
                Console.WriteLine(socio.MostrarDatos());
        }

        // bajo criterio de busqueda pide el socio y registra una nueva asistencia para el mismo
        private void RegistrarAsistencia()
        {
            Console.Write("Ingrese nombre, apellido o DNI del socio: ");
            string criteria = Console.ReadLine();
            controller.RegistrarAsistencia(criteria);
        }

        // pide el dato del socio para consultar en que estado esta su membresia actual
        private void VerMembresia()
        {
            Console.Write("Ingrese nombre, apellido o DNI del socio: ");
            string criteria = Console.ReadLine();
            controller.VerMembresia(criteria);
        }

        // pide un criterio y el monto a abonar para registrar el pago de la cuota
        private void RegistrarPago()
        {
            Console.Write("Ingrese nombre, apellido o DNI del socio: ");
            string criteria = Console.ReadLine();
            decimal amount = PedirDecimal("Monto: ");
            controller.RegistrarPago(criteria, amount);
        }
    }
}