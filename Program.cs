using System;
using System.Collections.Generic;
class Program
{
    //everardo
    //miguel
    static void Main(string[] args)
    {
        Grafo grafo = new Grafo();
        Console.Write("Ingrese la cantidad de nodos: ");
            int cantNodos = int.Parse(Console.ReadLine());
            for (int i = 0; i < cantNodos; i++)
            {
                Console.Write($"Ingrese el nombre del nodo {i + 1}: ");
                string nodo = Console.ReadLine();
                grafo.AgregarNodo(nodo);
            }
            Console.WriteLine("Ingrese la unidad de medida:");
            grafo.Unidad = Console.ReadLine();
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
        while (true)
        {
            Console.Write("Ingrese el nodo de inicio: ");
            string inicio = Console.ReadLine();
            Console.Write("Ingrese el nodo de fin: ");
            string fin = Console.ReadLine();

            grafo.MostrarCaminos(inicio, fin);

            Console.Write("¿Desea continuar? (s/n): ");
            string continuar = Console.ReadLine().ToLower();
            switch (continuar)
            {
                case "s":
                    Console.WriteLine("con los mismos nodos o con otros nuevos? (m/n): ");
                    continuar = Console.ReadLine().ToLower();
                    
                        if(continuar == "m") {
                            Console.Clear();
                            break;}
                        else if(continuar == "n") {
                            return;
                            }
                        else {
                            Console.WriteLine("Opción no válida.");
                            return;
                            }

                case "n":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    return;
            }

            
        }
    }
}
