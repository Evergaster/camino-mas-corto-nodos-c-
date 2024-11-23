using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Grafo grafo = new Grafo();

        while (true)
        {
            Console.Write("Ingrese la cantidad de nodos: ");
            int cantNodos = int.Parse(Console.ReadLine());
            for (int i = 0; i < cantNodos; i++)
            {
                Console.Write($"Ingrese el nombre del nodo {i + 1}: ");
                string nodo = Console.ReadLine();
                grafo.AgregarNodo(nodo);
            }

            Console.Write("Ingrese la cantidad de aristas: ");
            int cantAristas = int.Parse(Console.ReadLine());
            for (int i = 0; i < cantAristas; i++)
            {
                Console.Write($"Ingrese la arista {i + 1} (origen destino costo): ");
                var arista = Console.ReadLine().Split();
                string origen = arista[0];
                string destino = arista[1];
                int costo = int.Parse(arista[2]);
                grafo.AgregarArista(origen, destino, costo);
            }

            Console.Write("Ingrese el nodo de inicio: ");
            string inicio = Console.ReadLine();
            Console.Write("Ingrese el nodo de fin: ");
            string fin = Console.ReadLine();

            grafo.MostrarCaminos(inicio, fin);

            Console.Write("¿Desea continuar? (s/n): ");
            string continuar = Console.ReadLine().ToLower();
            if (continuar != "s")
                break;

            Console.Clear();
        }
    }
}
