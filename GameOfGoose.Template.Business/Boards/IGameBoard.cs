using GameOfGoose.Template.Business.Squares;

namespace GameOfGoose.Template.Business.Boards;

public interface IGameBoard
{
    int AmountOfSquares { get; }

    ISquare GetSquare(int index);
}