using GameOfGoose.Template.Business.Factories;

namespace GameOfGoose.Template.Business.Boards
{
    public class BoardConfiguration
    {
        public int AmountOfSquares { get; set; }

        public int[] GeeseSquares { get; set; }

        public IDictionary<int, SquareType> SpecialSquares { get; set; }
    }
}