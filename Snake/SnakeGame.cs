namespace Snake;

public class SnakeGame
{
    private const int Height = 40;
    private const int Width = 80;
    private Direction _direction;
    private Point _food;
    private bool _gameover;
    private Point _head;
    private int _score;
    private readonly List<Point> _snake;

    public SnakeGame()
    {
        _score = 0;
        _gameover = false;
        _head = new Point(Width / 2, Height / 2);
        _snake = [_head];
        _direction = Direction.Right;
        GenerateFood();
    }

    public void Run()
    {
        while (!_gameover)
        {
            Console.Clear();
            Draw();
            Input();
            Move();
            CheckCollision();
            Thread.Sleep(100);
        }

        Console.WriteLine($"Game Over! Your score: {_score}");
        Console.ReadKey();
    }

    private void CheckCollision()
    {
        // Check collision with walls
        if (_head.X < 0 || _head.X >= Width || _head.Y < 0 || _head.Y >= Height)
        {
            _gameover = true;
        }

        // Check collision with itself
        if (_snake.Count > 1 && _snake.Any(segment => segment.X == _head.X && segment.Y == _head.Y))
        {
            _gameover = true;
        }
    }

    private void Draw()
    {
        Console.SetCursorPosition(_food.X, _food.Y);
        Console.Write("F");

        foreach (var segment in _snake)
        {
            Console.SetCursorPosition(segment.X, segment.Y);
            Console.Write("O");
        }
    }

    private void GenerateFood()
    {
        var random = new Random();
        do
        {
            _food = new Point(random.Next(Width), random.Next(Height));
        } 
        while (_snake.Any(segment => segment.X == _food.X && segment.Y == _food.Y));
    }

    private void Input()
    {
        if (!Console.KeyAvailable)
        {
            return;
        }

        var key = Console.ReadKey(intercept: true).Key;
        switch (key)
        {
            case ConsoleKey.UpArrow:
                if (_direction != Direction.Down)
                {
                    _direction = Direction.Up;
                }

                break;

            case ConsoleKey.DownArrow:
                if (_direction != Direction.Up)
                {
                    _direction = Direction.Down;
                }

                break;

            case ConsoleKey.LeftArrow:
                if (_direction != Direction.Right)
                {
                    _direction = Direction.Left;
                }

                break;

            case ConsoleKey.RightArrow:
                if (_direction != Direction.Left)
                {
                    _direction = Direction.Right;
                }

                break;
        }
    }

    private void Move()
    {
        Point newHead = _head;

        switch (_direction)
        {
            case Direction.Up:
                newHead.Y--;
                break;

            case Direction.Down:
                newHead.Y++;
                break;

            case Direction.Left:
                newHead.X--;
                break;

            case Direction.Right:
                newHead.X++;
                break;
        }

        _head = newHead;
        _snake.Insert(0, newHead);

        // Check if the snake eats the food
        if (_head.X == _food.X && _head.Y == _food.Y)
        {
            _score++;
            GenerateFood();
        }
        else
        {
            // Remove the tail of the snake
            _snake.RemoveAt(_snake.Count - 1);
        }
    }
}