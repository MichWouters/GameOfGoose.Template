using GameOfGoose.Template.Business.Factories;

namespace GameOfGoose.Template.Business.Boards
{
    public class BoardConfiguration
    {
        public int AmountOfSquares { get; set; }

        public required int[] GeeseSquares { get; set; }

        public required IDictionary<int, SquareType> SpecialSquares { get; set; }
    }
}