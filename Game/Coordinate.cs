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

    public bool IsAdjacentPosition(Coordinate coordinate)
    {
        bool result = false;

        if (coordinate.Compare(this.pos_x+1, this.pos_y))
            result = true;
        else if (coordinate.Compare(this.pos_x, this.pos_y+1))
            result = true;
        else if (coordinate.Compare(this.pos_x-1, this.pos_y))
            result = true;
        else if (coordinate.Compare(this.pos_x, this.pos_y-1))
            result = true;

        return result;
    }

    private bool Compare(int x, int y)
    {
        return this.pos_x == x && this.pos_y == y;
    }
}