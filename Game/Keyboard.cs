using Game.Utility;

namespace Game
{
    /// <summary>
    /// Classe responsável por receber e analisar entradas do teclado.
    /// </summary>
    public class Keyboard
    {
        /// <summary>
        /// Evento para o preciosamento das teclas w, a, s, d.
        /// </summary>
        /// <returns>Retorna a direção correspondente a tecla pressionada.</returns>
        public event EventHandler<KeyMoveArgs>? keyMovePress;

        /// <summary>
        /// Evento para o precionamento da tecla g.
        /// </summary>
        public event EventHandler? keyCollectPress;

        /// <summary>
        /// Evento para o precionamento da tecla ESC.
        /// </summary>
        public event EventHandler? keyEndGamePress;

        protected virtual void OnKeyMovePress(KeyMoveArgs e)
        {
            keyMovePress?.Invoke(this, e);
        }

        protected virtual void OnKeyCollectPress(EventArgs e)
        {
            keyCollectPress?.Invoke(this, e);
        }

        protected virtual void OnKeyEndGamePress(EventArgs e)
        {
            keyEndGamePress?.Invoke(this, e);
        }

        /// <summary>
        /// Cria um loop para receber entradas do teclado, invoca eventos em caso do pressionamento de teclas especificas.
        /// O loop termina se a tecla ESC for pressionada.
        /// </summary>
        public void Start()
        {
            ConsoleKeyInfo cki;

            do {
                cki = Console.ReadKey(true);

                switch (cki.Key)
                {
                    case ConsoleKey.W:
                        OnKeyMovePress(new KeyMoveArgs(Direction.North));
                        break;
                    case ConsoleKey.A:
                        OnKeyMovePress(new KeyMoveArgs(Direction.West));
                        break;
                    case ConsoleKey.S:
                        OnKeyMovePress(new KeyMoveArgs(Direction.South));
                        break;
                    case ConsoleKey.D:
                        OnKeyMovePress(new KeyMoveArgs(Direction.East));
                        break;
                    case ConsoleKey.G:
                        OnKeyCollectPress(EventArgs.Empty);
                        break;
                }

            } while (cki.Key != ConsoleKey.Escape);

            OnKeyEndGamePress(EventArgs.Empty);
        }
    }

    /// <summary>
    /// Classe responsável por informar a direção do movimento, usada no evento keyMovePress.
    /// </summary>
    public class KeyMoveArgs : EventArgs
    {
        /// <summary>
        /// Direção do movimento.
        /// </summary>
        /// <value>Direção.</value>
        public Direction Direction { get; set; }

        /// <summary>
        /// Construtor do argumento com direção, cria o argumento com a direção recebida.
        /// </summary>
        /// <param name="direction">Direção do movimento.</param>
        public KeyMoveArgs(Direction direction)
        {
            this.Direction = direction;
        }
    }
}