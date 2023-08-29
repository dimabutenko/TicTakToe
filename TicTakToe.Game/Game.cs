namespace TicTakToe.Game;

public class Game
{
    private const int Size = 3;
    public bool?[,] Field { get; }

    public Game()
    {
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
        if (CheckRow(row) || CheckColumn(col) || CheckPrimaryDiagonal(row, col) || CheckSecondaryDiagonal(row, col))
        {
            return value ? Result.WinnerCrosses : Result.WinnerZeros;
        }

        return Field.Cast<bool?>().Any(item => item == null) ? Result.CorrectMove : Result.Draw;
    }

    private bool CheckRow(int row)
    {
        var value = Field[row, 0];
        
        for (var i = 1; i < Size; i++)
        {
            if (Field[row, i] != value)
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckColumn(int column)
    {
        var value = Field[0, column];
        for (var i = 1; i < Size; i++)
        {
            if (Field[i, column] != value)
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckPrimaryDiagonal(int row, int column)
    {
        if (row != column) return false;
        
        var value = Field[0, 0];
        for (var i = 1; i < Size; i++)
        {
            if (Field[i, i] != value)
            {
                return false;
            }
        }

        return true;
    }
    
    private bool CheckSecondaryDiagonal(int row, int column)
    {
        if (row + column != Size - 1) return false;
        
        var value = Field[0, Size - 1];
        for (var i = 1; i < Size; i++)
        {
            if (Field[i, Size - i - 1] != value)
            {
                return false;
            }
        }

        return true;
    }
}