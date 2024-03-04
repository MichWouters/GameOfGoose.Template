using GameOfGoose.Template.Business.Game;
using GameOfGoose.Template.Business.Players;

namespace GameOfGoose.Template.Business.Squares;

public interface ISquare
{
    int Index { get; set; }

    void HandlePlayer(IPlayer player);

    ILogger Logger { get; set; }
}