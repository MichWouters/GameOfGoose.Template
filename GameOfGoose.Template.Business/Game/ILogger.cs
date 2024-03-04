namespace GameOfGoose.Template.Business.Game;

public interface ILogger
{
    void Log(string message);

    void LogError(string message);
}