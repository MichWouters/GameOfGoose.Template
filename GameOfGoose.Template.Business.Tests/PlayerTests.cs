namespace GameOfGoose.Template.Business.Tests
{
    public class PlayerTests
    {
        private readonly PlayerHelper _helper = new();

        [Fact]
        public void WhenDiceAreRolled_PlayerShouldMoveTheAmountOfDiceRolled()
        {
            // Arrange
            var player = _helper.SetupTestCase(8, [2, 2]);

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
            var player = _helper.SetupTestCase(start, null);

            // Act
            player.MoveTo(destination);

            // Assert
            Assert.Equal(destination, player.Position);
            Assert.NotEqual(start, player.Position);
        }
    }
}