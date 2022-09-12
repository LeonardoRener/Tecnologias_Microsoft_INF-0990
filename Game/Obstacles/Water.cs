namespace Game.Obstacles;

using Utility;

/// <summary>
/// Classe para os obstaculo do tipo Water (Agua).
/// </summary>
public class Water : Obstacle
{
    /// <summary>
    /// O construtor recebe a coordenada do obstaculo e cria um obstaculo com simbolo "##".
    /// </summary>
    /// <param name="coordinate">Coordenada do obstaculo.</param>
    public Water(Coordinate coordinate) : base(coordinate, "##")
    {
        
    }
}
