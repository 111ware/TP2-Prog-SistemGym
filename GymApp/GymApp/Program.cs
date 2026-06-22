using GymApp.Views;
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

            // inicializo las views pasandoles los repositories para que los inyecten en los controllers
            EntrenadorView entrenadorView = new EntrenadorView(repoEntrenador);
            SocioView socioView = new SocioView(repoSocio, repoMembresia);
            RutinaView rutinaView = new RutinaView(repoRutina);
            MembresiaView membresiaView = new MembresiaView(repoMembresia);

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
                        entrenadorView.MostrarMenu();
                        break;
                    case "2":
                        socioView.MostrarMenu();
                        break;
                    case "3":
                        rutinaView.MostrarMenu();
                        break;
                    case "4":
                        membresiaView.MostrarMenu();
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