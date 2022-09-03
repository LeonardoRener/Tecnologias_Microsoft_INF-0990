public class Robot : Item
{
    private Coordinate coordinate;
    private String stringMap;
    private List<Jawel> bag;
    private Map? map;

    public Robot(Coordinate coordinate)
    {
        this.coordinate = coordinate;
        this.stringMap = "ME";
        bag = new List<Jawel>();
    }

    public void setMap(Map map)
    {
        this.map = map;
    }

    public void setCoordinate(Coordinate newCoordinate)
    {
        this.coordinate = newCoordinate;
    }

    public void Move(Direction direction)
    {
        Coordinate newCoordinate;

        switch (direction)
        {
            case Direction.North:
                newCoordinate = new Coordinate(coordinate.getX(),coordinate.getY()+1);
                break;
            case Direction.South:
                newCoordinate = new Coordinate(coordinate.getX(),coordinate.getY()-1);
                break;
            case Direction.East:
                newCoordinate = new Coordinate(coordinate.getX()+1,coordinate.getY());
                break;
            case Direction.West:
            default:
                newCoordinate = new Coordinate(coordinate.getX()-1,coordinate.getY());
                break;
        }
        
        map?.UpdatePlayerPosition(newCoordinate);
    }

    public void Collect()
    {
        List<Jawel>? collected = map?.CollectJawel(this.coordinate);

        if(collected != null && collected.Count > 0)
            this.bag.AddRange(collected);
    }

    public void PrintState()
    {

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