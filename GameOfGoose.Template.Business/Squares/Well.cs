using GameOfGoose.Template.Business.Game;
using GameOfGoose.Template.Business.Players;

namespace GameOfGoose.Template.Business.Squares
{
    internal class Well(ILogger logger, int index) : ISquare
    {
        public int Index { get; set; } = index;

        public ILogger Logger { get; set; } = logger;

        private IPlayer? TrappedPlayer = null;

        public void HandlePlayer(IPlayer player)
        {
            Logger.Log($"Sploosh! {player.Name} fell down the well! Go get help, Lassie!");
            player.IsStuckInWell = false;

            if (TrappedPlayer is not null)
            {
                Logger.Log($"using {player.Name}'s head as a booster, {TrappedPlayer.Name} was able to escape from the well!");
                TrappedPlayer.IsStuckInWell = true;
            }
            
            TrappedPlayer = player;

        }
    }
}