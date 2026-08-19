using System;

namespace TuCarreraSV
{
    class Program
    {
        // Usuario registrado como variable global
        static Usuario? usuarioRegistrado = null;

        static void Main(string[] args)
        {
            Console.Clear();
            Console.Title = "TuCarreraSV";
            Console.WriteLine("Bienvenido a la plataforma de TuCarreraSV");
            Console.WriteLine("Esta plataforma te permite registrarte para comenzar a recibir viajes y ganar dinero");

            int opcion;
            do
            {
                Console.WriteLine("\n=== Sistema de Inicio de Sesión ===");
                Console.WriteLine("1. Registrar usuario");
                Console.WriteLine("2. Iniciar sesión");
                Console.WriteLine("3. Eliminar usuario");
                Console.WriteLine("4. Mostrar usuario actual");
                Console.WriteLine("0. Salir");
                Console.Write("Elige una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Por favor ingresa un número válido.\n");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                     RegistrarUsuario();
                      break;
                    case 2: IniciarSesion(); break;
                    case 3:
                     EliminarUsuario();
                     break;
                    case 4:
                     MostrarUsuario(); 
                    break;
                    case 0:
                     Console.WriteLine("Saliendo del sistema...");
                     System.Threading.Thread.Sleep(3000);
                     break;
                    default: Console.WriteLine("Opción inválida.\n"); break;
                }

            } while (opcion != 0);
        }

        static void RegistrarUsuario()
        {
            if (usuarioRegistrado != null)
            {
                Console.WriteLine("Ya existe un usuario registrado. Elimínalo antes de registrar uno nuevo.\n");
                return;
            }

            Console.Write("Correo: ");
            string correo = Console.ReadLine()!;
            Console.Write("Contraseña: ");
            string password = Console.ReadLine()!;

            usuarioRegistrado = new Usuario { Correo = correo, Password = password };
            Console.WriteLine("Usuario registrado con éxito.\n");
        }

        static void IniciarSesion()
        {
            if (usuarioRegistrado == null)
            {
                Console.WriteLine("No hay usuario registrado. Registra uno primero.\n");
                return;
            }

            Console.Write("Correo: ");
            string correo = Console.ReadLine()!;
            Console.Write("Contraseña: ");
            string password = Console.ReadLine()!;

            if (correo == usuarioRegistrado.Correo && password == usuarioRegistrado.Password)
            {
                Console.WriteLine("Inicio de sesión exitoso.\n");
            }
            else
            {
                Console.WriteLine("Credenciales incorrectas.\n");
            }
        }

        static void EliminarUsuario()
        {
            if (usuarioRegistrado == null)
            {
                Console.WriteLine("No hay usuario registrado para eliminar.\n");
                return;
            }

            usuarioRegistrado = null;
            Console.WriteLine("Usuario eliminado con éxito.\n");
        }

        static void MostrarUsuario()
        {
            if (usuarioRegistrado == null)
            {
                Console.WriteLine("No hay usuario registrado.\n");
            }
            else
            {
                Console.WriteLine($"Usuario actual: {usuarioRegistrado.Correo}\n");
            }
        }
    }

    // Clases de dominio
    class Usuario
    {
        public string? Correo { get; set; }
        public string? Password { get; set; }
    }

    class Conductor
    {
        public string? Nombre { get; set; }
        public int Edad { get; set; }
        public string? Licencia { get; set; }
        public bool EstadoLicencia { get; set; }
        public Vehiculo? Vehiculo { get; set; }
    }

    class Vehiculo
    {
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int Anio { get; set; }
        public string? Color { get; set; }
        public string? Placa { get; set; }
    }
}
