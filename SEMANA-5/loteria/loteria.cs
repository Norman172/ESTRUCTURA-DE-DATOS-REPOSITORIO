using System;
using System.Collections.Generic;
using System.Linq;

namespace SEMANA_5.Loteria
{
    public class LoteriaPrimitiva
    {
        private List<int> _numerosGanadores;
        private const int CANTIDAD_NUMEROS = 6;
        private const int NUMERO_MINIMO = 1;
        private const int NUMERO_MAXIMO = 49;

        public LoteriaPrimitiva()
        {
            _numerosGanadores = new List<int>();
        }

        public void SolicitarNumeros()
        {
            Console.WriteLine($"Ingrese los {CANTIDAD_NUMEROS} números ganadores de la lotería primitiva ({NUMERO_MINIMO}-{NUMERO_MAXIMO}):");

            for (int i = 0; i < CANTIDAD_NUMEROS; i++)
            {
                int numero = LeerNumeroValido(i + 1);
                _numerosGanadores.Add(numero);
            }
        }

        private int LeerNumeroValido(int posicion)
        {
            while (true)
            {
                Console.Write($"Número {posicion}: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int numero))
                {
                    if (numero >= NUMERO_MINIMO && numero <= NUMERO_MAXIMO)
                    {
                        if (!_numerosGanadores.Contains(numero))
                        {
                            return numero;
                        }
                        else
                        {
                            Console.WriteLine($"El número {numero} ya fue ingresado. Intente con otro.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"El número debe estar entre {NUMERO_MINIMO} y {NUMERO_MAXIMO}.");
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                }
            }
        }

        public void MostrarNumerosOrdenados()
        {
            var numerosOrdenados = _numerosGanadores.OrderBy(n => n).ToList();

            Console.WriteLine("\nNúmeros ganadores ordenados de menor a mayor:");
            Console.WriteLine(string.Join(" - ", numerosOrdenados));
        }

        public IReadOnlyList<int> ObtenerNumeros()
        {
            return _numerosGanadores.AsReadOnly();
        }
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            var loteria = new LoteriaPrimitiva();
            loteria.SolicitarNumeros();
            loteria.MostrarNumerosOrdenados();
        }
    }
}
