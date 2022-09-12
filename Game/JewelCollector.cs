using Game.Utility;

namespace Game
{
  /// <summary>
  /// Classe responsável por iniciar a execução programa.
  /// </summary>
  public class JewelCollector {

    /// <summary>
    /// Metodo principal, inicia o jogo.
    /// Cria instancias das classes de teclado (Keyboard), robo (Robot) e controle de nivel (LevelController).
    /// </summary>
    public static void Main() {

        Keyboard keyboard = new Keyboard();

        Robot robot = new Robot(new Coordinate(0,0), keyboard);
        LevelController levelController = new LevelController(0, robot, keyboard);

        levelController.Start();
    }

  }
}