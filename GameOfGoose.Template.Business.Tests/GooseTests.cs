using GameOfGoose.Template.Business.Players;

namespace GameOfGoose.Template.Business.Tests;

public class GooseTests
{
    private PlayerHelper _helper = new();

    [Theory]
    [InlineData(7, new[] { 1, 1 }, 11)]
    [InlineData(11, new[] { 2, 1 }, 17)]
    public void WhenPlayerLandsOnGoose_GooseSendsForward(int startPosition, int[] diceRolls, int expectedPosition)
    {
        // Arrange
        IPlayer player = _helper.SetupTestPlayer(startPosition, diceRolls);

        // Act
        player.RollDice();

        // Assert
        Assert.Equal(diceRolls.Sum(), player.DiceRolls.Sum());
        Assert.Equal(expectedPosition, player.Position);
    }

    [Theory]
    [InlineData(1, new[] { 3, 1 }, 13)]
    [InlineData(22, new[] { 3, 2 }, 37)]
    public void WhenPlayerLandsOnMultipleGeese_PlayerKeepsMoving(int startPosition, int[] diceRolls, int expectedPosition)
    {
        // Arrange
        IPlayer player = _helper.SetupTestPlayer(startPosition, diceRolls);

        // Act
        player.RollDice();

        // Assert
        Assert.Equal(diceRolls.Sum(), player.DiceRolls.Sum());
        Assert.Equal(expectedPosition, player.Position);
    }

    [Theory]
    [InlineData(3, new[] { 2, 1 }, 12)]
    public void WhenPlayerPassesGoose_ButDoesNotLandOnGoose_GooseActionIsNotTriggered(int startPosition, int[] diceRolls, int expectedPosition)
    {
        // Arrange
        IPlayer player = _helper.SetupTestPlayer(startPosition, diceRolls);

        // Act
        player.RollDice();

        // Assert
        Assert.Equal(diceRolls.Sum(), player.DiceRolls.Sum());
        Assert.Equal(expectedPosition, player.Position);
    }

    [Theory]
    [InlineData(11, new[] { 1, 1 }, 7)]
    [InlineData(22, new[] { 3, 1 }, 10)]
    [InlineData(26, new[] { 1, 2 }, 20)]
    public void WhenPlayerLandsOnGoose_AndReverseMovementIsTrue_GooseSendsPlayerBackwards(int startPosition, int[] diceRolls, int expectedPosition)
    {
        // Arrange
        IPlayer player = _helper.SetupTestPlayer(startPosition, diceRolls);
        player.IsMovingBackWards = true;

        // Act
        player.RollDice();

        // Assert
        Assert.Equal(diceRolls.Sum(), player.DiceRolls.Sum());
        Assert.Equal(expectedPosition, player.Position);
        Assert.False(player.IsMovingBackWards);
    }

    [Theory]
    [InlineData(61, new[] { 3, 3 }, 53)]
    [InlineData(62, new[] { 4, 1 }, 49)]
    [InlineData(62, new[] { 2, 1 }, 61)]
    public void WhenPlayerPassesSquare63_AndLandsOnGoose_GooseSendsBackwards(int startPosition, int[] diceRolls, int expectedPosition)
    {
        // Arrange
        IPlayer player = _helper.SetupTestPlayer(startPosition, diceRolls);

        // Act
        player.RollDice();

        // Assert
        Assert.Equal(diceRolls.Sum(), player.DiceRolls.Sum());
        Assert.Equal(expectedPosition, player.Position);
        Assert.False(player.IsMovingBackWards);
    }

    [Theory]
    [InlineData(11, new[] { 3, 3 })]
    [InlineData(20, new[] { 6, 5 })]
    public void WhenPlayerLandsOnGoose_AndReverseMovementIsTrue_AndNewPositionIsLessThan0_NewPositionIs0(int startPosition, int[] diceRolls)
    {
        // Arrange
        IPlayer player = _helper.SetupTestPlayer(startPosition, diceRolls);
        player.IsMovingBackWards = true;

        // Act
        player.RollDice();

        // Assert
        Assert.Equal(0, player.Position);
        Assert.False(player.IsMovingBackWards);
    }
}