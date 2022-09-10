public class Robot : Item
{
    private Coordinate coordinate;
    private String stringMap;
    private List<Jawel> bag;
    private Map? map;

    public Robot(Coordinate coordinate, Keyboard keyboard)
    {
        this.coordinate = coordinate;
        this.stringMap = "ME";
        bag = new List<Jawel>();
        keyboard.keyMovePress += Move;
    }

    public void setMap(Map map)
    {
        this.map = map;
    }

    public void setCoordinate(Coordinate newCoordinate)
    {
        this.coordinate = newCoordinate;
    }

    public void Move(object sender, KeyMoveArgs e)
    {
        Coordinate newCoordinate;

        System.Console.WriteLine("Chamou o Move - {0}\n", e.direction);

        switch (e.direction)
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
        
        map?.UpdatePlayerPosition(newCoordinate);
        map?.PrintMap();
        PrintState();
    }

    public void Collect()
    {
        List<Jawel>? collected = map?.CollectJawel();

        if(collected != null && collected.Count > 0)
            this.bag.AddRange(collected);
    }

    public void PrintState()
    {
        int value = 0;
        foreach (Jawel jawel in bag) {
            value += jawel.getValue();
        }

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