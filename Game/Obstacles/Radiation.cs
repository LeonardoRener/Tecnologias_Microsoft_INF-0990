using Game.Utility;

namespace Game.Obstacles
{
    /// <summary>
    /// Classe responsável por representar obstaculos do tipo Radiação.
    /// </summary>
    public class Radiation : Obstacle
    {
        /// <summary>
        /// Diminuição de energia causada ao mover-se em posições adjacentes a esse obstaculo
        /// </summary>
        /// <value>Inteiro com valor da energia drenada.</value>
        public int AdjacentRation { get; private set; }

        /// <summary>
        /// Diminuição de energia causada ao mover-se para a mesma posição que a deste obstaculo
        /// </summary>
        /// <value>Inteiro com valor da energia drenada.</value>
        public int DirectRation { get; private set; }

        /// <summary>
        /// O construtor recebe a coordenada do obstaculo e cria um obstaculo com simbolo "!!" e caracteristicas de radiação.
        /// </summary>
        /// <param name="coordinate">Coordenada do obstaculo.</param>
        public Radiation(Coordinate coordinate) : base(coordinate, "!!")
        {
            AdjacentRation = -5;
            DirectRation = -30;
        }
    }
}