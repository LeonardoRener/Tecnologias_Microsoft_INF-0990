public enum ObstacleType: int
{
    Water,
    Tree
}

public class Obstacle : Item
{
    private Coordinate coordinate;
    private ObstacleType type;
    private String stringMap;

    public Obstacle(Coordinate coordinate, ObstacleType type)
    {
        this.coordinate = coordinate;
        this.type = type;

        if (type == ObstacleType.Water)
            this.stringMap = "##";
        else
            this.stringMap = "$$";
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