using System;

namespace ArbolBinarioDemo
{
	// Clase Nodo
	public class Nodo
	{
		public int Valor;
		public Nodo Izquierdo;
		public Nodo Derecho;

		public Nodo(int valor)
		{
			Valor = valor;
			Izquierdo = null;
			Derecho = null;
		}
	}

	// Clase Árbol Binario de Búsqueda (BST)
	public class BST
	{
		public Nodo Raiz;

		public BST()
		{
			Raiz = null;
		}

		// Insertar un valor en el árbol
		public void Insertar(int valor)
		{
			Raiz = InsertarRec(Raiz, valor);
		}

		private Nodo InsertarRec(Nodo nodo, int valor)
		{
			if (nodo == null)
				return new Nodo(valor);
			if (valor < nodo.Valor)
				nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor);
			else if (valor > nodo.Valor)
				nodo.Derecho = InsertarRec(nodo.Derecho, valor);
			// Si es igual, no inserta duplicados
			return nodo;
		}

		// Buscar un valor en el árbol
		public bool Buscar(int valor)
		{
			return BuscarRec(Raiz, valor);
		}

		private bool BuscarRec(Nodo nodo, int valor)
		{
			if (nodo == null) return false;
			if (valor == nodo.Valor) return true;
			if (valor < nodo.Valor) return BuscarRec(nodo.Izquierdo, valor);
			else return BuscarRec(nodo.Derecho, valor);
		}

		// Eliminar un valor del árbol
		public void Eliminar(int valor)
		{
			Raiz = EliminarRec(Raiz, valor);
		}

		private Nodo EliminarRec(Nodo nodo, int valor)
		{
			if (nodo == null) return null;
			if (valor < nodo.Valor)
				nodo.Izquierdo = EliminarRec(nodo.Izquierdo, valor);
			else if (valor > nodo.Valor)
				nodo.Derecho = EliminarRec(nodo.Derecho, valor);
			else
			{
				// Nodo con un solo hijo o sin hijos
				if (nodo.Izquierdo == null) return nodo.Derecho;
				else if (nodo.Derecho == null) return nodo.Izquierdo;
				// Nodo con dos hijos: obtener el sucesor
				nodo.Valor = MinValor(nodo.Derecho);
				nodo.Derecho = EliminarRec(nodo.Derecho, nodo.Valor);
			}
			return nodo;
		}

		// Recorridos
		public void Preorden() { PreordenRec(Raiz); Console.WriteLine(); }
		private void PreordenRec(Nodo nodo)
		{
			if (nodo == null) return;
			Console.Write(nodo.Valor + " ");
			PreordenRec(nodo.Izquierdo);
			PreordenRec(nodo.Derecho);
		}

		public void Inorden() { InordenRec(Raiz); Console.WriteLine(); }
		private void InordenRec(Nodo nodo)
		{
			if (nodo == null) return;
			InordenRec(nodo.Izquierdo);
			Console.Write(nodo.Valor + " ");
			InordenRec(nodo.Derecho);
		}

		public void Postorden() { PostordenRec(Raiz); Console.WriteLine(); }
		private void PostordenRec(Nodo nodo)
		{
			if (nodo == null) return;
			PostordenRec(nodo.Izquierdo);
			PostordenRec(nodo.Derecho);
			Console.Write(nodo.Valor + " ");
		}

		// Valor mínimo
		public int Minimo()
		{
			if (Raiz == null) throw new InvalidOperationException("Árbol vacío");
			return MinValor(Raiz);
		}
		private int MinValor(Nodo nodo)
		{
			while (nodo.Izquierdo != null)
				nodo = nodo.Izquierdo;
			return nodo.Valor;
		}

		// Valor máximo
		public int Maximo()
		{
			if (Raiz == null) throw new InvalidOperationException("Árbol vacío");
			return MaxValor(Raiz);
		}
		private int MaxValor(Nodo nodo)
		{
			while (nodo.Derecho != null)
				nodo = nodo.Derecho;
			return nodo.Valor;
		}

		// Altura del árbol
		public int Altura()
		{
			return AlturaRec(Raiz);
		}
		private int AlturaRec(Nodo nodo)
		{
			if (nodo == null) return 0;
			int izq = AlturaRec(nodo.Izquierdo);
			int der = AlturaRec(nodo.Derecho);
			return Math.Max(izq, der) + 1;
		}

		// Limpiar el árbol
		public void Limpiar() { Raiz = null; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			BST arbol = new BST();
			int opcion;
			do
			{
				Console.WriteLine("\n--- MENÚ ÁRBOL BINARIO DE BÚSQUEDA ---");
				Console.WriteLine("1. Insertar valor");
				Console.WriteLine("2. Buscar valor");
				Console.WriteLine("3. Eliminar valor");
				Console.WriteLine("4. Recorrido Preorden");
				Console.WriteLine("5. Recorrido Inorden");
				Console.WriteLine("6. Recorrido Postorden");
				Console.WriteLine("7. Mostrar valor mínimo");
				Console.WriteLine("8. Mostrar valor máximo");
				Console.WriteLine("9. Mostrar altura del árbol");
				Console.WriteLine("10. Limpiar árbol");
				Console.WriteLine("0. Salir");
				Console.Write("Seleccione una opción: ");
				int.TryParse(Console.ReadLine(), out opcion);

				switch (opcion)
				{
					case 1:
						Console.Write("Ingrese valor a insertar: ");
						if (int.TryParse(Console.ReadLine(), out int valIns))
							arbol.Insertar(valIns);
						break;
					case 2:
						Console.Write("Ingrese valor a buscar: ");
						if (int.TryParse(Console.ReadLine(), out int valBus))
							Console.WriteLine(arbol.Buscar(valBus) ? "Valor encontrado." : "Valor no encontrado.");
						break;
					case 3:
						Console.Write("Ingrese valor a eliminar: ");
						if (int.TryParse(Console.ReadLine(), out int valElim))
							arbol.Eliminar(valElim);
						break;
					case 4:
						Console.WriteLine("Recorrido Preorden:");
						arbol.Preorden();
						break;
					case 5:
						Console.WriteLine("Recorrido Inorden:");
						arbol.Inorden();
						break;
					case 6:
						Console.WriteLine("Recorrido Postorden:");
						arbol.Postorden();
						break;
					case 7:
						Console.WriteLine($"Valor mínimo: {arbol.Minimo()}");
						break;
					case 8:
						Console.WriteLine($"Valor máximo: {arbol.Maximo()}");
						break;
					case 9:
						Console.WriteLine($"Altura del árbol: {arbol.Altura()}");
						break;
					case 10:
						arbol.Limpiar();
						Console.WriteLine("Árbol limpiado.");
						break;
					case 0:
						Console.WriteLine("Saliendo...");
						break;
					default:
						Console.WriteLine("Opción no válida.");
						break;
				}
			} while (opcion != 0);
		}
	}
}
