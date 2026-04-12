using Snaky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Snaky
{
    public class Snake
    {
        public int Id;
        public Coordinate Head;
        public Vector Vector;
        public int Length;
        public int Speed;
        public List<Coordinate> Body;

        public Snake(int id, Coordinate head, Vector vector, int length, int speed)
        {
            Id = id;
            Head = head;
            Vector = vector;
            Length = length;
            Speed = speed;
            Body = new List<Coordinate>();

            for (int i = 1; i <= length; i++)
            {
                Body.Add(new Coordinate(head.X, head.Y + i));
            }
        }

        public void Move()
        {
            Body.Insert(0, new Coordinate(Head.X, Head.Y));
            if (Body.Count > Length)
            {
                Body.RemoveAt(Body.Count - 1);
            }
            Coordinate vectorCoord = Vector.GetCoordinate();
            Head = new Coordinate(Head.X + vectorCoord.X, Head.Y + vectorCoord.Y);
        }

        public List<Coordinate> GetAllPositions()
        {
            List<Coordinate> all = new List<Coordinate> { Head };
            all.AddRange(Body);
            return all;
        }
    }
}