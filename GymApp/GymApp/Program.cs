using GymApp.Views;
using System;

using GymApp.Views;
using System;
namespace GymApp
{
   
    public class Program
    {
        // MAIN.CS
        static void Main(string[] args)
        {
            // inicializo las views de cada modulo para poder usarlas en el switch
            EntrenadorView entrenadorView = new EntrenadorView();
            SocioView socioView = new SocioView();
            RutinaView rutinaView = new RutinaView();
            MembresiaView membresiaView = new MembresiaView();

            bool exit = false; //condicion de bluce 

            // bucle general para mantener el sistema abierto hasta que elijan salir
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
                        // muestra el menu de la view de entrenadores
                        entrenadorView.MostrarMenu();
                        break;
                    case "2":
                        // muestra el menu de la view de socio
                        socioView.MostrarMenu();
                        break;
                    case "3":
                        // muestra el menu de la view de rutina
                        rutinaView.MostrarMenu();
                        break;
                    case "4":
                        // muestra el menu de la view de membresia
                        membresiaView.MostrarMenu();
                        break;
                    case "0":
                        // corta el bucle principal y cierra la aplicacion 
                        exit = true;
                        Console.Clear(); //limpia la consola 
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

/*
El sistema aplica el principio SRP(principio de responsabilidad única) ya que cada clase tiene una unica responsabilidad definida: 
Pago gestiona comprobantes, Asistencia registra ingresos y cada Controller maneja únicamente su entidad correspondiente. 


Tambien aplica DIP (inversion de dependencias) usando las interfaces IBuscable e IPagable. 
Esto hace que los controladores dependan de ideas generales (abstracciones) y no de clases fijas. 
Asi, si agrego cosas nuevas al gimnasio, el sistema se adapta solo sin tener que tocar el codigo que ya funciona y romper todo.
*/