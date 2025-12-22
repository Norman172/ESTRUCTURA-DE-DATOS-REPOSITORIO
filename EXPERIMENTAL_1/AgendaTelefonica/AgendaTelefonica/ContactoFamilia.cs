//Subclase que representa un contacto perteneciente a familia
using static System.Runtime.InteropServices.JavaScript.JSType;

public class ContactoFamilia : Contacto
{
    private string grupo;
    public string Grupo
    {
        get { return grupo; }
        set { grupo = value; }
    }
    // Constructor: llama al constructor e inicializa el grupo
    public ContactoFamilia(string grupo, string nombre, string numero, string correo, bool esFavorito)
        : base(nombre, numero, correo, esFavorito)
    {
        this.grupo = grupo;
    }
    // Se implementa el método mostrar
    public override void Mostrar()
    {
        Console.WriteLine($"{"[Familia]",-15} | {Nombre,-20} | {Numero,-15} | {Correo,-25} | {(EsFavorito ? "Sí" : "No"),-8} | {Grupo,-20}");
    }
}
