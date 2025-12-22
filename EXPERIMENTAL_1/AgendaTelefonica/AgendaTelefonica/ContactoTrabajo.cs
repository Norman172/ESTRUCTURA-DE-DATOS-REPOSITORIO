// Subclase que representa un contacto de trabajo
public class ContactoTrabajo : Contacto
{
    private string empresa;

    public string Empresa
    {
        get => empresa;
        set => empresa = value;
    }

    // Constructor: llama al constructor base e inicializa la empresa
    public ContactoTrabajo(string nombre, string numero, string correo, bool esFavorito, string empresa)
        : base(nombre, numero, correo, esFavorito)
    {
        this.empresa = empresa;
    }

    // Implementación del método Mostrar
    public override void Mostrar()
    {
        Console.WriteLine($"{"[Trabajo]",-15} | {Nombre,-20} | {Numero,-15} | {Correo,-25} | {(EsFavorito ? "Sí" : "No"),-8} | {Empresa,-20}");
    }
}
