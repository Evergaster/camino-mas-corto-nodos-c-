# Caminocorto

Este proyecto implementa un grafo y permite encontrar todos los caminos posibles entre dos nodos, así como el camino más corto.

## Estructura del Proyecto

- `Program.cs`: Contiene el punto de entrada del programa y la lógica para interactuar con el usuario.
- `funcion.cs`: Define las clases `Vertice`, `Nodo` y `Grafo`, y contiene la lógica para agregar nodos y aristas, y encontrar caminos en el grafo.

## Clases

---

### Vertice

Representa una arista en el grafo.

- **Propiedades:**
  - `Nodo Destino`: Nodo de destino del vértice.
  - `int Costo`: Costo asociado al vértice.

- **Constructor:**
  - `Vertice(Nodo destino, int costo)`: Inicializa un nuevo vértice con el nodo de destino y el costo especificados.



### Nodo

Representa un nodo en el grafo.

- **Propiedades:**
  - `string Nombre`: Nombre del nodo.
  - `List<Vertice> Vertices`: Lista de vértices conectados al nodo.

- **Constructor:**
  - `Nodo(string nombre)`: Inicializa un nuevo nodo con el nombre especificado.

- **Métodos:**
  - `void AgregarVertice(Nodo destino, int costo)`: Agrega un vértice al nodo.

### Grafo

Representa el grafo y contiene la lógica para manipularlo.

- **Propiedades:**
  - `Dictionary<string, Nodo> Nodos`: Diccionario de nodos en el grafo.

- **Constructor:**
  - `Grafo()`: Inicializa un nuevo grafo.

- **Métodos:**
  - `void AgregarNodo(string nombre)`: Agrega un nodo al grafo.
  - `void AgregarArista(string origen, string destino, int costo)`: Agrega una arista entre dos nodos en el grafo.
  - `List<Tuple<List<string>, int>> EncontrarTodosCaminos(string inicio, string fin)`: Encuentra todos los caminos entre dos nodos.
  - `void MostrarCaminos(string inicio, string fin)`: Muestra todos los caminos entre dos nodos y el camino más corto.

---

### Uso

1. Ejecuta el programa.
2. Ingresa la cantidad de nodos y sus nombres.
3. Ingresa la cantidad de aristas y sus detalles (origen, destino, costo).
4. Ingresa el nodo de inicio y el nodo de fin.
5. El programa mostrará todos los caminos posibles entre los nodos especificados y el camino más corto.
6. Puedes elegir continuar ingresando más datos o salir del programa.

---

## Ejemplo
```
1. Nodos y aristas:  
   - Se crean los nodos `A`, `B`, `C` y `D`.
   - Las aristas conectan los nodos con sus costos:  
     - `A -> B (5)`
     - `A -> C (10)`
     - `B -> C (2)`
     - `B -> D (7)`
     - `C -> D (1)`

2. **Caminos posibles entre `A` y `D`:**  
   - **Camino 1:** `A -> B -> D` (Costo: 12)  
   - **Camino 2:** `A -> B -> C -> D` (Costo: 8)  
   - **Camino 3:** `A -> C -> D` (Costo: 11)  

3. **Camino más corto:**  
   - Es el **Camino 2**, con un costo total de **8 kilómetros**.  


```

---

## Cómo Probar

1. Copia el código fuente en un archivo de proyecto de C#.
2. Compila y ejecuta el programa.
3. Introduce los datos del ejemplo o personaliza los datos de nodos y aristas para adaptarlo a tus necesidades.

## Requerimientos

- .NET Framework o .NET Core
- Un editor o IDE como Visual Studio, Visual Studio Code o cualquier editor compatible con C#.

---

¡Disfruta explorando los caminos en tu grafo!