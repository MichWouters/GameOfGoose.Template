using GameOfGoose.Template.Business.Boards;
using GameOfGoose.Template.Business.Game;
using GameOfGoose.Template.Business.Squares;
using System;
using System.Drawing;

namespace GameOfGoose.Template.Business.Players
{
    public class Player : IPlayer
    {
        private static int _count = 1;
        private ISquare? _currentSquare;
        private IDiceRoller _diceRoller;
        private IGameBoard _gameBoard;
        private ILogger _logger;

        public Player(IDiceRoller diceRoller, ILogger logger, IGameBoard gameBoard, int position)
        {
            _count++;
            _diceRoller = diceRoller;
            _logger = logger;
            _gameBoard = gameBoard;

            Position = position;
            _currentSquare = _gameBoard.GetSquare(0);
        }

        public bool CanMove => !IsStuckInWell && TurnsToSkip == 0;
        public int[] DiceRolls { get; private set; }
        public bool IsMovingBackWards { get; set; }
        public bool IsStuckInWell { get; set; }
        public bool IsWinner { get; private set; }
        public string Name { get; } = $"Player {_count}";
        public int Position { get; private set; }
        public int TurnsToSkip { get; set; }

        public void Move(int roll)
        {
            int destination = CalculateDestination(roll);

            Position = destination;
            HandleEnterSquare();
            IsMovingBackWards = false;
        }

        public void MoveTo(int destination)
        {
            Position = destination;
            HandleEnterSquare();
        }

        public void RollDice(bool isFirstTurn)
        {
            if (CanMove)
            {
                HandleTurn(isFirstTurn);
            }
            else
            {
                SkipTurn();
            }
        }

        public void SetWinner()
        {
            IsWinner = true;
        }

        public void SkipTurn()
        {
            if (TurnsToSkip > 0)
            {
                TurnsToSkip--;
                _logger.Log($"{Name} skipped a turn. {TurnsToSkip} turns left to skip.");
            }

            if (IsStuckInWell)
            {
                _logger.Log($"{Name} spends a turn stuck in the well.");
            }
        }

        private int CalculateDestination(int roll)
        {
            int destination;
            if (IsMovingBackWards)
            {
                destination = Position - roll;
                if (destination < 0) destination = 0;
            }
            else
            {
                destination = Position + roll;

                if (destination > _gameBoard.AmountOfSquares)
                {
                    int overshot = destination - _gameBoard.AmountOfSquares;
                    destination = _gameBoard.AmountOfSquares - overshot;
                    IsMovingBackWards = true;
                }
            }

            return destination;
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

        private void HandleTurn(bool isFirstTurn)
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
    }
}