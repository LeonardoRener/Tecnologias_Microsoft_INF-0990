public class Map
{
    private int sizeX;
    private int sizeY;
    private Robot robot;
    private Item?[,] items;

    public Map(int sizeX, int sizeY, Robot robot)
    {
        this.items = new Item[sizeX,sizeY];
        this.sizeX = sizeX;
        this.sizeY = sizeY;
        this.items[robot.GetCoordinate().getX(),robot.GetCoordinate().getY()] = robot;
        this.robot = robot;
    }

    public void PrintMap()
    {
        for(int i = 0; i < this.sizeX; i++)
        {
            for(int j = 0; j < this.sizeY; j++)
            {
                if (items[i,j] != null)
                    System.Console.Write("{0}  ", items[i,j]?.getStringMap());
                else
                    System.Console.Write("--  ");
            }
            System.Console.Write("\n");
        }
    }

    public void AddItem(Item item)
    {
        int x = item.GetCoordinate().getX();
        int y = item.GetCoordinate().getY();
        this.items[x,y] = item;
    }

    public void UpdatePlayerPosition(Coordinate newCoordinate)
    {
        int old_x = robot.GetCoordinate().getX();
        int old_y = robot.GetCoordinate().getY();
        int new_x = newCoordinate.getX();
        int new_y = newCoordinate.getY();

        if ((new_x > 0 && new_x < sizeX) && (new_y > 0 && new_y < sizeY))
        {
            if (this.items[new_x,new_y] == null)
            {
                this.items[new_x,new_y] = this.robot;
                this.items[old_x,old_y] = null;
                robot.setCoordinate(newCoordinate);
            }
        }
    }

    public List<Jawel> CollectJawel(Coordinate coordinate)
    {
        List<Jawel> collected = new List<Jawel>();
        int x = coordinate.getX();
        int y = coordinate.getY();

        if (items[x-1,y] is Jawel jawel1)
        {
            collected.Add(jawel1);
            items[x-1,y] = null;
        }
        if (items[x,y-1] is Jawel jawel2)
        {
            collected.Add(jawel2);
            items[x,y-1] = null;
        }
        if (items[x+1,y] is Jawel jawel3)
        {
            collected.Add(jawel3);
            items[x+1,y] = null;
        }
        if (items[x,y+1] is Jawel jawel4)
        {
            collected.Add(jawel4);
            items[x,y+1] = null;
        }

        return collected;
    }
}