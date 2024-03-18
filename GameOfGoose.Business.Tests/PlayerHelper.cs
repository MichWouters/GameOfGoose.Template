using GameOfGoose.Template.Business.Boards;
using GameOfGoose.Template.Business.Factories;
using GameOfGoose.Template.Business.Game;
using GameOfGoose.Template.Business.Players;
using Moq;

namespace GameOfGoose.Template.Business.Tests
{
    internal class PlayerHelper
    {
        static Mock<ILogger> _mockLogger = new();
        GameBoard _gameBoard = new(_mockLogger.Object, false);

        /// <summary>
        /// Provides a mocked test player
        /// </summary>
        /// <param name="startPosition">The position where the player starts</param>
        /// <param name="diceRoll">The amount the player rolled</param>
        /// <returns>A test case player</returns>
        internal IPlayer SetupTestPlayer(int startPosition, int[] diceRoll)
        {
            Mock<IDiceRoller> diceMock = new();
            diceMock
                .Setup(x => x.RollDice(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(diceRoll);

            IPlayer player = new Player(diceMock.Object, _mockLogger.Object, _gameBoard, startPosition);
            return player;
        }

        /// <summary>
        /// Provides a mocked test game to which player objects can be added.
        /// </summary>
        /// <param name="turn">The turn currently being played</param>
        /// <param name="players">The player(s) under test</param>
        /// <returns></returns>
        public Game.Game SetupTestGame(int turn, IPlayer[] players)
        {
            var playerFactoryMock = new Mock<IPlayerFactory>();

            return new Game.Game(playerFactoryMock.Object, _mockLogger.Object)
            {
                Turn = turn,
                Players = players
            };
        }
    }
}