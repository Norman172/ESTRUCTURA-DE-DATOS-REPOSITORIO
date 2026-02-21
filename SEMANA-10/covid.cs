
using System;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		// Generar 500 ciudadanos ficticios
		var ciudadanos = new List<Ciudadano>();
		for (int i = 1; i <= 500; i++)
		{
			ciudadanos.Add(new Ciudadano(i, $"Ciudadano {i}"));
		}
		// Generar 75 ciudadanos vacunados con Pfizer (IDs aleatorios)
		var rnd = new Random();
		var vacunadosPfizer = new HashSet<Ciudadano>();
		var indicesPfizer = new HashSet<int>();
		while (vacunadosPfizer.Count < 75)
		{
			int idx = rnd.Next(0, ciudadanos.Count);
			if (indicesPfizer.Add(idx))
				vacunadosPfizer.Add(ciudadanos[idx]);
		}
		// Generar 75 ciudadanos vacunados con AstraZeneca (IDs aleatorios, sin repetir con Pfizer)
		var vacunadosAstra = new HashSet<Ciudadano>();
		var indicesAstra = new HashSet<int>();
		while (vacunadosAstra.Count < 75)
		{
			int idx = rnd.Next(0, ciudadanos.Count);
			if (!indicesPfizer.Contains(idx) && indicesAstra.Add(idx))
				vacunadosAstra.Add(ciudadanos[idx]);
		}
		// Operaciones de conjuntos
		// 1. No vacunados
		var noVacunados = new HashSet<Ciudadano>(ciudadanos);
		noVacunados.ExceptWith(vacunadosPfizer);
		noVacunados.ExceptWith(vacunadosAstra);

		// 2. Ambas dosis (vacunados con ambas vacunas)
		var ambasDosis = new HashSet<Ciudadano>(vacunadosPfizer);
		ambasDosis.IntersectWith(vacunadosAstra);

		// 3. Solo Pfizer
		var soloPfizer = new HashSet<Ciudadano>(vacunadosPfizer);
		soloPfizer.ExceptWith(vacunadosAstra);

		// 4. Solo AstraZeneca
		var soloAstra = new HashSet<Ciudadano>(vacunadosAstra);
		soloAstra.ExceptWith(vacunadosPfizer);
		// Mostrar resultados
		Console.WriteLine("Ciudadanos que NO se han vacunado:");
		foreach (var c in noVacunados)
			Console.WriteLine(c);
		Console.WriteLine($"Total: {noVacunados.Count}\n");

		Console.WriteLine("Ciudadanos que han recibido ambas dosis:");
		foreach (var c in ambasDosis)
			Console.WriteLine(c);
		Console.WriteLine($"Total: {ambasDosis.Count}\n");

		Console.WriteLine("Ciudadanos que solo han recibido la vacuna de Pfizer:");
		foreach (var c in soloPfizer)
			Console.WriteLine(c);
		Console.WriteLine($"Total: {soloPfizer.Count}\n");

		Console.WriteLine("Ciudadanos que solo han recibido la vacuna de AstraZeneca:");
		foreach (var c in soloAstra)
			Console.WriteLine(c);
		Console.WriteLine($"Total: {soloAstra.Count}\n");
	}
}

class Ciudadano
{
	public int Id { get; set; }
	public string Nombre { get; set; }
	public Ciudadano(int id, string nombre)
	{
		Id = id;
		Nombre = nombre;
	}
	public override bool Equals(object obj)
	{
		return obj is Ciudadano c && c.Id == Id;
	}
	public override int GetHashCode()
	{
		return Id.GetHashCode();
	}
	public override string ToString() => Nombre;
}

enum Vacuna { Pfizer, AstraZeneca }
