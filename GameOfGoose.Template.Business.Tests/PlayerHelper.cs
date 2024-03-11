using GameOfGoose.Template.Business.Boards;
using GameOfGoose.Template.Business.Game;
using GameOfGoose.Template.Business.Players;
using Moq;

namespace GameOfGoose.Template.Business.Tests
{
    internal class PlayerHelper
    {
        Mock<ILogger> _mockLogger = new();

        /// <summary>
        /// Provides a fully mocked test scenario
        /// </summary>
        /// <param name="startPosition">The position where the player starts</param>
        /// <param name="diceRoll">The amount the player rolled</param>
        /// <param name="squarePosition">The position of the square where the player will land</param>
        /// <param name="squareType">The type of the square where the player will land</param>
        /// <returns></returns>
        internal IPlayer SetupTestCase(int startPosition, int[] diceRoll)
        {
            Mock<IDiceRoller> diceMock = new();
            diceMock
                .Setup(x => x.RollDice(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(diceRoll);

            GameBoard gameBoard = new GameBoard(_mockLogger.Object, false);

            IPlayer player = new Player(diceMock.Object, gameBoard, startPosition);
            return player;
        }
    }
}