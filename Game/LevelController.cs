namespace Game
{
    /// <summary>
    /// Classe responsável por controlar os niveis (fases) do jogo.
    /// </summary>
    public class LevelController
    {
        private Map? map;
        private Robot robot;
        private Keyboard keyboard;
        private int startLevel;
        private int currentLevel;
        private bool isActiveGame;

        /// <summary>
        /// Constutor do controlador de niveis.
        /// </summary>
        /// <param name="startLevel">Nivel (fase) inicial do jogo.</param>
        /// <param name="robot">Robo que participara dos niveis do jogo.</param>
        /// <param name="keyboard">Controle das entradas do teclado.</param>
        public LevelController(int startLevel, Robot robot, Keyboard keyboard)
        {
            this.startLevel = startLevel;
            this.currentLevel = startLevel;
            this.isActiveGame = false;

            this.robot = robot;
            this.keyboard = keyboard;

            this.robot.NoEnergy += GameOver;
            this.keyboard.keyEndGamePress += ClosedGame;
        }

        /// <summary>
        /// Inicia um novo jogo começando no nivel inicial.
        /// </summary>
        public void Start()
        {
            CreateLevel(this.startLevel);

            if (!isActiveGame)
            {
                this.keyboard.Start();
                this.isActiveGame = true;
            }
        }

        private void ClosedGame(object? sender, EventArgs e)
        {
            this.isActiveGame = false;

            System.Console.WriteLine("{0}\n\tClosed Game.\n{0}", InfoDelimiter(this.currentLevel), this.currentLevel+1);
            
            Environment.Exit(0);
        }

        private void GameOver(object? sender, EventArgs e)
        {
            this.isActiveGame = false;

            System.Console.WriteLine("{0}\n\tGame Over!\n{0}", InfoDelimiter(this.currentLevel), this.currentLevel+1);
            
            Environment.Exit(0);
        }

        private void NextLevel(object? sender, EventArgs e)
        {
            System.Console.WriteLine("{0}\n\tLevel {1} complete!\n{0}\n", InfoDelimiter(this.currentLevel), this.currentLevel+1);

            this.currentLevel += 1;
            CreateLevel(this.currentLevel);
        }

        private void CreateLevel(int level)
        {
            this.map = MapFactory.CreateMap(level, this.robot);
            this.robot.setMap(map);

            this.map.AllJawelCollected += NextLevel;

            System.Console.WriteLine("{0}\n\tStarting level {1}\n{0}\n", InfoDelimiter(level), level+1);
            map.PrintMap();
            robot.PrintState();
        }

        private string InfoDelimiter(int level)
        {
            return new String('=', ((10+level)*3)-1);
        }
    }
}