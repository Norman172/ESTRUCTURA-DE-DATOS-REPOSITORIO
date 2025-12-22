//Subclase que representa un contacto perteneciente a familia
using static System.Runtime.InteropServices.JavaScript.JSType;

public class ContactoAmigo : Contacto
{
    private string grupo;
    public string Grupo
    {
        get { return grupo; }
        set { grupo = value; }
    }
    // Constructor: llama al constructor e inicializa el grupo
    public ContactoAmigo(string grupo, string nombre, string numero, string correo, bool esFavorito)
        : base(nombre, numero, correo, esFavorito)
    {
        this.grupo = grupo;
    }
    // Se implementa el método mostrar
    public override void Mostrar()
    {
        Console.WriteLine($"{Grupo,-15} | {Nombre,-20} | {Numero,-10} | {Correo,-20} | {(EsFavorito ? "Sí" : "No"),-5}");
    }
}
