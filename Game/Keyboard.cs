public class Keyboard
{
    public event EventHandler<KeyMoveArgs> keyMovePress;

    protected virtual void OnKeyMovePress(KeyMoveArgs e)
    {
        EventHandler<KeyMoveArgs> handler = keyMovePress;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    public void Game()
    {
        bool running = true;

        do {
            char? command = Console.ReadKey(true).KeyChar;

            if (command.Equals("quit")) {
                running = false;
            } else if (command.Equals('w')) {
                OnKeyMovePress(new KeyMoveArgs(Direction.North));
            } else if (command.Equals('a')) {
                OnKeyMovePress(new KeyMoveArgs(Direction.West));
            } else if (command.Equals('s')) {
                OnKeyMovePress(new KeyMoveArgs(Direction.South));
            } else if (command.Equals('d')) {
                OnKeyMovePress(new KeyMoveArgs(Direction.East));
            } else if (command.Equals('g')) {
                
            }

        } while (running);
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
