using GameOfGoose.Template.Business.Boards;
using GameOfGoose.Template.Business.Game;
using GameOfGoose.Template.Business.Squares;

namespace GameOfGoose.Template.Business.Players
{
    public class Player : IPlayer
    {
        private static int _count;

        private ISquare? _currentSquare;

        private IDiceRoller _diceRoller;

        private IGameBoard _gameBoard;

        public Player(IDiceRoller diceRoller, IGameBoard gameBoard, int position)
        {
            _count++;
            _diceRoller = diceRoller;
            _gameBoard = gameBoard;

            Position = position;
            _currentSquare = _gameBoard.GetSquare(0);
        }

        public bool IsWinner { get; private set; }
        public string Name { get; set; } = $"Player {_count}";

        public int Position { get; private set; }

        public void MoveTo(int destination)
        {
            Position = destination;
            HandleEnterSquare();
        }

        public void RollDice(bool firstTurn)
        {
            int[] result = _diceRoller.RollDice();
            Move(result.Sum());
        }

        public void SetWinner()
        {
            IsWinner = true;
        }

        private void HandleEnterSquare()
        {
            _currentSquare = _gameBoard.GetSquare(Position);
            _currentSquare.HandlePlayer(this);
        }

        private void Move(int roll)
        {
            Position += roll;
            HandleEnterSquare();
        }
    }
}