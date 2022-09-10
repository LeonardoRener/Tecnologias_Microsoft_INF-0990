public class Keyboard
{
    /// <summary>
    /// Evento para o preciosamento das teclas w, a, s, d.
    /// </summary>
    public event EventHandler<KeyMoveArgs> keyMovePress;

    /// <summary>
    /// Evento para o precionamento da tecla g.
    /// </summary>
    public event EventHandler keyCollectPress;

    protected virtual void OnKeyMovePress(KeyMoveArgs e)
    {
        EventHandler<KeyMoveArgs> handler = keyMovePress;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    protected virtual void OnKeyCollectPress(EventArgs e)
    {
        EventHandler handler = keyCollectPress;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    public void Game()
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
    }
}

public class KeyMoveArgs : EventArgs
{
    public Direction direction { get; set; }
    public KeyMoveArgs(Direction direction)
    {
        this.direction = direction;
    }
}
