using GymApp.Controllers;
using GymApp.Models;
using System;
using System.Linq;

namespace GymApp.Views
{
    // aca armo la view para interactuar con los entrenadores y mostrar los menus en la consola
    public class EntrenadorView
    {
        private EntrenadorController controller;

        // arranco la view, recibo el repository y se lo paso al controlador
        public EntrenadorView(IRepository<Entrenador> repo)
        {
            controller = new EntrenadorController(repo);
        }

        // asegura de que el usuario meta un numero entero si o si y no rompa nada
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

        // validador de texto ingresado que tenga solo letras y espacios
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

        // metodo para pedir solo numeros, valida que no este vacio y que cada caracter sea un numero, sino da error
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

        // bucle principal con las opciones de la pantalla de entrenadores
        public void MostrarMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("\n--- MENU ENTRENADORES ---");
                Console.WriteLine("1. Agregar Entrenador");
                Console.WriteLine("2. Listar Entrenadores");
                Console.WriteLine("3. Buscar Entrenador");
                Console.WriteLine("4. Asignar Rutina a Entrenador");
                Console.WriteLine("5. Ver Rutinas de Entrenador");
                Console.WriteLine("0. Volver al menu principal");
                Console.Write("Seleccione una opcion: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AgregarEntrenador();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "2":
                        controller.Listar();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "3":
                        BuscarEntrenador();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "4":
                        AsignarRutina();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "5":
                        VerRutinas();
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

        // pido uno por uno los datos validados para crear al profe y mandarlo al controlador
        private void AgregarEntrenador()
        {
            int id = PedirEntero("ID: ");
            string name = PedirTexto("Nombre: ");
            string lastName = PedirTexto("Apellido: ");
            string dni = PedirNumeros("DNI: ");
            string phone = PedirNumeros("Telefono: ");
            string specialty = PedirTexto("Especialidad: ");
            string registrationNumber = PedirNumeros("Numero de matricula: ");

            Entrenador entrenador = new Entrenador(id, name, lastName, dni, phone, specialty, registrationNumber);
            controller.Agregar(entrenador);
        }

        // pido criterio de busqueda al usuario, si lo encuentro muestro la info del entrenador
        private void BuscarEntrenador()
        {
            Console.Write("Ingrese nombre, apellido o DNI: ");
            string criteria = Console.ReadLine();
            Entrenador entrenador = controller.Buscar(criteria);
            if (entrenador != null)
                Console.WriteLine(entrenador.MostrarDatos());
        }

        // busco al entrenador y le asigno una rutina nueva con los datos que ingresa el usuario
        private void AsignarRutina()
        {
            Console.Write("Ingrese nombre, apellido o DNI del entrenador: ");
            string criteria = Console.ReadLine();
            Entrenador entrenador = controller.Buscar(criteria);
            if (entrenador != null)
            {
                int id = PedirEntero("ID de la rutina: ");
                string name = PedirTexto("Nombre de la rutina: ");
                string objetive = PedirTexto("Objetivo de la rutina: ");
                Rutina rutina = new Rutina(id, name, objetive);
                entrenador.AsignarRutina(rutina);
                Console.WriteLine("Rutina asignada correctamente.");
            }
        }

        // busco al entrenador y muestro todas las rutinas que tiene asignadas
        private void VerRutinas()
        {
            Console.Write("Ingrese nombre, apellido o DNI del entrenador: ");
            string criteria = Console.ReadLine();
            controller.ListarRutinas(criteria);
        }
    }
}