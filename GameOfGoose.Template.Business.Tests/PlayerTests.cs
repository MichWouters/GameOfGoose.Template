using GameOfGoose.Template.Business.Boards;
using GameOfGoose.Template.Business.Game;
using GameOfGoose.Template.Business.Players;
using Moq;

namespace GameOfGoose.Template.Business.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void WhenDiceAreRolled_PlayerShouldMoveTheAmountOfDiceRolled()
        {
            // Arrange
            var player = SetupPlayer(8, [2,2]);

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
            var player = SetupPlayer(start, null);

            // Act
            player.MoveTo(destination);

            // Assert
            Assert.Equal(destination, player.Position);
            Assert.NotEqual(start, player.Position);
        }

        private IPlayer SetupPlayer(int startPosition, int[]? diceRoll)
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