using GameOfGoose.Template.Business.Boards;
using GameOfGoose.Template.Business.Game;
using GameOfGoose.Template.Business.Squares;

namespace GameOfGoose.Template.Business.Players
{
    public class Player : IPlayer
    {
        private static int _count = 1;
        private ISquare? _currentSquare;
        private IDiceRoller _diceRoller;
        private ILogger _logger;
        private IGameBoard _gameBoard;

        public Player(IDiceRoller diceRoller, ILogger logger, IGameBoard gameBoard, int position)
        {
            _count++;
            _diceRoller = diceRoller;
            _logger = logger;
            _gameBoard = gameBoard;

            Position = position;
            _currentSquare = _gameBoard.GetSquare(0);
        }

        public int[] DiceRolls { get; private set; }
        public bool IsMovingBackWards { get; set; }
        public bool IsStuckInWell { get; set; }
        public bool IsWinner { get; private set; }
        public string Name { get; } = $"Player {_count}";
        public int Position { get; private set; }
        public int TurnsToSkip { get; set; }

        public void Move(int roll)
        {
            Position += roll;
            HandleEnterSquare();
        }

        public void MoveTo(int destination)
        {
            Position = destination;
            HandleEnterSquare();
        }

        public void RollDice(bool isFirstTurn)
        {
            int[] result = _diceRoller.RollDice();
            DiceRolls = result;

            int roll = result.Sum();
            _logger.Log($"{Name} rolled {roll}.");

            if (isFirstTurn && roll == 9)
            {
                HandleFirstTurnExceptions();
            }
            else
            {
                Move(roll);
            }
        }

        public void SetWinner()
        {
            IsWinner = true;
        }

        public void SkipTurn()
        {
            if (TurnsToSkip > 0 && !IsStuckInWell)
            {
                TurnsToSkip--;
                _logger.Log($"{Name} skipped a turn. {TurnsToSkip} turns left to skip.");
            }
        }

        private void HandleEnterSquare()
        {
            _currentSquare = _gameBoard.GetSquare(Position);
            _currentSquare.HandlePlayer(this);
        }

        private void HandleFirstTurnExceptions()
        {
            if (DiceRolls.Contains(5) && DiceRolls.Contains(4))
            {
                MoveTo(26);
            }
            else if (DiceRolls.Contains(6) && DiceRolls.Contains(3))
            {
                MoveTo(53);
            }
        }
    }
}