namespace Game.Obstacles;

using Utility;

/// <summary>
/// Classe abstrata para os obstaculo presentes no mapa.
/// </summary>
public abstract class Obstacle : IMapComponent
{
    /// <summary>
    /// Coordenada do obstaculo no mapa.
    /// </summary>
    /// <value>Coordinate (x, y)</value>
    public Coordinate Coordinate { get; private set; }

    // Atributos privados
    private string simbol;

    /// <summary>
    /// Construtor base para os obstaculo.
    /// </summary>
    /// <param name="coordinate">Coordenada do obstaculo.</param>
    /// <param name="simbol">Simbolo para impressão no mapa.</param>
    public Obstacle(Coordinate coordinate, string simbol)
    {
        this.Coordinate = coordinate;
        this.simbol = simbol;
    }

    /// <summary>
    /// Metodo para impressão no console.
    /// </summary>
    /// <returns>Retorna o simbolo do obstaculo, em formato string.</returns>
    public override string ToString()
    {
        return simbol;
    }
}