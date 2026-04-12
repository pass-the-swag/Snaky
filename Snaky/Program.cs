using Snaky;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Field field = new Field(20, 10);
        Snake snake = new Snake(1, new Coordinate(10, 5), new Vector(), 3, 1);

        Console.WriteLine("start game");
        bool start = true;
        field.Render();//очищаем поле

        while (start)
        {
            Console.Clear();
            field.Render();
            if (field.IsValidPosition(snake.Head))
            {
                field.field[snake.Head.Y][snake.Head.X] = '@';
            }

            foreach (var segment in snake.Body)
            {
                if (field.IsValidPosition(segment))
                {
                    field.field[segment.Y][segment.X] = 'o';
                }
            }

            field.Draw();
            Console.WriteLine($"Score: {snake.Length - 3} | Use WASD to move, 1 to quit");

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
                if (!field.IsValidPosition(snake.Head))
                {
                    Console.WriteLine("въехалось в стену (");
                    start = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"сюда нельзя: {ex.Message}");
            }
        }

        Console.WriteLine("THE END");
    }
}