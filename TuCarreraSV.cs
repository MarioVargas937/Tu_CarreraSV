using System;
using System.Collections.Generic;

namespace TuCarreraSV
{
    class Program
    {
        // Usuario registrado como variable global
        static Usuario? usuarioRegistrado = null;

        // Solo puede existir un conductor activo
        static Conductor? conductorActivo = null;

        static void Main(string[] args)
        {
            Console.Clear();
            Console.Title = "TuCarreraSV";

            Console.WriteLine("Bienvenido a la plataforma de TuCarreraSV");
            Console.WriteLine("Esta plataforma te permite registrarte para comenzar a recibir viajes y ganar dinero");

            int opcion;

            do
            {
                Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
                Console.WriteLine("1. Registrar usuario");
                Console.WriteLine("2. Iniciar sesión");
                Console.WriteLine("3. Eliminar usuario");
                Console.WriteLine("4. Mostrar usuario actual");

                Console.WriteLine("\n--- GESTIÓN DE CONDUCTOR ---");
                Console.WriteLine("5. Registrar conductor");
                Console.WriteLine("6. Eliminar conductor");
                Console.WriteLine("7. Mostrar conductor");

                Console.WriteLine("\n--- GESTIÓN DE VEHÍCULOS ---");
                Console.WriteLine("8. Registrar vehículo");
                Console.WriteLine("9. Mostrar vehículos");
                Console.WriteLine("10. Asignar vehículo al conductor");

                Console.WriteLine("\n--- CIUDADES ---");
                Console.WriteLine("11. Registrar ciudades donde puede operar");
                Console.WriteLine("12. Mostrar ciudades donde puede operar");

                Console.WriteLine("\n13. Mostrar información completa");
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
                    case 2:
                        IniciarSesion();
                        break;
                    case 3:
                        EliminarUsuario();
                        break;
                    case 4:
                        MostrarUsuario();
                        break;
                    case 5:
                        RegistrarConductor();
                        break;
                    case 6:
                        EliminarConductor();
                        break;
                    case 7:
                        MostrarConductor();
                        break;
                    case 8:
                        RegistrarVehiculo();
                        break;
                    case 9:
                        MostrarVehiculos();
                        break;
                    case 10:
                        AsignarVehiculo();
                        break;
                    case 11:
                        RegistrarCiudad();
                        break;
                    case 12:
                        MostrarCiudades();
                        break;
                    case 13:
                        MostrarInformacionCompleta();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del sistema...");
                        System.Threading.Thread.Sleep(4000);
                        break;
                    default:
                        Console.WriteLine("Opción inválida.\n");
                        break;
                }

            } while (opcion != 0);
        }

        // =========================
        // MÉTODOS DEL USUARIO DE LA PLATFORMA DE TU CARRERA SV!!!!
        // =========================

        static void RegistrarUsuario()
        {
            if (usuarioRegistrado != null)
            {
                Console.WriteLine("Ya existe un usuario registrado. Elimínalo antes de registrar uno nuevo.\n");
                System.Threading.Thread.Sleep(4000);
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
                System.Threading.Thread.Sleep(4000);
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
                System.Threading.Thread.Sleep(4000);
            }
            else
            {
                Console.WriteLine($"Usuario actual: {usuarioRegistrado.Correo}\n");
            }
        }

        // =========================
        // MÉTODOS DEL CONDUCTOR
        // =========================

        static void RegistrarConductor()
        {
            // Solo puede existir un conductor activo
            if (conductorActivo != null)
            {
                Console.WriteLine("Ya existe un conductor activo.");
                Console.WriteLine("Debes eliminarlo antes de registrar otro.");
                System.Threading.Thread.Sleep(4000);
                return;
            }

            Console.Write("Nombre del conductor: ");
            string nombre = Console.ReadLine()!;

            Console.Write("Edad: ");

            if (!int.TryParse(Console.ReadLine(), out int edad))
            {
                Console.WriteLine("Edad inválida.");
                return;
            }

            Console.Write("Número de licencia: ");
            string licencia = Console.ReadLine()!;

            conductorActivo = new Conductor
            {
                Nombre = nombre,
                Edad = edad,
                Licencia = licencia,
                EstadoLicencia = true
            };

            Console.WriteLine("Conductor registrado con éxito.");
        }

        static void EliminarConductor()
        {
            if (conductorActivo == null)
            {
                Console.WriteLine("No hay conductor registrado.");
                return;
            }

            conductorActivo = null;

            Console.WriteLine("Conductor eliminado con éxito.");
        }

        static void MostrarConductor()
        {
            if (conductorActivo == null)
            {
                Console.WriteLine("No hay conductor registrado.");
                return;
            }

            Console.WriteLine("\n=== INFORMACIÓN DEL CONDUCTOR ===");

            Console.WriteLine("Nombre: " + conductorActivo.Nombre);

            Console.WriteLine("Edad: " + conductorActivo.Edad);

            Console.WriteLine("Licencia: " + conductorActivo.Licencia);
            if (conductorActivo.EstadoLicencia)
            {
                Console.WriteLine("Estado de la licencia: Válida");
            }
            else
            {
                Console.WriteLine("Estado de la licencia: No válida");
            }
        }


        // =========================
        // MÉTODOS DE VEHÍCULOS
        // =========================

        static void RegistrarVehiculo()
        {
            if (conductorActivo == null)
            {
                Console.WriteLine("Primero debes registrar un conductor.");
                return;
            }

            Console.Write("Marca: ");
            string marca = Console.ReadLine()!;

            Console.Write("Modelo: ");
            string modelo = Console.ReadLine()!;

            Console.Write("Año: ");

            if (!int.TryParse(Console.ReadLine(), out int anio))
            {
                Console.WriteLine("Año inválido.");
                return;
            }

            Console.Write("Color: ");
            string color = Console.ReadLine()!;

            Console.Write("Placa: ");
            string placa = Console.ReadLine()!;

            Vehiculo nuevoVehiculo = new Vehiculo
            {
                Marca = marca,
                Modelo = modelo,
                Anio = anio,
                Color = color,
                Placa = placa
            };

            // Agregar el vehículo a la lista del conductor
            conductorActivo.Vehiculos.Add(nuevoVehiculo);

            Console.WriteLine("Vehículo registrado con éxito.");
        }

        static void MostrarVehiculos()
        {
            if (conductorActivo == null)
            {
                Console.WriteLine("No hay conductor registrado.");
                return;
            }

            if (conductorActivo.Vehiculos.Count == 0)
            {
                Console.WriteLine("El conductor no tiene vehículos registrados.");
                return;
            }

            Console.WriteLine("\n=== VEHÍCULOS REGISTRADOS ===");

            for (int i = 0; i < conductorActivo.Vehiculos.Count; i++)
            {
                Vehiculo vehiculo = conductorActivo.Vehiculos[i];

                Console.WriteLine($"\nVehículo #{i + 1}");
                Console.WriteLine("Marca: " + vehiculo.Marca);
                Console.WriteLine("Modelo: " + vehiculo.Modelo);
                Console.WriteLine("Año: " + vehiculo.Anio);
                Console.WriteLine("Color: " + vehiculo.Color);
                Console.WriteLine("Placa: " + vehiculo.Placa);
            }
        }

        static void AsignarVehiculo()
        {
            if (conductorActivo == null)
            {
                Console.WriteLine("No hay conductor registrado.");
                return;
            }

            if (conductorActivo.Vehiculos.Count == 0)
            {
                Console.WriteLine("No hay vehículos registrados.");
                return;
            }

            Console.WriteLine("\n=== VEHÍCULOS DISPONIBLES ===");

            for (int i = 0; i < conductorActivo.Vehiculos.Count; i++)
            {
                Vehiculo vehiculo = conductorActivo.Vehiculos[i];

                Console.WriteLine($"{i + 1}. {vehiculo.Marca} " + $"{vehiculo.Modelo} - " + $"Placa: {vehiculo.Placa}");
            }

            Console.Write("Selecciona un vehículo: ");

            if (!int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.WriteLine("Opción inválida.");
                return;
            }

            if (opcion < 1 || opcion > conductorActivo.Vehiculos.Count)
            {
                Console.WriteLine("Vehículo no válido.");
                return;
            }

            // Se asigna el vehículo seleccionado
            conductorActivo.VehiculoAsignado = conductorActivo.Vehiculos[opcion - 1];

            Console.WriteLine("Vehículo asignado correctamente.");
        }

        // =========================
        // MÉTODOS DE CIUDADES
        // =========================

        static void RegistrarCiudad()
        {
            if (conductorActivo == null)
            {
                Console.WriteLine("Primero debes registrar un conductor.");
                return;
            }

            Console.Write("Nombre de la ciudad donde puede operar: ");
            string nombreCiudad = Console.ReadLine()!;

            Ciudad nuevaCiudad = new Ciudad
            {
                Nombre = nombreCiudad
            };

            // La ciudad pertenece al conductor
            conductorActivo.Ciudades.Add(nuevaCiudad);

            Console.WriteLine("Ciudad registrada con éxito.");
        }

        static void MostrarCiudades()
        {
            if (conductorActivo == null)
            {
                Console.WriteLine("No hay conductor registrado.");
                return;
            }

            if (conductorActivo.Ciudades.Count == 0)
            {
                Console.WriteLine("El conductor no tiene ciudades registradas.");
                return;
            }

            Console.WriteLine("\n=== CIUDADES DONDE PUEDE OPERAR ===");

            for (int i = 0; i < conductorActivo.Ciudades.Count; i++)
            {
                Console.WriteLine($"{i + 1}. " + conductorActivo.Ciudades[i].Nombre);
            }
        }

        // =========================
        // INFORMACIÓN COMPLETA
        // =========================

        static void MostrarInformacionCompleta()
        {
            Console.WriteLine("\n=================================");
            Console.WriteLine(" INFORMACIÓN COMPLETA TuCarreraSV");
            Console.WriteLine("=================================");

            // Información del usuario
            Console.WriteLine("\n--- USUARIO ---");

            if (usuarioRegistrado != null)
            {
                Console.WriteLine("Correo: " + usuarioRegistrado.Correo);
            }
            else
            {
                Console.WriteLine("No hay usuario registrado.");
            }

            // Información del conductor
            Console.WriteLine("\n--- CONDUCTOR ---");

            if (conductorActivo == null)
            {
                Console.WriteLine("No hay conductor registrado.");
                return;
            }

            Console.WriteLine("Nombre: " + conductorActivo.Nombre);

            Console.WriteLine("Edad: " + conductorActivo.Edad);

            Console.WriteLine("Licencia: " + conductorActivo.Licencia);

            // Vehículo asignado
            Console.WriteLine("\n--- VEHÍCULO ASIGNADO ---");

            if (conductorActivo.VehiculoAsignado != null)
            {
                Console.WriteLine("Marca: " +
                    conductorActivo.VehiculoAsignado.Marca);

                Console.WriteLine("Modelo: " +
                    conductorActivo.VehiculoAsignado.Modelo);

                Console.WriteLine("Placa: " +
                    conductorActivo.VehiculoAsignado.Placa);
            }
            else
            {
                Console.WriteLine("No hay vehículo asignado.");
            }

            // Cantidad de vehículos
            Console.WriteLine("\nCantidad de vehículos registrados: " + conductorActivo.Vehiculos.Count);

            // Ciudades donde puede operar
            Console.WriteLine("\n--- CIUDADES DONDE PUEDE OPERAR ---");

            if (conductorActivo.Ciudades.Count == 0)
            {
                Console.WriteLine("No hay ciudades registradas.");
            }
            else
            {
                foreach (Ciudad ciudad in conductorActivo.Ciudades)
                {
                    Console.WriteLine("- " + ciudad.Nombre);
                }
            }
            System.Threading.Thread.Sleep(10000);
        }
    }





    // Clases 
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

        // Un conductor puede registrar varios vehículos
        public List<Vehiculo> Vehiculos { get; set; }
            = new List<Vehiculo>();

        // Solo uno de los vehículos puede estar asignado
        public Vehiculo? VehiculoAsignado { get; set; }

        // Ciudades donde este conductor puede operar, solo puede operar en esas ciudades
        public List<Ciudad> Ciudades { get; set; }
            = new List<Ciudad>();
    }

    class Vehiculo
    {
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int Anio { get; set; }
        public string? Color { get; set; }
        public string? Placa { get; set; }
    }

    class Ciudad
    {
        public string? Nombre { get; set; }
    }
}