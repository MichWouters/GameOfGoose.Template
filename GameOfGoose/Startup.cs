using GameOfGoose.Template.Business.Boards;
using GameOfGoose.Template.Business.Factories;
using GameOfGoose.Template.Business.Game;
using Microsoft.Extensions.DependencyInjection;

namespace GameOfGoose.Template
{
    internal class Startup
    {
        private ServiceProvider ConfigureServices()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IGameBoard, GameBoard>()
                .AddTransient<ISquareFactory, SquareFactory>()
                .AddTransient<IPlayerFactory, PlayerFactory>()
                .AddTransient<IDiceRoller, DiceRoller>()
                .AddTransient<ILogger, Logger>()
                .AddSingleton<Game>()
                .BuildServiceProvider();

            return serviceProvider;
        }

        internal Game SetupGame()
        {
            Game game = ConfigureServices().GetRequiredService<Game>();
            return game;
        }
    }
}