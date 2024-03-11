using GameOfGoose.Template.Business.Game;
using GameOfGoose.Template.Business.Players;

namespace GameOfGoose.Template.Business.Squares;

internal class Goose(ILogger logger, int index) : ISquare
{
    public int Index { get; set; } = index;

    public ILogger Logger { get; set; } = logger;

    public void HandlePlayer(IPlayer player)
    {
        Logger.Log($"{player.Name} hit a goose and moved {player.DiceRolls.Sum()} again.");
        player.Move(player.DiceRolls.Sum());
    }
}