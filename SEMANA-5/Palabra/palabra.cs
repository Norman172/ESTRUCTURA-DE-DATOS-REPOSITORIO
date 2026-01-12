using System;
using System.Collections.Generic;
using System.Linq;

namespace SEMANA_5.Palabra
{
    public class ContadorVocales
    {
        private string _palabra;
        private Dictionary<char, int> _conteoVocales;

        public ContadorVocales()
        {
            _palabra = string.Empty;
            _conteoVocales = new Dictionary<char, int>();
        }

        public void SolicitarPalabra()
        {
            Console.Write("Ingrese una palabra: ");
            _palabra = Console.ReadLine() ?? string.Empty;
        }

        public void ContarVocales()
        {
            // Inicializar contadores de vocales
            char[] vocales = { 'a', 'e', 'i', 'o', 'u' };
            _conteoVocales.Clear();

            foreach (var vocal in vocales)
            {
                _conteoVocales[vocal] = 0;
            }

            // Contar vocales en la palabra (ignorando mayúsculas)
            string palabraLower = _palabra.ToLower();
            foreach (char letra in palabraLower)
            {
                if (_conteoVocales.ContainsKey(letra))
                {
                    _conteoVocales[letra]++;
                }
            }
        }

        public void MostrarResultados()
        {
            Console.WriteLine($"\nAnálisis de la palabra: \"{_palabra}\"");
            Console.WriteLine("\nConteo de vocales:");
            Console.WriteLine("------------------");

            foreach (var kvp in _conteoVocales.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key.ToString().ToUpper()}: {kvp.Value}");
            }

            int totalVocales = _conteoVocales.Values.Sum();
            Console.WriteLine($"\nTotal de vocales: {totalVocales}");
        }

        public IReadOnlyDictionary<char, int> ObtenerConteo()
        {
            return _conteoVocales;
        }
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            var contador = new ContadorVocales();
            contador.SolicitarPalabra();
            contador.ContarVocales();
            contador.MostrarResultados();
        }
    }
}
