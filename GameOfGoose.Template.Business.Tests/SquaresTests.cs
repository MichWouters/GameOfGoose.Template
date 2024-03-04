using GameOfGoose.Template.Business.Boards;
using GameOfGoose.Template.Business.Game;
using GameOfGoose.Template.Business.Players;
using Moq;

namespace GameOfGoose.Template.Business.Tests
{
    public class SquaresTests
    {
        [Fact]
        public void BridgeShouldMovePlayerToSquare12()
        {
            // Arrange
            IPlayer player = SetupPlayer(2, [1, 3]);

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
            IPlayer player = SetupPlayer(40, [1, 1]);

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
            IPlayer player = SetupPlayer(56, [1, 1]);

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
            IPlayer player = SetupPlayer(56, [6,1]);

            // Act
            player.RollDice();

            // Assert
            Assert.True(player.IsWinner);
            //Assert.True(Game.Instance.HasGameEnded == true);
        }

        private IPlayer SetupPlayer(int startPosition, int[]diceRoll)
        {
            Mock<IDiceRoller> diceMock = new();
            diceMock
                .Setup(x => x.RollDice(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(diceRoll);

            Mock<IGameBoard> gameBoardMock = new();

            IPlayer player = new Player(diceMock.Object, gameBoardMock.Object, startPosition);
            return player;
        }
    }
}