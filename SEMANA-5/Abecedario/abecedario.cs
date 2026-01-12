using System;
using System.Collections.Generic;
using System.Linq;

namespace SEMANA_5.Abecedario
{
    public class GestorAbecedario
    {
        private List<char> _letras;

        public GestorAbecedario()
        {
            _letras = new List<char>();
        }

        public void CargarAbecedario()
        {
            // Abecedario español completo (27 letras con Ñ)
            string abecedario = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            _letras = abecedario.ToList();
        }

        public void EliminarMultiplosDeTres()
        {
            // Crear una nueva lista con las letras que NO están en posiciones múltiplos de 3
            // Posición 1 = índice 0, Posición 2 = índice 1, Posición 3 = índice 2 (múltiplo de 3)
            var letrasResultantes = new List<char>();

            for (int i = 0; i < _letras.Count; i++)
            {
                int posicion = i + 1; // Convertir índice a posición (base 1)
                if (posicion % 3 != 0)
                {
                    letrasResultantes.Add(_letras[i]);
                }
            }

            _letras = letrasResultantes;
        }

        public void MostrarAbecedario(string titulo = "Abecedario:")
        {
            Console.WriteLine($"\n{titulo}");
            Console.WriteLine(string.Join(" ", _letras));
            Console.WriteLine($"Total de letras: {_letras.Count}");
        }

        public IReadOnlyList<char> ObtenerLetras()
        {
            return _letras.AsReadOnly();
        }
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            var gestor = new GestorAbecedario();

            // Cargar el abecedario completo
            gestor.CargarAbecedario();
            gestor.MostrarAbecedario("Abecedario original:");

            // Eliminar las letras en posiciones múltiplos de 3
            gestor.EliminarMultiplosDeTres();
            gestor.MostrarAbecedario("Abecedario sin múltiplos de 3:");
        }
    }
}
