using GameOfGoose.Template.Business.Game;
using GameOfGoose.Template.Business.Squares;

namespace GameOfGoose.Template.Business.Factories
{
    public class SquareFactory(ILogger logger) : ISquareFactory
    {
        public ISquare Create(int index, SquareType squareType)
        {
            return squareType switch
            {
                SquareType.Well => new Well(logger, index),
                SquareType.Prison => new Prison(logger, index),
                SquareType.Maze => new Maze(logger, index),
                SquareType.End => new End(logger, index),
                SquareType.Death => new Death(logger, index),
                SquareType.Bridge => new Bridge(logger, index),
                SquareType.Goose => new Goose(logger,index),
                SquareType.Inn => new Inn(logger, index),
                SquareType.Regular => new Regular(logger, index),
                SquareType.Start => new Regular(logger, index),
                _ => throw new ArgumentOutOfRangeException(nameof(squareType), "Square type unavailable"),
            };
        }
    }
}