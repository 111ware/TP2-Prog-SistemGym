using GymApp.Controllers;
using GymApp.Models;
using System;
using System.Linq;

namespace GymApp.Views
{
    // maneja la view para armar los planes de entrenamiento 
    public class RutinaView
    {
        private RutinaController controller;

        // levanto la view y preparo la conexion con el controlador de rutinas
        public RutinaView()
        {
            controller = new RutinaController();
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

        //  menu de la consola para gestionar los ejercicios y planes de entrenamiento
        public void MostrarMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("\n--- MENU RUTINAS ---");
                Console.WriteLine("1. Agregar Rutina");
                Console.WriteLine("2. Listar Rutinas");
                Console.WriteLine("3. Buscar Rutina");
                Console.WriteLine("4. Agregar Ejercicio a Rutina");
                Console.WriteLine("5. Eliminar Ejercicio de Rutina");
                Console.WriteLine("6. Listar Ejercicios de Rutina");
                Console.WriteLine("0. Volver al menu principal");
                Console.Write("Seleccione una opcion: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AgregarRutina();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "2":
                        controller.Listar();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "3":
                        BuscarRutina();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "4":
                        AgregarEjercicio();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "5":
                        EliminarEjercicio();
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "6":
                        ListarEjercicios();
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

        // agregar una rutina nueva y se guarda en la lista de rutinas del controlador
        private void AgregarRutina()
        {
            int id = PedirEntero("ID: ");
            string name = PedirTexto("Nombre: ");
            string objetive = PedirTexto("Objetivo: ");

            Rutina rutina = new Rutina(id, name, objetive);
            controller.Agregar(rutina);
        }

        // busca una rutina por su nombre y muestra los datos de la misma si la encuentra
        private void BuscarRutina()
        {
            Console.Write("Ingrese nombre de la rutina: ");
            string criteria = Console.ReadLine();
            Rutina rutina = controller.Buscar(criteria);
            if (rutina != null)
                Console.WriteLine($"[{rutina.Id}] {rutina.Name} - Objetivo: {rutina.Objetive}");
        }

        // pido la rutina a la cual se le agrega un ejercicoo y luego los datos del ejercicio para agregarlo a la misma
        private void AgregarEjercicio()
        {
            Console.Write("Nombre de la rutina: ");
            string rutinaName = Console.ReadLine();
            int id = PedirEntero("ID del ejercicio: ");
            string name = PedirTexto("Nombre del ejercicio: ");
            int series = PedirEntero("Series: ");
            int reps = PedirEntero("Repeticiones: ");
            int rest = PedirEntero("Descanso en segundos: ");

            Ejercicio ejercicio = new Ejercicio(id, name, series, reps, rest);
            controller.AgregarEjercicio(rutinaName, ejercicio);
        }

        // pido la rutina y el id del ejercicio a eliminar
        private void EliminarEjercicio()
        {
            Console.Write("Nombre de la rutina: ");
            string rutinaName = Console.ReadLine();
            int id = PedirEntero("ID del ejercicio a eliminar: ");
            controller.EliminarEjercicio(rutinaName, id);
        }

        // lista todos los ejercicios de una rutina buscando por su nombre
        private void ListarEjercicios()
        {
            Console.Write("Nombre de la rutina: ");
            string criteria = Console.ReadLine();
            controller.ListarEjercicios(criteria);
        }
    }
}