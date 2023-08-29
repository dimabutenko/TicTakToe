namespace TicTakToe.Game;

public class Game: IGame
{
    internal const int Size = 3;
    private readonly IGameService _gameService;
    public bool?[,] Field { get; }

    public Game(IGameService gameService)
    {
        _gameService = gameService;
        Field = new bool?[Size, Size];
    }

    public Result MakeMove(int row, int col, bool value)
    {
        if (row >= Size || col >= Size) return Result.IncorrectMove;

        if (Field[row, col] != null) return Result.IncorrectMove;

        Field[row, col] = value;

        return GetMoveResult(row, col, value);
    }

    private Result GetMoveResult(int row, int col, bool value)
    {
        if (_gameService.CheckForWinner(Field, row, col))
        {
            return value ? Result.WinnerCrosses : Result.WinnerZeros;
        }

        return Field.Cast<bool?>().Any(item => item == null) ? Result.CorrectMove : Result.Draw;
    }
}