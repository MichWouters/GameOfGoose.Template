using GameOfGoose.Template.Business.Players;

namespace GameOfGoose.Template.Business.Tests;

public class GameTests
{
    private readonly PlayerHelper _helper = new();

    [Fact]
    public void WhenPlayerIsOnStart_AndRolls5And4_AndIsFirstTurn_ThenPlayerMovesTo26()
    {
        // Arrange
        IPlayer player = _helper.SetupTestPlayer(0, [5, 4]);
        Game.Game game = _helper.SetupTestGame(1, [player]);

        // Act
        game.PlayTurn();

        // Assert
        Assert.Equal(26, player.Position);
    }

    [Fact]
    public void WhenPlayerIsOnStart_AndRolls6And3_AndIsFirstTurn_ThenPlayerMovesTo53()
    {
        // Arrange
        IPlayer player = _helper.SetupTestPlayer(0, [6, 3]);
        Game.Game game = _helper.SetupTestGame(1, [player]);

        // Act
        game.PlayTurn();

        // Assert
        Assert.Equal(53, player.Position);
    }

    [Fact]
    public void WhenPlayerIsOnStart_AndRolls9_AndIsNotFirstTurn_ThenPlayerWins()
    {
        // Arrange
        IPlayer player = _helper.SetupTestPlayer(0, [6, 3]);
        Game.Game game = _helper.SetupTestGame(2, [player]);

        // Act
        game.PlayTurn();

        // Assert
        Assert.Equal(63, player.Position);
        Assert.True(player.IsWinner);
    }

    [Fact]
    public void WhenTurnEnds_PlayerThatHaveTurnsToBeSkipped_GetDecreasedByOne()
    {
        // Arrange
        IPlayer player1 = _helper.SetupTestPlayer(5, [4, 4]);
        IPlayer player2 = _helper.SetupTestPlayer(5, [4, 4]);
        IPlayer player3 = _helper.SetupTestPlayer(5, [4, 4]);

        player1.TurnsToSkip = 2;
        player2.TurnsToSkip = 1;

        var game = _helper.SetupTestGame(1, [player1, player2, player3]);

        // Act
        game.PlayTurn();

        // Assert
        Assert.Equal(1, player1.TurnsToSkip);
        Assert.Equal(0, player2.TurnsToSkip);
        Assert.Equal(0, player3.TurnsToSkip);
    }

    [Fact]
    public void WhenPlayerWinsGame_ThenGameEndsWithOneWinner()
    { 
        // Arrange
        IPlayer player1 = _helper.SetupTestPlayer(61, [1, 1]);
        IPlayer player2 = _helper.SetupTestPlayer(61, [1, 1]);
        var game = _helper.SetupTestGame(1, [player1, player2]);

        // Act
        game.PlayTurn();

        // Assert
        Assert.True(player1.IsWinner);
        Assert.False(player2.IsWinner);
        Assert.True(game.HasGameEnded);
    }
}