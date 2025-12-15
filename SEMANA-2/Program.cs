using System;
class circulo

{
    private double diametro;
    private double radio;
    public double CalcularArea(double radio)

    {

        return Math.PI * radio * radio;

    }
    public double calcularperimetro(double diametro)

    {

        return Math.PI * diametro;

    }


}

class cuadrado

{
    private double lado;

    public double CalcularArea(double lado)

    {

        return lado * lado;

    }
    public double calcularperimetro(double lado)

    {

        return 4 * lado;

    }



}

class program
{
    static void Main(string[] args)
    {
        circulo cir1 = new circulo();
        Console.WriteLine("Área del círculo: " + cir1.CalcularArea(3));
        Console.WriteLine("Perímetro del círculo: " + cir1.calcularperimetro(6));
        cuadrado C2 = new cuadrado();
        Console.WriteLine("Área del cuadrado: " + C2.CalcularArea(4));
        cuadrado c3 = new cuadrado();
        Console.WriteLine("Perímetro del cuadrado: " + c3.calcularperimetro(3));
    }
}
