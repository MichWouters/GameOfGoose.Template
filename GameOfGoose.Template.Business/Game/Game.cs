using GameOfGoose.Template.Business.Factories;
using GameOfGoose.Template.Business.Players;

namespace GameOfGoose.Template.Business.Game;

public class Game(IPlayerFactory factory, ILogger logger)
{
    public IPlayer[] Players;

    public bool HasGameEnded { get; private set; }
    public int Turn { get; set; } = 1;

    public void PlayGame(uint amountOfPlayers = 2)
    {
        Players = factory.CreatePlayers(amountOfPlayers);
        while (!HasGameEnded)
        {
            PlayTurn();
            EndTurn();
        }

        logger.Log("Game over");
    }

    public void PlayTurn()
    {
        foreach (IPlayer player in Players)
        {
            HandleTurn(player);
            if (WinnerExists(player)) break;
        }
    }

    private void EndTurn()
    {
        logger.Log("Turn ended");
        logger.Log("");
        Turn++;
    }

    private void HandleTurn(IPlayer player)
    {
        if (player.IsStuckInWell || player.TurnsToSkip > 0)
        {
            player.SkipTurn();
        }
        else
        {
            player.RollDice(Turn == 1);
        }
    }

    private bool WinnerExists(IPlayer player)
    {
        if (!player.IsWinner) return false;

        HasGameEnded = true;
        return true;
    }
}