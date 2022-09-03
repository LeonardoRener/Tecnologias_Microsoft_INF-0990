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
        Coordinate newCoordinate = new Coordinate(1,1);
        map?.UpdatePlayerPosition(newCoordinate);
    }

    public void Collect()
    {

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