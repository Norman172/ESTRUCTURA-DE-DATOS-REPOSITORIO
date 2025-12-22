// Clase que administra la agenda telefónica
public class AgendaTelefonica
{
    // Vector para almacenar contactos
    private Contacto[] contactos;

    // Contador de cuántos contactos se han registrado
    private int contador;

    // Constructor: define la capacidad máxima de la agenda
    public AgendaTelefonica(int capacidad)
    {
        contactos = new Contacto[capacidad];
        contador = 0;
    }

    // Método para agregar un contacto a la agenda
    public void AgregarContacto(Contacto c)
    {
        if (contador < contactos.Length)
        {
            contactos[contador++] = c;
            Console.WriteLine("Contacto agregado exitosamente.");
        }
        else
        {
            Console.WriteLine("Agenda llena. No se puede agregar más contactos.");
        }
    }

    // Método para mostrar todos los contactos
    public void MostrarContactos()
    {
        Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                         AGENDA TELEFÓNICA                                                      ║");
        Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
        Console.WriteLine("Tipo            | Nombre               | Número          | Correo                    | Favorito | Extra");
        Console.WriteLine("________________|______________________|_________________|___________________________|__________|____________________");

        for (int i = 0; i < contador; i++)
        {
            contactos[i].Mostrar();
        }
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
    }

    // Método para ordenar los contactos alfabéticamente por nombre
    public void OrdenarPorNombre()
    {
        Array.Sort(contactos, 0, contador, Comparer<Contacto>.Create(
            (a, b) => string.Compare(a.Nombre, b.Nombre, StringComparison.OrdinalIgnoreCase)
        ));

        Console.WriteLine("\nContactos ordenados alfabéticamente por nombre.");
    }

    // Método para mostrar solo contactos favoritos
    public void MostrarFavoritos()
    {
        Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                      CONTACTOS FAVORITOS                                                       ║");
        Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
        Console.WriteLine("Tipo            | Nombre               | Número          | Correo                    | Favorito | Extra");
        Console.WriteLine("________________|______________________|_________________|___________________________|__________|____________________");

        bool hayFavoritos = false;
        for (int i = 0; i < contador; i++)
        {
            if (contactos[i].EsFavorito)
            {
                contactos[i].Mostrar();
                hayFavoritos = true;
            }
        }

        if (!hayFavoritos)
        {
            Console.WriteLine("No hay contactos marcados como favoritos.");
        }
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
    }

    // Método para buscar un contacto por nombre
    public void BuscarPorNombre(string nombre)
    {
        Console.WriteLine($"\nBuscando contactos con el nombre: {nombre}");
        bool encontrado = false;

        for (int i = 0; i < contador; i++)
        {
            if (contactos[i].Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
            {
                contactos[i].Mostrar();
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontraron contactos con ese nombre.");
        }
    }
}
