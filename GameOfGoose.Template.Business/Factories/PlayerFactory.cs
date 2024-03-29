﻿using GameOfGoose.Template.Business.Boards;
using GameOfGoose.Template.Business.Game;
using GameOfGoose.Template.Business.Players;

namespace GameOfGoose.Template.Business.Factories;

// Create a PlayerFactory to encapsulate the dependency Injection for creating players
public class PlayerFactory(IDiceRoller diceRoller, ILogger logger, IGameBoard gameBoard) : IPlayerFactory
{
    public IPlayer CreatePlayer(int position)
    {
        return new Player(diceRoller,logger, gameBoard, position);
    }

    public IPlayer[] CreatePlayers(uint amountOfPlayers)
    {
        IPlayer[] players = new IPlayer[amountOfPlayers];

        for (int i = 0; i < amountOfPlayers; i++)
        {
            players[i] = CreatePlayer(0);
        }

        return players;
    }
}