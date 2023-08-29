namespace TicTakToe.Game;

public interface IGameService
{
    bool CheckForWinner(bool?[,] field, int row, int column);
}