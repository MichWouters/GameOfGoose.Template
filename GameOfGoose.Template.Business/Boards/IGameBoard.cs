using GameOfGoose.Template.Business.Squares;

namespace GameOfGoose.Template.Business.Boards;

public interface IGameBoard
{
    void CreateBoard(BoardConfiguration config);
    ISquare GetSquare(int index);
}