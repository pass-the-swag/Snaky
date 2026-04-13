using Snaky;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        ushort width = 20;
        ushort height = 10;
        Field field = new Field(width, height);
        Snake snake = new Snake(1, new Coordinate(10, 5), new Vector(), 3, 1);
        Food food = new Food(width, height);
        int score = 0;

        Console.WriteLine("start game");
        bool start = true;
        field.Render();

        while (start)
        {
            Console.Clear();
            field.Draw(snake,food);
            Console.WriteLine($"Score {score} | используй wasd для хотьбы, 1 для выхода");
            char move = Console.ReadKey().KeyChar;
            try
            {
                switch (move)
                {
                    case 'w':
                        snake.Vector.MoveUp();
                        break;
                    case 's':
                        snake.Vector.MoveDown();
                        break;
                    case 'a':
                        snake.Vector.MoveLeft();
                        break;
                    case 'd':
                        snake.Vector.MoveRight();
                        break;
                    case '1':
                        start = false;
                        continue;
                }
                snake.Move();
                if (snake.Head.X == food.Pos.X && snake.Head.Y == food.Pos.Y)
                {
                    snake.Eat();
                    snake.Length++;
                    score++;
                    food.Generate(width, height);
                }

                if (snake.Body.Any(b => b.X == snake.Head.X && b.Y == snake.Head.Y))
                {
                    Console.WriteLine("\nсама себя покусала q-q");
                    start = false;
                }
                if (!field.IsValidPosition(snake.Head))
                {
                    Console.WriteLine("\nстена!");
                    start = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nсюда никак {ex.Message}");
                Console.ReadKey();
            }
        }

        Console.WriteLine("THE END  финальный счет: " + score);
        Console.ReadKey();


    }
}