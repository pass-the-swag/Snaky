using Snaky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snaky
{
    public class Vector
    {
        private Coordinate coordinate;

        public Vector()
        {
            this.coordinate = new Coordinate(0, 1);
        }

        public Vector(Coordinate coord)
        {
            this.coordinate = coord;
        }

        public Coordinate GetCoordinate()
        {
            return coordinate;
        }

        public override string ToString()
        {
            return coordinate.ToString();
        }

        public void MoveUp()
        {
            if (coordinate.Y != 1)
            {
                coordinate = new Coordinate(0, -1);
            }
            else
            {
                throw new Exception("нельзя в обратку");
            }
        }

        public void MoveDown()
        {
            if (coordinate.Y != -1)
            {
                coordinate = new Coordinate(0, 1);
            }
            else
            {
                throw new Exception("нельзя в обратку");
            }
        }

        public void MoveLeft()
        {
            if (coordinate.X != 1)
            {
                coordinate = new Coordinate(-1, 0);
            }
            else
            {
                throw new Exception("нельзя в обратку");
            }
        }

        public void MoveRight()
        {
            if (coordinate.X != -1)
            {
                coordinate = new Coordinate(1, 0);
            }
            else
            {
                throw new Exception("нельзя в обратку");
            }
        }
    }
}