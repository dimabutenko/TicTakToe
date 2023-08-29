namespace TicTakToe.Game;

public interface IGame
{
    bool?[,]? Field { get; }
    Result MakeMove(int row, int col, bool value);
}