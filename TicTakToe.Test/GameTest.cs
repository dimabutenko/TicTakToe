using TicTakToe.Game;

namespace TicTakToe.Test;

public class GameTest
{
    [Theory]
    [InlineData(3)]
    [InlineData(8)]
    public void StartNewGame_WithCorrectValues_CreatesMatrix(int size)
    {
        var game = new Game.Game(size);

        Assert.NotNull(game.GetField());
    }

    [Theory]
    [InlineData(2)]
    [InlineData(0)]
    public void StartNewGame_WithIncorrectValues_ThrowsException(int size)
    {
        Assert.Throws<ArgumentException>(() => new Game.Game(size));
    }

    [Theory]
    [InlineData(5, 4, 1, true)]
    [InlineData(8, 7, 1, false)]
    public void MakeMove_WhenEmptyField_SetsValue(int size, int row, int col, bool value)
    {
        var game = new Game.Game(size);

        var result = game.MakeMove(row, col, value);

        Assert.Equal(GameResult.CorrectMove, result);
        Assert.Equal(value, game.GetField()?[row, col]);
    }

    [Theory]
    [InlineData(5, 4, 1, true, false)]
    [InlineData(8, 7, 1, false, true)]
    public void MakeMove_WhenNotEmptyField_NotSetsValue(int size, int row, int col, bool value, bool newValue)
    {
        var game = new Game.Game(size);
        game.MakeMove(row, col, value);

        var result = game.MakeMove(row, col, newValue);

        Assert.Equal(GameResult.IncorrectMove, result);
        Assert.Equal(value, game.GetField()?[row, col]);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void MakeMove_WhenNoFreeFieldsLeft_EndsWithDraw(bool value)
    {
        var game = new Game.Game(3);
        game.MakeMove(0, 0, true);
        game.MakeMove(0, 1, true);
        game.MakeMove(0, 2, false);
        game.MakeMove(1, 0, false);
        game.MakeMove(1, 1, false);
        game.MakeMove(1, 2, true);
        game.MakeMove(2, 0, true);
        game.MakeMove(2, 1, false);

        var result = game.MakeMove(2, 2, value);

        Assert.Equal(GameResult.Draw, result);
    }
}