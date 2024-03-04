using GameOfGoose.Template.Business.Players;

namespace GameOfGoose.Template.Business.Factories
{
    public interface IPlayerFactory
    {
        IPlayer CreatePlayer(int position);

        List<IPlayer> CreatePlayers(int amountOfPlayers);
    }
}