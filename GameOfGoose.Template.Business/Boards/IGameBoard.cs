using GameOfGoose.Template.Business.Squares;

namespace GameOfGoose.Template.Business.Boards;

public interface IGameBoard
{
    ISquare GetSquare(int index);
}