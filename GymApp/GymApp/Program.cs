using GymApp.Controllers;
using GymApp.Models;
using System;

namespace GymApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // creo los repositories, cada uno apunta a su propio archivo json
            var repoEntrenador = new JsonRepository<Entrenador>("entrenadores.json");
            var repoSocio = new JsonRepository<Socio>("socios.json");
            var repoRutina = new JsonRepository<Rutina>("rutinas.json");
            var repoMembresia = new JsonRepository<Membresia>("membresias.json");

            // creo los controllers, cada uno recibe su repository
            EntrenadorController entrenadorController = new EntrenadorController(repoEntrenador);
            SocioController socioController = new SocioController(repoSocio);
            RutinaController rutinaController = new RutinaController(repoRutina);
            MembresiaController membresiaController = new MembresiaController(repoMembresia);

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTION GYM ===");
                Console.WriteLine("1. Gestionar Entrenadores");
                Console.WriteLine("2. Gestionar Socios");
                Console.WriteLine("3. Gestionar Rutinas");
                Console.WriteLine("4. Gestionar Membresias");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opcion: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        // el controller se encarga de llamar a su view
                        entrenadorController.MostrarMenu();
                        break;
                    case "2":
                        socioController.MostrarMenu();
                        break;
                    case "3":
                        rutinaController.MostrarMenu();
                        break;
                    case "4":
                        membresiaController.MostrarMenu();
                        break;
                    case "0":
                        exit = true;
                        Console.Clear();
                        Console.WriteLine("Hasta luego!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}