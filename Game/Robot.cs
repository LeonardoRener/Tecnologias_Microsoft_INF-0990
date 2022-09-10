public class Robot : Item
{
    private Coordinate coordinate;
    private String stringMap;
    private List<Jawel> bag;
    private Map? map;
    private String commandException;

    public Robot(Coordinate coordinate, Keyboard keyboard)
    {
        // Inicializa variaveis privadas.
        this.coordinate = coordinate;
        this.stringMap = "ME";
        this.bag = new List<Jawel>();
        this.commandException = String.Empty;

        // Inscrição em eventos.
        keyboard.keyMovePress += Move;
        keyboard.keyCollectPress += Collect;
    }

    public void setMap(Map map)
    {
        this.map = map;
    }

    public void setCoordinate(Coordinate newCoordinate)
    {
        this.coordinate = newCoordinate;
    }

    public void Move(object? sender, KeyMoveArgs args)
    {
        Coordinate newCoordinate;

        switch (args.direction)
        {
            case Direction.North:
                newCoordinate = new Coordinate(coordinate.getX()-1,coordinate.getY());
                break;
            case Direction.South:
                newCoordinate = new Coordinate(coordinate.getX()+1,coordinate.getY());
                break;
            case Direction.East:
                newCoordinate = new Coordinate(coordinate.getX(),coordinate.getY()+1);
                break;
            case Direction.West:
            default:
                newCoordinate = new Coordinate(coordinate.getX(),coordinate.getY()-1);
                break;
        }
        
        try
        {
            map?.UpdateRobotPosition(newCoordinate);
            commandException = String.Empty;
        } catch (Exception ex)
        {
            commandException = ex.ToString();
        }
        
        map?.PrintMap();
        PrintState();
    }

    public void Collect(object? sender, EventArgs e)
    {
        List<Jawel>? collected = map?.CollectJawel();

        if(collected != null && collected.Count > 0)
            this.bag.AddRange(collected);
        
        map?.PrintMap();
        PrintState();
    }

    public void PrintState()
    {
        int value = 0;
        foreach (Jawel jawel in bag) {
            value += jawel.getValue();
        }

        if (!String.IsNullOrEmpty(this.commandException))
            System.Console.WriteLine("Command output: {0}", this.commandException);

        System.Console.WriteLine("Bag total items: {0} | Bag total value: {1}", bag.Count, value);
    }

    public String getStringMap()
    {
        return this.stringMap;
    }

    public Coordinate GetCoordinate()
    {
        return this.coordinate;
    }
}