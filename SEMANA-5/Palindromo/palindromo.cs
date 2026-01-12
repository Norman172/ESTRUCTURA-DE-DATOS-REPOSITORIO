using System;
using System.Linq;

namespace SEMANA_5.Palindromo
{
    public class VerificadorPalindromo
    {
        public bool EsPalindromo(string palabra)
        {
            if (string.IsNullOrWhiteSpace(palabra))
                return false;

            // Normalizar la palabra: remover espacios, convertir a minúsculas y quitar acentos
            string palabraNormalizada = NormalizarTexto(palabra);

            // Comparar la palabra con su inversa
            string palabraInvertida = new string(palabraNormalizada.Reverse().ToArray());

            return palabraNormalizada.Equals(palabraInvertida, StringComparison.OrdinalIgnoreCase);
        }

        private string NormalizarTexto(string texto)
        {
            // Remover espacios y convertir a minúsculas
            string normalizado = texto.Replace(" ", "").ToLower();

            // Remover acentos comunes en español
            normalizado = normalizado
                .Replace("á", "a").Replace("é", "e").Replace("í", "i")
                .Replace("ó", "o").Replace("ú", "u").Replace("ü", "u");

            return normalizado;
        }

        public void VerificarYMostrar(string palabra)
        {
            bool resultado = EsPalindromo(palabra);

            if (resultado)
            {
                Console.WriteLine($"✓ \"{palabra}\" ES un palíndromo");
            }
            else
            {
                Console.WriteLine($"✗ \"{palabra}\" NO es un palíndromo");
            }
        }
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            var verificador = new VerificadorPalindromo();

            Console.WriteLine("=== Verificador de Palíndromos ===\n");
            Console.Write("Ingrese una palabra: ");
            string? entrada = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine();
                verificador.VerificarYMostrar(entrada);
            }
            else
            {
                Console.WriteLine("\nError: Debe ingresar una palabra válida.");
            }
        }
    }
}
