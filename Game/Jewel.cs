public enum JawelType: int
{
    Red = 100,
    Green = 50,
    Blue = 10
}

public class Jawel : Item
{
    private Coordinate coordinate;
    private JawelType type;
    private String stringMap;

    public Jawel(Coordinate coordinate, JawelType type)
    {
        this.coordinate = coordinate;
        this.type = type;

        if (type == JawelType.Red)
            this.stringMap = "JR";
        else if (type == JawelType.Green)
            this.stringMap = "JG";
        else
            this.stringMap = "JB";
        
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