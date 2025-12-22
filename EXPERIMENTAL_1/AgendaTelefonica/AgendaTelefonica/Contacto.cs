// Clase que representa a un teléfono genérico
public abstract class Contacto
{
    // Se realiza el encapsulamiento que pasan a ser campos privados
    private string nombre;
    private string numero;
    private string correo;
     private bool esFavorito;

    // Se estabelcen las propiedades públicas que permiten tener acceso a los campos prvados
    public string Nombre
    {
        get => nombre;
        set => nombre = value;
    }
    public string Numero
    {
        get => numero;
        set => numero = value;
    }
    public string Correo
    {
        get => correo;
        set => correo = value;
    }
     
    public bool EsFavorito
    {
        get => esFavorito;
        set => esFavorito = value;
    }
    // Se define el constructor común para los contactos
    public Contacto(string nombre, string numero, string correo, bool esFavorito)
    {
        this.nombre = nombre;
        this.numero = numero;
        this.correo = correo;
        this.esFavorito = esFavorito;
    }
    // Método abstracto que ha de ser implantado en las subclases
    public abstract void Mostrar();
}
