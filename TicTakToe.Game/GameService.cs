namespace TicTakToe.Game;

public class GameService : IGameService
{
    public bool CheckForWinner(bool?[,] field, int row, int column)
    {
        return CheckRowForWinner(field, row) || CheckColumnForWinner(field, column) || CheckPrimaryDiagonalForWinner(field ,row, column) ||
               CheckSecondaryDiagonalForWinner(field, row, column);
    }
    
    private static bool CheckRowForWinner(bool?[,] field, int row)
    {
        var value = field[row, 0];

        for (var i = 1; i < Game.Size; i++)
            if (field[row, i] != value)
                return false;

        return true;
    }

    private static bool CheckColumnForWinner(bool?[,] field, int column)
    {
        var value = field[0, column];
        for (var i = 1; i < Game.Size; i++)
            if (field[i, column] != value)
                return false;

        return true;
    }

    private static bool CheckPrimaryDiagonalForWinner(bool?[,] field, int row, int column)
    {
        if (row != column) return false;

        var value = field[0, 0];
        for (var i = 1; i < Game.Size; i++)
            if (field[i, i] != value)
                return false;

        return true;
    }

    private static bool CheckSecondaryDiagonalForWinner(bool?[,] field, int row, int column)
    {
        if (row + column != Game.Size - 1) return false;

        var value = field[0, Game.Size - 1];
        for (var i = 1; i < Game.Size; i++)
            if (field[i, Game.Size - i - 1] != value)
                return false;

        return true;
    }
}