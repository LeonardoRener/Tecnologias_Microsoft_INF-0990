public class JewelCollector {

  public static void Main() {

      Robot robot = new Robot(new Coordinate(0,0));
      Map map = createMap(robot);
      robot.setMap(map);
  
      bool running = true;
  
      do {
        map.PrintMap();
        robot.PrintState();

        Console.WriteLine("Enter the command: ");
        string? command = Console.ReadLine();

        if (command != null)
        {
            if (command.Equals("quit")) {
                running = false;
            } else if (command.Equals("w")) {
                robot.Move(Direction.North);
            } else if (command.Equals("a")) {
                robot.Move(Direction.West);
            } else if (command.Equals("s")) {
                robot.Move(Direction.South);
            } else if (command.Equals("d")) {
                robot.Move(Direction.East);
            } else if (command.Equals("g")) {
                robot.Collect();
            }
        }

      } while (running);
  }

  private static Map createMap(Robot robot)
  {
    Map map = new Map(10, 10, robot);
    map.AddItem(new Jawel(new Coordinate(1, 9), JawelType.Red));
    map.AddItem(new Jawel(new Coordinate(8, 8), JawelType.Red));
    map.AddItem(new Jawel(new Coordinate(9, 1), JawelType.Green));
    map.AddItem(new Jawel(new Coordinate(7, 6), JawelType.Green));
    map.AddItem(new Jawel(new Coordinate(3, 4), JawelType.Blue));
    map.AddItem(new Jawel(new Coordinate(2, 1), JawelType.Blue));

    return map;
  }
}