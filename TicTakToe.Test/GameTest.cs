using TicTakToe.Game;

namespace TicTakToe.Test;

public class GameTest
{
    [Fact]
    public void StartNewGame_WithCorrectValues_CreatesMatrix()
    {
        var game = new Game.Game();

        Assert.NotNull(game.Field);
    }

    [Theory]
    [InlineData(2, 1, true)]
    [InlineData(1, 1, false)]
    public void MakeMove_WhenEmptyField_SetsValue(int row, int col, bool value)
    {
        var game = new Game.Game();

        var result = game.MakeMove(row, col, value);

        Assert.Equal(Result.CorrectMove, result);
        Assert.Equal(value, game.Field[row, col]);
    }

    [Theory]
    [InlineData(0, 1, true, false)]
    [InlineData(2, 1, false, true)]
    public void MakeMove_WhenNotEmptyField_NotSetsValue(int row, int col, bool value, bool newValue)
    {
        var game = new Game.Game();
        game.MakeMove(row, col, value);

        var result = game.MakeMove(row, col, newValue);

        Assert.Equal(Result.IncorrectMove, result);
        Assert.Equal(value, game.Field[row, col]);
    }
    
    [Theory]
    [InlineData(4, 1, true)]
    [InlineData(0, 7, false)]
    public void MakeMove_WhenIncorrectRowOrColumn_NotSetsValue(int row, int col, bool value)
    {
        var game = new Game.Game();

        var result = game.MakeMove(row, col, value);
    
        Assert.Equal(Result.IncorrectMove, result);
    }
    
    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void MakeMove_WhenNoFreeFieldsLeftAndNoWinner_EndsWithDraw(bool value)
    {
        var game = new Game.Game();
        game.MakeMove(0, 0, true);
        game.MakeMove(0, 1, true);
        game.MakeMove(0, 2, false);
        game.MakeMove(1, 0, false);
        game.MakeMove(1, 1, false);
        game.MakeMove(1, 2, true); 
        game.MakeMove(2, 0, true);
        game.MakeMove(2, 1, false);
    
        var result = game.MakeMove(2, 2, value);
    
        Assert.Equal(Result.Draw, result);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void MakeMove_WhenSameNotNullValuesInRow_EndsWithWinCrosses(bool value)
    {
        var game = new Game.Game();

        game.MakeMove(0, 0, value);
        game.MakeMove(0, 1, value);
        
        var result = game.MakeMove(0, 2, value);
        
        Assert.True(result == Result.WinnerCrosses && value || result == Result.WinnerZeros && !value);
    }
    
    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void MakeMove_WhenSameNotNullValuesInColumn_EndsWithWin(bool value)
    {
        var game = new Game.Game();

        game.MakeMove(0, 0, value);
        game.MakeMove(1, 0, value);
        
        var result = game.MakeMove(2, 0, value);
        
        Assert.True(result == Result.WinnerCrosses && value || result == Result.WinnerZeros && !value);
    }
    
    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void MakeMove_WhenSameNotNullValuesInPrimaryDiagonal_EndsWithWin(bool value)
    {
        var game = new Game.Game();

        game.MakeMove(0, 0, value);
        game.MakeMove(1, 1, value);
        
        var result = game.MakeMove(2, 2, value);
        
        Assert.True(result == Result.WinnerCrosses && value || result == Result.WinnerZeros && !value);
    }
    
    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void MakeMove_WhenSameNotNullValuesInSecondaryDiagonal_EndsWithWin(bool value)
    {
        var game = new Game.Game();

        game.MakeMove(0, 2, value);
        game.MakeMove(1, 1, value);
        
        var result = game.MakeMove(2, 0, value);
        
        Assert.True(result == Result.WinnerCrosses && value || result == Result.WinnerZeros && !value);
    }
}