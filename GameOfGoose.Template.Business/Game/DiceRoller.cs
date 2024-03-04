namespace GameOfGoose.Template.Business.Game;

public class DiceRoller : IDiceRoller
{
    private Random random = new();

    public int[] RollDice(int amountOfDice = 2, int maxEyes = 6)
    {
        int[] diceThrow = new int[amountOfDice];

        for (int i = 0; i < amountOfDice; i++)
        {
            diceThrow[i] = random.Next(1, maxEyes + 1);
        }

        return diceThrow;
    }
}