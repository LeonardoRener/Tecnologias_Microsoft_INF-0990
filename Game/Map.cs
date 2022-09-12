using Game.Utility;
using Game.Jawels;
using Game.Obstacles;

namespace Game
{
    /// <summary>
    /// Classe responsável por armazenar as informações do mapa 2D e implementar métodos para adição e remoção de joias e obstáculos
    /// </summary>
    public class Map
    {
        private int sizeX;
        private int sizeY;
        private Robot robot;
        private IMapComponent?[,] items;
        private int jawelAmount;

        /// <summary>
        /// Evento que informa quando todas as joias do mapa foram coletadas.
        /// </summary>
        public event EventHandler? AllJawelCollected;

        protected virtual void OnAllJawelCollected(EventArgs e)
        {
            AllJawelCollected?.Invoke(this, e);
        }

        /// <summary>
        /// Construtor da classe, cria a formação inicial do mapa.
        /// </summary>
        /// <param name="sizeX">Dimensão x do mapa</param>
        /// <param name="sizeY">Dimensão y do mapa</param>
        /// <param name="robot"></param>
        public Map(int sizeX, int sizeY, Robot robot)
        {
            this.items = new IMapComponent[sizeX,sizeY];
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.jawelAmount = 0;
            this.items[robot.Coordinate.X,robot.Coordinate.Y] = robot;
            this.robot = robot;
        }

        /// <summary>
        /// Imprime o mapa no console.
        /// </summary>
        public void PrintMap()
        {
            for(int i = 0; i < this.sizeX; i++)
            {
                for(int j = 0; j < this.sizeY; j++)
                {
                    if (items[i,j] != null)
                        System.Console.Write("{0} ", items[i,j]);
                    else
                        System.Console.Write("-- ");
                }
                System.Console.Write("\n");
            }
        }

        /// <summary>
        /// Adiciona um item no mapa.
        /// </summary>
        /// <param name="item">Item que sera inserido.</param>
        public void AddItem(IMapComponent item)
        {
            this.items[item.Coordinate.X, item.Coordinate.Y] = item;  

            if (item is Jawel)
                this.jawelAmount += 1;
        }

        /// <summary>
        /// Remove um item no mapa.
        /// </summary>
        /// <param name="item">Item que sera removido.</param>
        private void RemoveItem(IMapComponent? item)
        {
            if (item != null)
            {
                this.items[item.Coordinate.X, item.Coordinate.Y] = null;

                if (item is Jawel)
                {
                    this.jawelAmount -= 1;
                    if (this.jawelAmount == 0)
                        OnAllJawelCollected(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Metodo que atualiza a posição do robo no mapa e retorna o custo de energia do movimento.
        /// Retorna uma exceção caso a nova posição não seja valida ou exista um objeto intransponíveis estaja na nova posição. 
        /// </summary>
        /// <param name="newCoordinate">Nova coordenada do robo.</param>
        /// <returns>Custo de energia do movimento.</returns>
        public int UpdateRobotPosition(Coordinate newCoordinate)
        {
            int new_x = newCoordinate.X;
            int new_y = newCoordinate.Y;
            int energyCost;

            if (!IsValidPosition(new_x, new_y))
            {
                throw new Exception("Posição invalida");
            }
            else if (this.items[new_x,new_y] != null || this.items[new_x,new_y] !is Radiation)
            {
                throw new Exception("Não é possivel ir para essa posição");
            }
            else
            {
                this.items[robot.Coordinate.X,robot.Coordinate.Y] = null;
                this.items[new_x,new_y] = this.robot;
                
                energyCost = EnergyCostMove(newCoordinate);
            }

            return energyCost;
        }

        /// <summary>
        /// Metodo que coleta joias que estão em posição adjacente a posição do robo.
        /// </summary>
        /// <returns>Lista de joias.</returns>
        public List<Jawel> CollectJawel()
        {
            List<Jawel> collected = new List<Jawel>();
            int x = robot.Coordinate.X;
            int y = robot.Coordinate.Y;

            if (IsValidPosition(x-1, y) && items[x-1,y] is Jawel jawel1)
            {
                collected.Add(jawel1);
                RemoveItem(items[x-1,y]);
            }
            if (IsValidPosition(x, y-1) && items[x,y-1] is Jawel jawel2)
            {
                collected.Add(jawel2);
                RemoveItem(items[x,y-1]);
            }
            if (IsValidPosition(x+1, y) && items[x+1,y] is Jawel jawel3)
            {
                collected.Add(jawel3);
                RemoveItem(items[x+1,y]);
            }
            if (IsValidPosition(x, y+1) && items[x,y+1] is Jawel jawel4)
            {
                collected.Add(jawel4);
                RemoveItem(items[x,y+1]);
            }

            return collected;
        }

        /// <summary>
        /// Metodo que coleta energias que estão em posição adjacente a posição do robo.
        /// </summary>
        /// <returns>Quantidade de energia coletada.</returns>
        public int CollectEnergy()
        {
            int energy = 0;
            int x = robot.Coordinate.X;
            int y = robot.Coordinate.Y;

            if (IsValidPosition(x-1, y) && items[x-1,y] is IRecharger recharger1)
                energy += recharger1.Energy;

            if (IsValidPosition(x, y-1) && items[x,y-1] is IRecharger recharger2)
                energy += recharger2.Energy;

            if (IsValidPosition(x+1, y) && items[x+1,y] is IRecharger recharger3)
                energy += recharger3.Energy;

            if (IsValidPosition(x, y+1) && items[x,y+1] is IRecharger recharger4)
                energy += recharger4.Energy;

            return energy;
        }

        private bool IsValidPosition(int x, int y)
        {
            return (x >= 0 && x < sizeX) && (y >= 0 && y < sizeY);
        }

        private int EnergyCostMove(Coordinate coordinate)
        {
            int x = coordinate.X;
            int y = coordinate.Y;
            int result = Robot.ENERGY_TO_MOVE;

            if (this.items[x,y] is Radiation radiation)
                result += radiation.DirectRation;
            
            if (IsValidPosition(x-1, y) && items[x-1,y] is Radiation radiation1)
                result += radiation1.AdjacentRation;

            if (IsValidPosition(x, y-1) && items[x,y-1] is Radiation radiation2)
                result += radiation2.AdjacentRation;

            if (IsValidPosition(x+1, y) && items[x+1,y] is Radiation radiation3)
                result += radiation3.AdjacentRation;

            if (IsValidPosition(x, y+1) && items[x,y+1] is Radiation radiation4)
                result += radiation4.AdjacentRation;

            return result;
        }
    }
}