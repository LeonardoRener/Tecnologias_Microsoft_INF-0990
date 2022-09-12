namespace Game;

using Utility;
using Jawels;
using Obstacles;

/// <summary>
/// Classe responsavel por criar um novo mapa.
/// </summary>
public static class MapFactory
{
    private const int INITIAL_SIZE_X = 10;
    private const int INITIAL_SIZE_Y = 10;
    private const int INITIAL_AMOUNT_JAWEL_RED = 2;
    private const int INITIAL_AMOUNT_JAWEL_BLUE = 2;
    private const int INITIAL_AMOUNT_JAWEL_GREE = 2;
    private const int INITIAL_AMOUNT_OBSTACLE_WATER = 7;
    private const int INITIAL_AMOUNT_OBSTACLE_TREE = 5;
    private const int INITIAL_AMOUNT_OBSTACLE_RADIATION = 0;
    private static Random random = new Random();

    /// <summary>
    /// Cria um novo mapa com as caracteristicas da fase recebida como parametro.
    /// Adiciona ao mapa as joias e obstaculos de acordo com a fase.
    /// </summary>
    /// <param name="level"></param>
    /// <param name="robot"></param>
    /// <returns>Retorna uma nova instancia de Map</returns>
    public static Map CreateMap(int level, Robot robot)
    {
        int sizeX = level < 20 ? INITIAL_SIZE_X + level : 30;
        int sizeY = level < 20 ? INITIAL_SIZE_Y + level : 30;
        int amountJawelRed = level < 20 ? INITIAL_AMOUNT_JAWEL_RED + level : 22;
        int amountJawelBlue = level < 20 ? INITIAL_AMOUNT_JAWEL_BLUE + level : 22;
        int amountJawelGree = level < 20 ? INITIAL_AMOUNT_JAWEL_GREE + level : 22;
        int amountObstacleWater = level < 20 ? INITIAL_AMOUNT_OBSTACLE_WATER + level : 27;
        int amountObstacleTree = level < 20 ? INITIAL_AMOUNT_OBSTACLE_TREE + level : 25;
        int amountObstacleRadiation = level < 20 ? INITIAL_AMOUNT_OBSTACLE_RADIATION + level : 20;
        List<Coordinate> coordinates = Coordinate.CoordinateMap(sizeX, sizeY);
        Map map = new Map(sizeX, sizeY, robot);

        coordinates.Remove(robot.Coordinate);

        for (int i = 0; i < amountJawelRed; i++)
        {
            map.AddItem(new JawelRed(coordinates.GetNewRandom(random)));
        }
        for (int i = 0; i < amountJawelBlue; i++)
        {
            map.AddItem(new JawelBlue(coordinates.GetNewRandom(random)));
        }
        for (int i = 0; i < amountJawelGree; i++)
        {
            map.AddItem(new JawelGreen(coordinates.GetNewRandom(random)));
        }

        for (int i = 0; i < amountObstacleWater; i++)
        {
            map.AddItem(new Water(coordinates.GetNewRandom(random)));
        }
        for (int i = 0; i < amountObstacleTree; i++)
        {
            map.AddItem(new Tree(coordinates.GetNewRandom(random)));
        }
        for (int i = 0; i < amountObstacleRadiation; i++)
        {
            map.AddItem(new Radiation(coordinates.GetNewRandom(random)));
        }

        return map;
    }


}
