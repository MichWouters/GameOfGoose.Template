using GameOfGoose.Template;
using GameOfGoose.Template.Business.Boards;
using GameOfGoose.Template.Business.Factories;
using GameOfGoose.Template.Business.Game;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
        .AddSingleton<IGameBoard, GameBoard>()
        .AddTransient<ISquareFactory, SquareFactory>()
        .AddTransient<IPlayerFactory, PlayerFactory>()
        .AddTransient<IDiceRoller, DiceRoller>()
        .AddTransient<ILogger, Logger>()
        .AddSingleton<Game>()
    .BuildServiceProvider();

var game = serviceProvider.GetRequiredService<Game>();
game.PlayGame();

