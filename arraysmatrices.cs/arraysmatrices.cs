using System;

namespace GestionEstudiantes
{
    // Clase para representar un estudiante
    class Estudiante
    {
        public string ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string[] Telefonos { get; set; }

        // Constructor
        public Estudiante()
        {
            Telefonos = new string[3]; // Array para 3 números de teléfono
        }

        // Método para mostrar la información del estudiante
        public void MostrarInformacion()
        {
            Console.WriteLine("\n===== INFORMACIÓN DEL ESTUDIANTE =====");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Números de Teléfono:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"  Teléfono {i + 1}: {Telefonos[i]}");
            }
            Console.WriteLine("======================================\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║   SISTEMA DE REGISTRO DE ESTUDIANTES         ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝\n");

            // Crear un nuevo estudiante
            Estudiante estudiante = new Estudiante();

            // Solicitar y almacenar los datos del estudiante
            Console.Write("Ingrese el ID del estudiante: ");
            estudiante.ID = Console.ReadLine();

            Console.Write("Ingrese los nombres del estudiante: ");
            estudiante.Nombres = Console.ReadLine();

            Console.Write("Ingrese los apellidos del estudiante: ");
            estudiante.Apellidos = Console.ReadLine();

            Console.Write("Ingrese la dirección del estudiante: ");
            estudiante.Direccion = Console.ReadLine();

            // Solicitar los tres números de teléfono usando un array
            Console.WriteLine("\nIngrese los números de teléfono:");
            for (int i = 0; i < estudiante.Telefonos.Length; i++)
            {
                Console.Write($"Teléfono {i + 1}: ");
                estudiante.Telefonos[i] = Console.ReadLine();
            }

            // Mostrar la información registrada
            estudiante.MostrarInformacion();

            // Ejemplo adicional: Crear otro estudiante con datos predefinidos
            Console.WriteLine("\n--- Ejemplo con datos predefinidos ---");
            Estudiante estudiante2 = new Estudiante
            {
                ID = "2024001",
                Nombres = "María José",
                Apellidos = "García López",
                Direccion = "Av. Principal #123, Ciudad",
                Telefonos = new string[] { "555-1234", "555-5678", "555-9012" }
            };

            estudiante2.MostrarInformacion();

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
