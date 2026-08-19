using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TuCarreraSV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Title = "TuCarreraSV";
            Console.ReadKey();

            Console.WriteLine("Bienvenido a la plataforma de TuCarreraSV");
            Console.WriteLine("Esta plataforma te permite registrarte para comenzar a recibir viajes y ganar dinero");
            Console.WriteLine("1. Registrarse\n 2. Iniciar sesión\n 3. Salir");
            switch (int.TryParse(Console.ReadLine(), out int opcion) ? opcion : 0)
            {
                case 1:
                Console.WriteLine("Registrarse");
                Console.WriteLine("Ingrese su nombre:");
                string nombre = Console.ReadLine()!;
                Console.WriteLine("Ingrese su usuario:");
                string usuario = Console.ReadLine()!;
                Console.WriteLine("Vuelva a ingresar su usuario:");
                string usuarioConfirmacion = Console.ReadLine()!;
                if (usuario != usuarioConfirmacion)
                {
                    Console.WriteLine("Los usuarios no coinciden");
                    break;
                }
                break;

                case 2:
                Console.WriteLine("Iniciar sesión");
                break;

                case 3:
                Console.WriteLine("Salir");
                break;
            }

        }


        }

        class Conductor
        {
            string nombre { get; set; }
            int edad { get; set; }
            string licencia { get; set; }
            bool estadoLicencia { get; set; }

            Vehiculo vehiculo { get; set; }
        }

        class Vehiculo
        {
            string marca { get; set; }
            string modelo { get; set; }
            int anio { get; set; }
            string color { get; set; }
            string placa { get; set; }
        }
    }
