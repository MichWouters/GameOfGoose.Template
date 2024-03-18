using GameOfGoose.Template.Business.Players;

namespace GameOfGoose.Template.Business.Tests
{
    public class SquaresTests
    {
        private PlayerHelper _helper = new ();

        [Fact]
        public void BridgeShouldMovePlayerToSquare12()
        {
            // Arrange
            IPlayer player = _helper.SetupTestPlayer(2, [2, 2]);

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
            IPlayer player = _helper.SetupTestPlayer(40, [1, 1]);

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
            IPlayer player = _helper.SetupTestPlayer(56, [1, 1]);

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
            IPlayer player = _helper.SetupTestPlayer(56, [6,1]);

            // Act
            player.RollDice();

            // Assert
            Assert.True(player.IsWinner);
        }

        [Fact]
        public void WhenPlayerDoesNotLandOnEnd_PlayerIsNotPronouncedWinner()
        {
            // Arrange
            IPlayer player = _helper.SetupTestPlayer(13, [4, 3]);

            // Act
            player.RollDice();

            // Assert
            Assert.False(player.IsWinner);
        }

        [Fact]
        public void WhenPlayerLandsOnInn_SkipOneTurn()
        {
            // Arrange
            IPlayer player = _helper.SetupTestPlayer(12, [4, 3]);

            // Act
            player.RollDice();

            // Assert
            Assert.Equal(1, player.TurnsToSkip);
        }

        [Fact]
        public void WhenPlayerLandsOnPrison_SkipThreeTurns()
        {
            // Arrange
            IPlayer player = _helper.SetupTestPlayer(47, [2, 3]);

            // Act
            player.RollDice();

            // Assert
            Assert.Equal(3, player.TurnsToSkip);
        }

        [Fact]
        public void WhenPlayerLandsOnWell_StuckInWellIsTrue()
        {
            // Arrange
            IPlayer player = _helper.SetupTestPlayer(28, [2, 1]);

            // Act
            player.RollDice();

            // Assert
            Assert.True(player.IsStuckInWell);
        }

        [Fact]
        public void WhenPlayerIsStuckInWell_HeCannotMove()
        {
            // Arrange
            IPlayer player = _helper.SetupTestPlayer(28, [2, 1]);

            // Act & Assert
            player.RollDice();
            Assert.True(player.IsStuckInWell);
            Assert.Equal(31, player.Position);

            player.RollDice();
            Assert.True(player.IsStuckInWell);
            Assert.Equal(31, player.Position);
        }

        [Fact]
        public void WhenPlayerLandsOnWell_SkipTurnsUntilNextPlayerLandsOnWell()
        {
            // Arrange
            IPlayer player1 = _helper.SetupTestPlayer(28, [2, 1]);
            IPlayer player2 = _helper.SetupTestPlayer(28, [2, 1]);
            IPlayer player3 = _helper.SetupTestPlayer(28, [2, 1]);

            // Trap player 1
            player1.RollDice();
            Assert.True(player1.IsStuckInWell);
            Assert.False(player2.IsStuckInWell);
            Assert.False(player3.IsStuckInWell);

            // Trap player 2
            player2.RollDice();
            Assert.False(player1.IsStuckInWell);
            Assert.True(player2.IsStuckInWell);
            Assert.False(player3.IsStuckInWell);

            // Trap player 3
            player3.RollDice();
            Assert.False(player1.IsStuckInWell);
            Assert.False(player2.IsStuckInWell);
            Assert.True(player3.IsStuckInWell);
        }

    }
}