using System;

public class Estudiante
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Correo { get; set; }
    public int Nota { get; set; }
    public Estudiante? Siguiente { get; set; }

    public Estudiante(string cedula, string nombre, string apellido, string correo, int nota)
    {
        Cedula = cedula;
        Nombre = nombre;
        Apellido = apellido;
        Correo = correo;
        Nota = nota;
        Siguiente = null;
    }
}

public class ListaEstudiantes
{
    private Estudiante? cabeza;
    private Estudiante? cola;

    public void AgregarEstudiante(Estudiante estudiante)
    {
        if (estudiante.Nota >= 6) // Aprobado
        {
            estudiante.Siguiente = cabeza;
            cabeza = estudiante;
            if (cola == null) cola = estudiante;
        }
        else // Reprobado
        {
            if (cola == null)
            {
                cabeza = cola = estudiante;
            }
            else
            {
                cola.Siguiente = estudiante;
                cola = estudiante;
            }
        }
    }

    public Estudiante? BuscarPorCedula(string cedula)
    {
        Estudiante? actual = cabeza;
        while (actual != null)
        {
            if (actual.Cedula == cedula)
                return actual;
            actual = actual.Siguiente;
        }
        return null;
    }

    public bool EliminarPorCedula(string cedula)
    {
        Estudiante? actual = cabeza;
        Estudiante? anterior = null;
        while (actual != null)
        {
            if (actual.Cedula == cedula)
            {
                if (anterior == null)
                {
                    cabeza = actual.Siguiente;
                    if (cola == actual) cola = cabeza;
                }
                else
                {
                    anterior.Siguiente = actual.Siguiente;
                    if (cola == actual) cola = anterior;
                }
                return true;
            }
            anterior = actual;
            actual = actual.Siguiente;
        }
        return false;
    }

    public int TotalAprobados()
    {
        int total = 0;
        Estudiante? actual = cabeza;
        while (actual != null)
        {
            if (actual.Nota >= 6) total++;
            actual = actual.Siguiente;
        }
        return total;
    }

    public int TotalReprobados()
    {
        int total = 0;
        Estudiante? actual = cabeza;
        while (actual != null)
        {
            if (actual.Nota < 6) total++;
            actual = actual.Siguiente;
        }
        return total;
    }

    public void MostrarEstudiantes()
    {
        Estudiante? actual = cabeza;
        while (actual != null)
        {
            Console.WriteLine($"Cédula: {actual.Cedula}, Nombre: {actual.Nombre} {actual.Apellido}, Correo: {actual.Correo}, Nota: {actual.Nota}");
            actual = actual.Siguiente;
        }
    }
}

class Program
{
    static void Main()
    {
        ListaEstudiantes lista = new ListaEstudiantes();
        while (true)
        {
            Console.WriteLine("\n1. Agregar estudiante\n2. Buscar estudiante por cédula\n3. Eliminar estudiante\n4. Total aprobados\n5. Total reprobados\n6. Mostrar todos\n7. Salir");
            Console.Write("Seleccione una opción: ");
            string? opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    Console.Write("Cédula: "); string cedula = Console.ReadLine() ?? "";
                    Console.Write("Nombre: "); string nombre = Console.ReadLine() ?? "";
                    Console.Write("Apellido: "); string apellido = Console.ReadLine() ?? "";
                    Console.Write("Correo: "); string correo = Console.ReadLine() ?? "";
                    Console.Write("Nota definitiva (1-10): "); int nota = int.Parse(Console.ReadLine() ?? "0");
                    lista.AgregarEstudiante(new Estudiante(cedula, nombre, apellido, correo, nota));
                    Console.WriteLine("Estudiante agregado.");
                    break;
                case "2":
                    Console.Write("Cédula a buscar: "); string cedBuscar = Console.ReadLine() ?? "";
                    var est = lista.BuscarPorCedula(cedBuscar);
                    if (est != null)
                        Console.WriteLine($"Encontrado: {est.Nombre} {est.Apellido}, Nota: {est.Nota}");
                    else
                        Console.WriteLine("No encontrado.");
                    break;
                case "3":
                    Console.Write("Cédula a eliminar: "); string cedEliminar = Console.ReadLine() ?? "";
                    if (lista.EliminarPorCedula(cedEliminar))
                        Console.WriteLine("Estudiante eliminado.");
                    else
                        Console.WriteLine("No encontrado.");
                    break;
                case "4":
                    Console.WriteLine($"Total aprobados: {lista.TotalAprobados()}");
                    break;
                case "5":
                    Console.WriteLine($"Total reprobados: {lista.TotalReprobados()}");
                    break;
                case "6":
                    lista.MostrarEstudiantes();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
}
