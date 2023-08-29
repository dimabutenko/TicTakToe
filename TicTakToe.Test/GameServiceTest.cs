namespace TicTakToe.Test;

public class GameServiceTest : IClassFixture<GameServiceFixture>
{
    private readonly GameServiceFixture _gameServiceFixture;
    
    public GameServiceTest(GameServiceFixture gameServiceFixture)
    {
        _gameServiceFixture = gameServiceFixture;
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CheckForWinner_WhenSameNotNullValuesInRow_EndsWithWinCrosses(bool value)
    {
        var field = new bool?[,] { { value, value, value }, { null, null, null }, { null, null, null } };

        var result = _gameServiceFixture.GameService.CheckForWinner(field,0, 2);

        Assert.True(result);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CheckForWinner_WhenSameNotNullValuesInColumn_EndsWithWin(bool value)
    {
        var field = new bool?[,] { { value, null, null }, { value, null, null }, { value, null, null } };

        var result = _gameServiceFixture.GameService.CheckForWinner(field,2, 0);

        Assert.True(result);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CheckForWinner_WhenSameNotNullValuesInPrimaryDiagonal_EndsWithWin(bool value)
    {
        var field = new bool?[,] { { value, null, null }, { null, value, null }, { null, null, value } };

        var result = _gameServiceFixture.GameService.CheckForWinner(field,2, 2);

        Assert.True(result);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CheckForWinner_WhenSameNotNullValuesInSecondaryDiagonal_EndsWithWin(bool value)
    {
        var field = new bool?[,] { { null, null, value }, { null, value, null }, { value, null, null } };

        var result = _gameServiceFixture.GameService.CheckForWinner(field,2, 0);

        Assert.True(result);
    }
}