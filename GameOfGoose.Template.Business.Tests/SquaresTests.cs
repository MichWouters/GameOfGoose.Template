using GameOfGoose.Template.Business.Players;

namespace GameOfGoose.Template.Business.Tests
{
    public class SquaresTests
    {
        private PlayerHelper _helper = new PlayerHelper();

        [Fact]
        public void BridgeShouldMovePlayerToSquare12()
        {
            // Arrange
            IPlayer player = _helper.SetupTestCase(2, [2, 2]);

            // Act
            player.RollDice();

            // Assert
            Assert.Equal(12, player.Position);
            Assert.NotEqual(5, player.Position);
        }

        [Fact]
        public void MazeShouldMovePlayerToSquare39()
        {
            // Arrange
            IPlayer player = _helper.SetupTestCase(40, [1, 1]);

            // Act
            player.RollDice();

            // Assert
            Assert.Equal(39, player.Position);
            Assert.NotEqual(42, player.Position);
        }

        [Fact]
        public void DeathShouldMovePlayerBackToStart()
        {
            // Arrange
            IPlayer player = _helper.SetupTestCase(56, [1, 1]);

            // Act
            player.RollDice();

            // Assert
            Assert.Equal(0, player.Position);
            Assert.NotEqual(57, player.Position);
        }

        [Fact]
        public void WhenPlayerLandsOnEnd_PlayerIsPronouncedWinner()
        {
            // Arrange
            IPlayer player = _helper.SetupTestCase(56, [6,1]);

            // Act
            player.RollDice();

            // Assert
            Assert.True(player.IsWinner);
        }
    }
}