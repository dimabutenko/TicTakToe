using TicTakToe.Game;

namespace TicTakToe.Test;

public class GameServiceFixture
{
    public GameService GameService { get; private set; }

    public GameServiceFixture()
    {
        GameService = new GameService();
    }
}