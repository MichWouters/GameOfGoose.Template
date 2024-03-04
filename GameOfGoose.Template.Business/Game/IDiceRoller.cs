namespace GameOfGoose.Template.Business.Game;

public interface IDiceRoller
{
    int[] RollDice(int amountOfDice = 2, int maxEyes = 6);
}