using System;
using System.Collections.Generic;
using System.Linq;

public class Vertice
{
    public Nodo Destino { get; set; }
    public int Costo { get; set; }

    public Vertice(Nodo destino, int costo)
    {
        Destino = destino;
        Costo = costo;
    }
}

public class Nodo
{
    public string Nombre { get; set; }
    public List<Vertice> Vertices { get; set; }

    public Nodo(string nombre)
    {
        Nombre = nombre;
        Vertices = new List<Vertice>();
    }

    public void AgregarVertice(Nodo destino, int costo)
    {
        Vertices.Add(new Vertice(destino, costo));
    }
}

public class Grafo
{
    public Dictionary<string, Nodo> Nodos { get; set; }
    public string Unidad { get; set; }

    public Grafo()
    {
        Nodos = new Dictionary<string, Nodo>();
        Unidad = "unidad"; // Unidad predeterminada
    }

    public void AgregarNodo(string nombre)
    {
        if (!Nodos.ContainsKey(nombre))
        {
            Nodos[nombre] = new Nodo(nombre);
        }
    }

    public void AgregarArista(string origen, string destino, int costo)
    {
        AgregarNodo(origen);
        AgregarNodo(destino);

        Nodo nodoOrigen = Nodos[origen];
        Nodo nodoDestino = Nodos[destino];

        nodoOrigen.AgregarVertice(nodoDestino, costo);
        nodoDestino.AgregarVertice(nodoOrigen, costo);
    }

    public List<Tuple<List<string>, int>> EncontrarTodosCaminos(string inicio, string fin)
    {
        List<Tuple<List<string>, int>> caminos = new List<Tuple<List<string>, int>>();

        if (!Nodos.ContainsKey(inicio) || !Nodos.ContainsKey(fin))
        {
            Console.WriteLine("Uno o ambos nodos no existen en el grafo.");
            return caminos;
        }

        Nodo nodoInicio = Nodos[inicio];
        Nodo nodoFin = Nodos[fin];

        List<Nodo> visitados = new List<Nodo>();
        List<string> caminoActual = new List<string>();
        int costoActual = 0;

        DFS(nodoInicio, nodoFin, visitados, caminoActual, costoActual, caminos);

        return caminos;
    }

    private void DFS(Nodo actual, Nodo destino, List<Nodo> visitados, List<string> caminoActual, int costoActual, List<Tuple<List<string>, int>> caminos)
    {
        visitados.Add(actual);
        caminoActual.Add(actual.Nombre);

        if (actual == destino)
        {
            caminos.Add(new Tuple<List<string>, int>(new List<string>(caminoActual), costoActual));
        }
        else
        {
            foreach (Vertice vertice in actual.Vertices)
            {
                if (!visitados.Contains(vertice.Destino))
                {
                    DFS(vertice.Destino, destino, visitados, caminoActual, costoActual + vertice.Costo, caminos);
                }
            }
        }

        visitados.Remove(actual);
        caminoActual.RemoveAt(caminoActual.Count - 1);
    }

    public void MostrarCaminos(string inicio, string fin)
    {
        List<Tuple<List<string>, int>> caminos = EncontrarTodosCaminos(inicio, fin);

        if (caminos.Count == 0)
        {
            Console.WriteLine($"No se encontraron caminos entre {inicio} y {fin}.");
            return;
        }

        Console.WriteLine($"Todos los caminos entre {inicio} y {fin}:");
        foreach (var camino in caminos)
        {
            string representacionCamino = "";

            for (int i = 0; i < camino.Item1.Count - 1; i++)
            {
                string origen = camino.Item1[i];
                string destino = camino.Item1[i + 1];
                Vertice arista = Nodos[origen].Vertices.First(v => v.Destino.Nombre == destino);

                representacionCamino += $"{origen} -({arista.Costo} {Unidad})-> ";
            }
            representacionCamino += camino.Item1.Last();

            Console.WriteLine($"Camino: {representacionCamino}, Costo total: {camino.Item2} {Unidad}");
        }

        var caminoMasCorto = caminos.MinBy(c => c.Item2);
        Console.WriteLine("\nEl camino más corto:");
        string caminoCorto = "";

        for (int i = 0; i < caminoMasCorto.Item1.Count - 1; i++)
        {
            string origen = caminoMasCorto.Item1[i];
            string destino = caminoMasCorto.Item1[i + 1];
            Vertice arista = Nodos[origen].Vertices.First(v => v.Destino.Nombre == destino);

            caminoCorto += $"{origen} -({arista.Costo} {Unidad})-> ";
        }
        caminoCorto += caminoMasCorto.Item1.Last();

        Console.WriteLine($"Camino: {caminoCorto}, Costo total: {caminoMasCorto.Item2} {Unidad}");
    }
}

