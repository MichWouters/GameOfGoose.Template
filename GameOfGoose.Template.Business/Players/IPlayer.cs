namespace GameOfGoose.Template.Business.Players
{
    public interface IPlayer
    {
        int[] DiceRolls { get; }

        bool IsWinner { get; }

        string Name { get; }

        int Position { get; }

        void MoveTo(int destination);

        void RollDice(bool firstTurn = false);

        void SetWinner();
    }
}