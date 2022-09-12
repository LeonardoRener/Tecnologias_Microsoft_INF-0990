namespace Game;

using Utility;
using Jawels;

public class Robot : IMapComponent
{
    /// <summary>
    /// Coordenada do robo no mapa.
    /// </summary>
    /// <value>Coordenada (x, y)</value>
    public Coordinate Coordinate { get; private set; }

    // Atributos privados
    private List<Jawel> bag;
    private Map? map;
    private int energy;
    private String commandException;

    // Constantes
    private const String SYMBOL_ON_MAP = "ME";

    /// <summary>
    /// Energia minima que o robo deve ter para conseguir se mover.
    /// </summary>
    public const int MIN_ENERGY = 1;

    /// <summary>
    /// Custo de energia para o robo se mover 1 posição.
    /// </summary>
    public const int ENERGY_TO_MOVE = -1;

    /// <summary>
    /// Evento que informa quando o robo esta sem energia.
    /// </summary>
    public event EventHandler? NoEnergy;

    protected virtual void OnNoEnergy(EventArgs e)
    {
        NoEnergy?.Invoke(this, e);
    }

    /// <summary>
    /// Construtor da classe Robot, cria um novo robo na coordenada recebida.
    /// Realiza inscrições em eventos do teclado para mover e coletar itens.
    /// </summary>
    /// <param name="coordinate">Coordenada inicial do robo.</param>
    /// <param name="keyboard">Classe que controla entradas do teclado.</param>
    public Robot(Coordinate coordinate, Keyboard keyboard)
    {
        // Inicializa variaveis privadas.
        this.Coordinate = coordinate;
        this.bag = new List<Jawel>();
        this.energy = 5;
        this.commandException = String.Empty;

        // Inscrição em eventos.
        keyboard.keyMovePress += Move;
        keyboard.keyCollectPress += CollectAndRecharge;
    }

    /// <summary>
    /// Metodo para atribuir um novo mapa para o robo.
    /// </summary>
    /// <param name="map">Mapa</param>
    public void setMap(Map map)
    {
        this.map = map;
    }

    /// <summary>
    /// Metodo para mover o robo no mapa.
    /// </summary>
    private void Move(object? sender, KeyMoveArgs args)
    {
        Coordinate newCoordinate;
        int energyCost = 0;

        switch (args.direction)
        {
            case Direction.North:
                newCoordinate = new Coordinate(Coordinate.X-1,Coordinate.Y);
                break;
            case Direction.South:
                newCoordinate = new Coordinate(Coordinate.X+1,Coordinate.Y);
                break;
            case Direction.East:
                newCoordinate = new Coordinate(Coordinate.X,Coordinate.Y+1);
                break;
            case Direction.West:
            default:
                newCoordinate = new Coordinate(Coordinate.X,Coordinate.Y-1);
                break;
        }
        
        if (energy >= MIN_ENERGY && map != null)
        {
            try
            {
                energyCost = map.UpdateRobotPosition(newCoordinate);
                this.Coordinate = newCoordinate;
                this.energy += energyCost;
                commandException = String.Empty;
            } catch (Exception ex)
            {
                commandException = ex.Message;
            }
            finally
            {
                map.PrintMap();
                PrintState();

                if (energy < MIN_ENERGY)
                    OnNoEnergy(EventArgs.Empty);
            }
            
        }
        
    }

    /// <summary>
    /// Metodo para coletar joias e/ou itens de recarga de energia.
    /// Para isso o robo deve estar em posições adjacentes a estes itens.
    /// </summary>
    private void CollectAndRecharge(object? sender, EventArgs e)
    {
        if (map != null)
        {
            this.energy += map.CollectEnergy();
            List<Jawel> collected = map.CollectJawel();

            if(collected.Count > 0)
                this.bag.AddRange(collected);

            map.PrintMap();
            PrintState();
        }
    }

    /// <summary>
    /// Metodo para imprimir no console o estado atual do robo.
    /// É exibida a quantidade de energia, total de itens na sacola e valor total dos itens na sacola.
    /// </summary>
    public void PrintState()
    {
        int value = 0;
        foreach (Jawel jawel in bag) {
            value += jawel.Value;
        }

        if (!String.IsNullOrEmpty(this.commandException))
            System.Console.WriteLine("Command output: {0}", this.commandException);

        System.Console.WriteLine("Energy = {0} | Bag total items: {1} | Bag total value: {2}\n", energy, bag.Count, value);
    }

    /// <summary>
    /// Metodo para impressão no console.
    /// </summary>
    /// <returns>Retorna o simbolo do robo, em formato string.</returns>
    public override string ToString()
    {
        return SYMBOL_ON_MAP;
    }
}