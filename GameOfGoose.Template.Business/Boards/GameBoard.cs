using GameOfGoose.Template.Business.Factories;
using GameOfGoose.Template.Business.Game;
using GameOfGoose.Template.Business.Squares;
using Newtonsoft.Json;

namespace GameOfGoose.Template.Business.Boards
{
    public class GameBoard : IGameBoard
    {

        private readonly ISquareFactory _factory;

        private readonly BoardConfiguration _config;

        private readonly int[] _geeseSquares = [4, 8, 13, 17, 22, 26, 31, 35, 40, 44, 49, 53, 58];

        private readonly Dictionary<int, SquareType> _specialSquares = new()
        {
            { 0, SquareType.Start },
            { 5, SquareType.Bridge },
            { 18, SquareType.Inn },
            { 30, SquareType.Well },
            { 41, SquareType.Maze },
            { 51, SquareType.Prison },
            { 57, SquareType.Death },
            { 62, SquareType.End },
        };

        private readonly List<ISquare> _squares;

        public GameBoard(ILogger logger)
        {
            _factory = new SquareFactory(logger);
            _squares = [];
            _config = GetDataFromJson("Boards/StandardBoard.json");
            CreateBoard(_config);
        }

        public void CreateBoard(BoardConfiguration config)
        {
            _squares.Clear();

            for (int i = 0; i < config.AmountOfSquares; i++)
            {
                _squares.Add(CreateSquare(i));
            }
        }

        public ISquare GetSquare(int index)
        {
            return _squares.ElementAtOrDefault(index)
                   ?? throw new ArgumentOutOfRangeException(nameof(index), "Square could not be found");
        }

        private ISquare CreateSquare(int index)
        {
            if (_config.SpecialSquares.TryGetValue(index, out SquareType square))
            {
                return _factory.Create(index, square);
            }
            if (_config.GeeseSquares.Contains(index))
            {
                return _factory.Create(index, SquareType.Goose);
            }

            return _factory.Create(index, SquareType.Regular);
        }

        private BoardConfiguration GetDataFromJson(string fileName)
        {
            string filePath = fileName;
            if (!File.Exists(filePath)) throw new FileNotFoundException(nameof(fileName));

            string jsonString = File.ReadAllText(filePath);
            BoardConfiguration boardConfig = JsonConvert.DeserializeObject<BoardConfiguration>(jsonString);
            return boardConfig;
        }
    }
}