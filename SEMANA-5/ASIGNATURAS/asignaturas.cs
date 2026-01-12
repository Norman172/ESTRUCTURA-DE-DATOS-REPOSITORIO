using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SEMANA_5.ASIGNATURAS
{
    public class Asignatura
    {
        public string Nombre { get; }

        public Asignatura(string nombre)
        {
            Nombre = nombre;
        }

        public string EstudiarMensaje()
        {
            return $"Yo estudio {Nombre}";
        }
    }

    public class Curso
    {
        private readonly List<Asignatura> _asignaturas;

        public Curso(IEnumerable<string> nombresAsignaturas)
        {
            _asignaturas = nombresAsignaturas.Select(n => new Asignatura(n)).ToList();
        }

        public IReadOnlyList<Asignatura> Asignaturas => _asignaturas;

        public void MostrarAsignaturas(TextWriter salida)
        {
            foreach (var asignatura in _asignaturas)
            {
                salida.WriteLine(asignatura.EstudiarMensaje());
            }
        }
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            var asignaturas = args != null && args.Length > 0
                ? args
                : new[] { "Matemáticas", "Física", "Química", "Historia", "Lengua" };

            var curso = new Curso(asignaturas);
            curso.MostrarAsignaturas(Console.Out);
        }
    }
}
