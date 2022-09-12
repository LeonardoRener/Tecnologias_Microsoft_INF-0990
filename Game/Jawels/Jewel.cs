namespace Game.Jawels;

using Utility;

/// <summary>
/// Classe abstrata para as joias presentes no mapa.
/// </summary>
public abstract class Jawel : IMapComponent
{
    /// <summary>
    /// Coordenada da joia no mapa.
    /// </summary>
    /// <value>Coordenada (x, y)</value>
    public Coordinate Coordinate { get; private set; }

    /// <summary>
    /// Pontos fornecidos ao coletar a joia.
    /// </summary>
    /// <value>Inteiro</value>
    public int Value { get; private set; }

    // Atributos privados
    private string simbol;

    /// <summary>
    /// Construtor base para as joias.
    /// </summary>
    /// <param name="coordinate">Coordenada da joia.</param>
    /// <param name="simbol">Simbolo para impressão no mapa.</param>
    /// <param name="value">Pontos ao ser coletada pelo robo.</param>
    public Jawel(Coordinate coordinate, string simbol, int value)
    {
        this.Coordinate = coordinate;
        this.simbol = simbol;
        this.Value = value;
    }

    /// <summary>
    /// Metodo para impressão no console.
    /// </summary>
    /// <returns>Retorna o simbolo da joia, em formato string.</returns>
    public override string ToString()
    {
        return simbol;
    }
}