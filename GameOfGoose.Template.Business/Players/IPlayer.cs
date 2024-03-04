namespace GameOfGoose.Template.Business.Players
{
    public interface IPlayer
    {
        bool IsWinner { get; }

        string Name { get; set; }

        int Position { get; }

        void MoveTo(int destination);

        void RollDice(bool firstTurn = false);

        void SetWinner();
    }
}