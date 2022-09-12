using Game.Utility;

namespace Game.Obstacles
{
    /// <summary>
    /// Classe responsável por representar obstaculos do tipo Água.
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
}
