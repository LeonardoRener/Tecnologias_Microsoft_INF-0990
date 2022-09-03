public class JewelCollector {

  public static void Main() {

      Robot robot = new Robot(new Coordinate(0,0));
      Map map = createMap(robot);
      robot.setMap(map);
  
      bool running = true;
  
      do {
  
          Console.WriteLine("Enter the command: ");
          string command = Console.ReadLine();
  
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

          map.PrintMap();
          robot.PrintState();

      } while (running);
  }

  private static Map createMap(Robot robot)
  {
    Map map = new Map(10, 10, robot);
    map.AddItem(new Jawel(new Coordinate(1, 9), JawelType.Red));

    return map;
  }
}