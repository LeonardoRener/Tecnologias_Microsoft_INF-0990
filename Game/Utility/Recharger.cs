namespace Game.Utility;

/// <summary>
/// Interface de objetos que recarregam a energia do robo.
/// </summary>
public interface IRecharger
{
    /// <summary>
    /// Energia fornecida pelo objeto.
    /// </summary>
    /// <value>Energia fornecida.</value>
    int Energy { get; }
}
