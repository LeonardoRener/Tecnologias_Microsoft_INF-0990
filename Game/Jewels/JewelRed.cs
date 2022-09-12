using Game.Utility;

namespace Game.Jewels
{
    /// <summary>
    /// Classe responsável por representar joias do tipo Red.
    /// </summary>
    public class JewelRed : Jewel
    {
        /// <summary>
        /// O construtor recebe a coordenada da joia e cria uma joia com simbolo "JR" e com valor de 100 pontos.
        /// </summary>
        /// <param name="coordinate">Coordenada da joia.</param>
        public JewelRed(Coordinate coordinate) : base(coordinate, "JR", 100)
        {
            
        }
    }
}