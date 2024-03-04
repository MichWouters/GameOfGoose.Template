using GameOfGoose.Template.Business.Squares;

namespace GameOfGoose.Template.Business.Factories;

public interface ISquareFactory
{
    ISquare Create(int index, SquareType squareType);
}