using Game.Utility;

namespace Game.Jawels
{
    /// <summary>
    /// Classe responsável por representar joias do tipo Blue.
    /// </summary>
    public class JawelBlue : Jawel, IRecharger
    {
        /// <summary>
        /// Pontos de energia fornecidos ao ser consumida.
        /// </summary>
        /// <value>5</value>
        public int Energy { get; private set; }

        /// <summary>
        /// O construtor recebe a coordenada da joia e cria uma joia com simbolo "JB" e com valor de 10 pontos.
        /// A joia fornece 5 pontos de energia ao ser consumida.
        /// </summary>
        /// <param name="coordinate">Coordenada da joia.</param>
        public JawelBlue(Coordinate coordinate) : base(coordinate, "JB", 10)
        {
            this.Energy = 5;
        }
    }
}