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

    public Grafo()
    {
        Nodos = new Dictionary<string, Nodo>();
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

        HashSet<Nodo> visitados = new HashSet<Nodo>();
        List<string> caminoActual = new List<string> { inicio };
        int costoActual = 0;

        DFS(nodoInicio, nodoFin, visitados, caminoActual, costoActual, caminos);

        return caminos;
    }

    private void DFS(Nodo actual, Nodo destino, HashSet<Nodo> visitados, List<string> caminoActual, int costoActual, List<Tuple<List<string>, int>> caminos)
    {
        if (actual == destino)
        {
            caminos.Add(new Tuple<List<string>, int>(new List<string>(caminoActual), costoActual));
            return;
        }

        visitados.Add(actual);

        foreach (Vertice vertice in actual.Vertices)
        {
            if (!visitados.Contains(vertice.Destino))
            {
                caminoActual.Add(vertice.Destino.Nombre);
                DFS(vertice.Destino, destino, visitados, caminoActual, costoActual + vertice.Costo, caminos);
                caminoActual.RemoveAt(caminoActual.Count - 1);
            }
        }

        visitados.Remove(actual);
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
            Console.WriteLine($"Camino: {string.Join(" -> ", camino.Item1)}, Costo: {camino.Item2}");
        }

        var caminoMasCorto = caminos.MinBy(c => c.Item2);
        Console.WriteLine("\nEl camino más corto:");
        Console.WriteLine($"Camino: {string.Join(" -> ", caminoMasCorto.Item1)}, Costo: {caminoMasCorto.Item2}");
    }
}
