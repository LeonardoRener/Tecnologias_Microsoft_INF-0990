namespace Game.Utility
{
  /// <summary>
  /// Interface de objetos que podem estar no mapa (Jawel, Obstacle e Robot).
  /// </summary>
  public interface IMapComponent
  {
    /// <summary>
    /// Coordenada do objeto no mapa.
    /// </summary>
    /// <value>Coordenada do objeto.</value>
    Coordinate Coordinate { get; }
  }
}