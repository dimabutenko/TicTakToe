namespace TicTakToe.Game;

public class Game
{
    private const int MinSize = 3;
    private readonly int _fieldSize;
    private bool?[,]? Field { get; }

    public Game(int fieldSize)
    {
        if (fieldSize < MinSize)
            throw new ArgumentException($"Incorrect value. Value must be greater or equal than {MinSize}",
                nameof(fieldSize));

        _fieldSize = fieldSize;
        Field = new bool?[_fieldSize, _fieldSize];
    }

    public GameResult MakeMove(int row, int col, bool value)
    {
        if (row >= _fieldSize || col >= _fieldSize) return GameResult.IncorrectMove;

        if (Field?[row, col] != null) return GameResult.IncorrectMove;

        if (Field != null) Field[row, col] = value;

        return GetMoveResult(row, col, value);
    }

    private GameResult GetMoveResult(int row, int col, bool value)
    {
        if (CheckRow(row) || CheckColumn(col) || CheckDiagonal(row, col))
            return value ? GameResult.WinnerCrosses : GameResult.WinnerZeros;

        if (Field != null)
            if (Field.Cast<bool?>().Any(item => item == null))
                return GameResult.CorrectMove;

        return GameResult.Draw;
    }

    public bool?[,]? GetField()
    {
        return Field;
    }

    private bool CheckRow(int row)
    {
        if (Field != null)
        {
            var value = Field[row, 0];
            for (var i = 1; i < _fieldSize; i++)
                if (Field[row, i] != value)
                    return false;
        }

        return true;
    }

    private bool CheckColumn(int column)
    {
        if (Field != null)
        {
            var value = Field[0, column];
            for (var i = 1; i < _fieldSize; i++)
                if (Field[i, column] != value)
                    return false;
        }

        return true;
    }

    private bool CheckDiagonal(int row, int column)
    {
        if (row != column && row + column != _fieldSize - 1) return false;

        if (row == column)
        {
            if (Field != null)
            {
                var value = Field[0, 0];
                for (var i = 1; i < _fieldSize; i++)
                    if (Field[i, i] != value)
                        return false;
            }
        }
        else
        {
            if (Field != null)
            {
                var value = Field[0, _fieldSize - 1];
                for (var i = 1; i < _fieldSize; i++)
                    if (Field[i, _fieldSize - i - 1] != value)
                        return false;
            }
        }

        return true;
    }
}