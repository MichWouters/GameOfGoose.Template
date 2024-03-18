namespace GameOfGoose.Template.Business.Players
{
    public interface IPlayer
    {
        public bool CanMove { get; }
        int[] DiceRolls { get; }
        bool IsMovingBackWards { get; set; }
        bool IsWinner { get; }
        string Name { get; }
        int Position { get; }
        bool IsStuckInWell { get; set; }
        int TurnsToSkip { get; set; }

        void Move(int roll);
        void MoveTo(int destination);
        void RollDice(bool isFirstTurn = false);
        void SetWinner();
        void SkipTurn();
    }
}