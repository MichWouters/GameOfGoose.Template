using GameOfGoose.Template.Business.Game;

namespace GameOfGoose.Template;

public class Logger: ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }

    public void LogError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}