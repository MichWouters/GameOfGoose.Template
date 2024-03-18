using GameOfGoose.Template.Business.Factories;
using GameOfGoose.Template.Business.Game;
using GameOfGoose.Template.Business.Squares;
using Newtonsoft.Json;

namespace GameOfGoose.Template.Business.Boards
{
    public class GameBoard : IGameBoard
    {
        private readonly BoardConfiguration _config;
        private readonly ISquareFactory _factory;
        private readonly int[] _geeseSquares = [5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59];

        private readonly Dictionary<int, SquareType> _specialSquares = new()
        {
            { 0, SquareType.Start },
            { 6, SquareType.Bridge },
            { 19, SquareType.Inn },
            { 31, SquareType.Well },
            { 42, SquareType.Maze },
            { 52, SquareType.Prison },
            { 58, SquareType.Death },
            { 63, SquareType.End },
        };

        private readonly List<ISquare> _squares;

        public GameBoard(ILogger logger, bool useJsonConfig = true)
        {
            _factory = new SquareFactory(logger);
            _squares = [];

            if (useJsonConfig)
            {
                // Alternative way -> Use JSON configs instead of hardcoding
                _config = GetDataFromJson("Boards/StandardBoard.json");
            }
            else
            {
                // Standard way -> Hard code values
                _config = new BoardConfiguration
                {
                    AmountOfSquares = 64,
                    GeeseSquares = _geeseSquares,
                    SpecialSquares = _specialSquares
                };
            }

            CreateBoard(_config);
        }

        public ISquare GetSquare(int index)
        {
            return _squares.ElementAtOrDefault(index)
                   ?? throw new ArgumentOutOfRangeException(nameof(index), "Square could not be found");
        }

        private void CreateBoard(BoardConfiguration config)
        {
            _squares.Clear();

            for (int i = 0; i < config.AmountOfSquares; i++)
            {
                _squares.Add(CreateSquare(i));
            }
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

        private BoardConfiguration GetDataFromJson(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException(nameof(filePath));

            string jsonString = File.ReadAllText(filePath);
            BoardConfiguration boardConfig = JsonConvert.DeserializeObject<BoardConfiguration>(jsonString);
            return boardConfig;
        }
    }
}