using System;

// Clase que representa un círculo 
class circulo
{
    // Atributos privados del círculo
    private double diametro;
    private double radio;

    // Método para calcular el área del círculo: phi * radio al cuadrado
    public double CalcularArea(double radio)
    {
        return Math.PI * radio * radio;
    }

    // Método para calcular el perímetro del círculo: phi * diametro
    public double calcularperimetro(double diametro)
    {
        return Math.PI * diametro;
    }
}

// Clase que representa un cuadrado 
class cuadrado
{
    // Atributo privado del cuadrado
    private double lado;

    // Método para calcular el área del cuadrado: lado * lado
    public double CalcularArea(double lado)
    {
        return lado * lado;
    }

    // Método para calcular el perímetro del cuadrado: 4 * lado
    public double calcularperimetro(double lado)
    {
        return 4 * lado;
    }
}

// Clase principal del programa
class program
{
    static void Main(string[] args)
    {
        // Crear un objeto círculo y calcular su área con radio 3
        circulo cir1 = new circulo();
        Console.WriteLine("Área del círculo: " + cir1.CalcularArea(3));

        // Calcular el perímetro del círculo con diámetro 6
        Console.WriteLine("Perímetro del círculo: " + cir1.calcularperimetro(6));

        // Crear un objeto cuadrado y calcular su área con lado 4
        cuadrado C2 = new cuadrado();
        Console.WriteLine("Área del cuadrado: " + C2.CalcularArea(4));

        // Crear otro cuadrado y calcular su perímetro con lado 3
        cuadrado c3 = new cuadrado();
        Console.WriteLine("Perímetro del cuadrado: " + c3.calcularperimetro(3));
    }
}
