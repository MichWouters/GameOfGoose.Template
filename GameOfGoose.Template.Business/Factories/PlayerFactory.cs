using GameOfGoose.Template.Business.Boards;
using GameOfGoose.Template.Business.Game;
using GameOfGoose.Template.Business.Players;

namespace GameOfGoose.Template.Business.Factories;

public class PlayerFactory(IDiceRoller diceRoller, IGameBoard gameBoard) : IPlayerFactory
{
    public IPlayer CreatePlayer(int position)
    {
        return new Player(diceRoller, gameBoard, position);
    }

    public List<IPlayer> CreatePlayers(int amountOfPlayers)
    {
        List<IPlayer> players = [];

        for (int i = 0; i < amountOfPlayers; i++)
        {
            players.Add(CreatePlayer(0));
        }

        return players;
    }
}