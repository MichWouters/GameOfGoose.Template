namespace GameOfGoose.Template.Business.Tests
{
    public class PlayerTests
    {
        private readonly PlayerHelper _helper = new();

        [Fact]
        public void WhenDiceAreRolled_PlayerShouldMoveTheAmountOfDiceRolled()
        {
            // Arrange
            var player = _helper.SetupTestPlayer(8, [2, 2]);

            // Act
            player.RollDice();

            // Assert
            Assert.Equal(12, player.Position);
        }

        [Theory]
        [InlineData(40, 12)]
        [InlineData(4, 25)]
        public void WhenPlayerMoveToIsCalled_PlayerShouldMoveToThatExactLocation(int start, int destination)
        {
            // Arrange
            var player = _helper.SetupTestPlayer(start, null);

            // Act
            player.MoveTo(destination);

            // Assert
            Assert.Equal(destination, player.Position);
            Assert.NotEqual(start, player.Position);
        }

        [Theory]
        [InlineData(61, new[] {2,3}, 60)]
        [InlineData(62, new[] {1,1}, 62)]
        [InlineData(57, new[] {1,6}, 62)]
        public void WhenPlayerOvershootsLastSquare_PlayerShouldMoveTheOvershotAmountBackwards(int start, int[]roll,  int expectedLocation)
        {
            // Arrange
            var player = _helper.SetupTestPlayer(start, roll);

            // Act
            player.RollDice();

            // Assert
            Assert.Equal(expectedLocation, player.Position);
            Assert.False(player.IsMovingBackWards);
        }
    }
}