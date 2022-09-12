namespace Game.Jawels;

using Utility;

/// <summary>
/// Classe para as joias do tipo Red.
/// </summary>
public class JawelRed : Jawel
{
    /// <summary>
    /// O construtor recebe a coordenada da joia e cria uma joia com simbolo "JR" e com valor de 100 pontos.
    /// </summary>
    /// <param name="coordinate">Coordenada da joia.</param>
    public JawelRed(Coordinate coordinate) : base(coordinate, "JR", 100)
    {
        
    }
}
