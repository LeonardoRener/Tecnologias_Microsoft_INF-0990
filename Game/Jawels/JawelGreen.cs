using Game.Utility;

namespace Game.Jawels
{
    /// <summary>
    /// Classe responsável por representar joias do tipo Gree.
    /// </summary>
    public class JawelGreen : Jawel
    {
        /// <summary>
        /// O construtor recebe a coordenada da joia e cria uma joia com simbolo "JG" e com valor de 50 pontos.
        /// </summary>
        /// <param name="coordinate">Coordenada da joia.</param>
        public JawelGreen(Coordinate coordinate) : base(coordinate, "JG", 50)
        {
            
        }
    }
}