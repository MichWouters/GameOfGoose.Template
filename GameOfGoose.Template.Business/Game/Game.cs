using GameOfGoose.Template.Business.Boards;
using GameOfGoose.Template.Business.Factories;
using GameOfGoose.Template.Business.Players;
using GameOfGoose.Template.Business.Squares;

namespace GameOfGoose.Template.Business.Game;

public class Game(IGameBoard board, IPlayerFactory factory, ILogger logger, int amountOfPlayers = 2)
{
    public List<IPlayer> Players = factory.CreatePlayers(amountOfPlayers);
    public IGameBoard Board { get; private set; } = board;
    public bool HasGameEnded { get; private set; }
    public int Turn { get; private set; } = 1;

    private ILogger _logger = logger;

    public void PlayGame()
    {
        while (!HasGameEnded)
        {
            PlayTurn();
            EndTurn();
        }

        _logger.Log("Game over");
    }

    private void PlayTurn()
    {
        foreach (IPlayer player in Players)
        {
            player.RollDice(Turn == 1);

            if (player.IsWinner)
            {
                HasGameEnded = true;
                break;
            }
        }
    }

    private void EndTurn()
    {
        _logger.Log("Turn ended");
        Turn++;
    }
}