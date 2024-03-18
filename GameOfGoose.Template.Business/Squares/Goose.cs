using GameOfGoose.Template.Business.Game;
using GameOfGoose.Template.Business.Players;

namespace GameOfGoose.Template.Business.Squares;

internal class Goose(ILogger logger, int index) : ISquare
{
    public int Index { get; set; } = index;

    public ILogger Logger { get; set; } = logger;

    public void HandlePlayer(IPlayer player)
    {
        string suffix = player.IsMovingBackWards ? "backwards" : "again";
        Logger.Log($"{player.Name} hit a goose on {Index} and moved {player.DiceRolls.Sum()} {suffix}.");
        player.Move(player.DiceRolls.Sum());
    }
}