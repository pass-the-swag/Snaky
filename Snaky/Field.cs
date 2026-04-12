using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snaky
{
    public class Field
    {
        private ushort width;
        private ushort height;
        public List<List<char>> field = new List<List<char>>();

        public Field(ushort width = 10, ushort height = 10)
        {
            this.width = width;
            this.height = height;
            Render();//ренденр
        }

        public void Draw()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(field[i][j]);
                }
                Console.WriteLine();
            }
        }

        public void Render()
        {
            field.Clear();
            for (int i = 0; i < height; i++)
            {
                field.Add(new List<char>());
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || i == height - 1)
                    {
                        field[i].Add('#');
                    }
                    else if (j == 0 || j == width - 1)
                    {
                        field[i].Add('#');
                    }
                    else
                    {
                        field[i].Add(' ');
                    }
                }
            }
        }

        public bool IsValidPosition(Coordinate coord)
        {
            return coord.X > 0 && coord.X < width - 1 &&
                   coord.Y > 0 && coord.Y < height - 1;
        }

        public void UpdatePosition(Coordinate oldPos, Coordinate newPos, char symbol)
        {
            if (IsValidPosition(oldPos))
                field[oldPos.Y][oldPos.X] = ' ';
            if (IsValidPosition(newPos))
                field[newPos.Y][newPos.X] = symbol;
        }
    }
}
