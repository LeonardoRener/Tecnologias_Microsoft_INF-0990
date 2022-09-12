using Game.Utility;

namespace Game.Obstacles
{
    /// <summary>
    /// Classe responsável por representar obstaculos do tipo Arvore.
    /// </summary>
    public class Tree : Obstacle, IRecharger
    {
        /// <summary>
        /// Pontos de energia fornecidos ao ser consumida.
        /// </summary>
        /// <value>Retorna 3 na primeira vez e 0 nas chamadas posteriores.</value>
        public int Energy 
        {
            get
            {
                int value = energy;
                energy = 0;
                return value;
            }
            private set
            {
                energy = value;
            }
        }

        // Atributos privados
        private int energy;

        /// <summary>
        /// O construtor recebe a coordenada do obstaculo e cria um obstaculo com simbolo "$$".
        /// A arvore fornece 3 pontos de energia ao ser consumida.
        /// </summary>
        /// <param name="coordinate">Coordenada da arvore.</param>
        public Tree(Coordinate coordinate) : base(coordinate, "$$")
        {
            this.Energy = 3;
        }
    }
}