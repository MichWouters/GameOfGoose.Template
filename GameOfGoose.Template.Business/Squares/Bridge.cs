using GameOfGoose.Template.Business.Game;
using GameOfGoose.Template.Business.Players;

namespace GameOfGoose.Template.Business.Squares
{
    internal class Bridge(ILogger logger, int index) : ISquare
    {
        public int Index { get; set; } = index;

        public ILogger Logger { get; set; } = logger;

        public void HandlePlayer(IPlayer player)
        {
            player.MoveTo(12);
        }
    }
}