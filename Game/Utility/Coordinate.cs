namespace Game.Utility;

/// <summary>
/// Classe que representa coordenadas de objetos no mapa (x, y).
/// </summary>
public class Coordinate
{
    /// <summary>
    /// Posição X da coordenada.
    /// </summary>
    /// <value>Valor da posição x.</value>
    public int X { get; private set; }

    /// <summary>
    /// Posição Y da coordenada.
    /// </summary>
    /// <value>Valor da posição y.</value>
    public int Y { get; private set; }

    /// <summary>
    /// Cria uma nova coordenada na posição (x, y).
    /// </summary>
    /// <param name="x">Coordenada X</param>
    /// <param name="y">Coordenada Y</param>
    public Coordinate(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    /// <summary>
    /// Compara objetos e determina se possuem a mesma coordenada.
    /// </summary>
    /// <param name="obj">Objeto a ser comparado.</param>
    /// <returns>True se for igual e False caso contrario.</returns>
    public override bool Equals(Object? obj)
    {
        if (obj is Coordinate coord)
            if (this.X == coord.X && this.Y == coord.Y)
                return true;

        return false;
    }

    public override int GetHashCode()
    {
        return (this.X << 2) ^ this.Y;
    }

    /// <summary>
    /// Metodo estatico que cria uma lista de coordenadas com as posições de uma mapa de tamanho sizeX por sizeY.
    /// </summary>
    /// <param name="sizeX">Tamanho em x.</param>
    /// <param name="sizeY">Tamanho em y.</param>
    /// <returns>Lista de coordenadas.</returns>
    public static List<Coordinate> CoordinateMap(int sizeX, int sizeY)
    {
        List<Coordinate> coordinates = new List<Coordinate>();

        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                coordinates.Add(new Coordinate(x,y));
            }
        }

        return coordinates;
    }
}

/// <summary>
/// Classe para extensões de tipos Coordinate.
/// </summary>
public static class CoordinateHelper
{
    /// <summary>
    /// Extensão de objetos List<Coordinate>, retorna um elemento aleatorio da lista e exclui esse elemento da lista.
    /// </summary>
    /// <param name="coordinates">Lista de coordenadas.</param>
    /// <param name="random">Gerador de numeros aleatorios.</param>
    /// <returns>Coordenada aleatoria pertencente a lista.</returns>
    public static Coordinate GetNewRandom(this List<Coordinate> coordinates, Random random)
    {
        int index = random.Next(0, coordinates.Count);
        Coordinate result = coordinates[index];
        coordinates.Remove(result);

        return result;
    }
}