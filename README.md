# Caminocorto

Este proyecto implementa un grafo y permite encontrar todos los caminos posibles entre dos nodos, así como el camino más corto.

## Estructura del Proyecto

- `Program.cs`: Contiene el punto de entrada del programa y la lógica para interactuar con el usuario.
- `funcion.cs`: Define las clases `Vertice`, `Nodo` y `Grafo`, y contiene la lógica para agregar nodos y aristas, y encontrar caminos en el grafo.

## Clases

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

## Uso

1. Ejecuta el programa.
2. Ingresa la cantidad de nodos y sus nombres.
3. Ingresa la cantidad de aristas y sus detalles (origen, destino, costo).
4. Ingresa el nodo de inicio y el nodo de fin.
5. El programa mostrará todos los caminos posibles entre los nodos especificados y el camino más corto.
6. Puedes elegir continuar ingresando más datos o salir del programa.

## Ejemplo
```
Ingrese la cantidad de nodos: 3 
Ingrese el nombre del nodo 1: A 
Ingrese el nombre del nodo 2: B 
Ingrese el nombre del nodo 3: C 
Ingrese la cantidad de aristas: 2 
Ingrese la arista 1 (origen destino costo): A B 5 
Ingrese la arista 2 (origen destino costo): B C 3 
Ingrese el nodo de inicio: A 
Ingrese el nodo de fin: C 
Todos los caminos entre A y C: 
Camino: A -> B -> C, Costo: 8
El camino más corto: 
Camino: A -> B -> C, Costo: 8

```

## Requisitos

- .NET 8.0

## Compilación y Ejecución

Para compilar y ejecutar el proyecto, usa los siguientes comandos:

```sh
dotnet build
dotnet run