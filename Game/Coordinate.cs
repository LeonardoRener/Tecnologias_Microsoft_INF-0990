public class Coordinate
{
    private int pos_x;
    private int pos_y;

    public Coordinate(int x, int y)
    {
        this.pos_x = x;
        this.pos_y = y;
    }

    public int getX()
    {
        return this.pos_x;
    }

    public int getY()
    {
        return this.pos_y;
    }

    public override bool Equals(Object? obj)
    {
        if (obj is Coordinate coord)
            if (this.pos_x == coord.getX() && this.pos_y == coord.getY())
                return true;

        return false;
    }

    public override int GetHashCode()
    {
        return (this.pos_x << 2) ^ this.pos_y;
    }
}