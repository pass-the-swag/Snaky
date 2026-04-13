using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Snaky
{
    public class Food
    {
        public Coordinate Pos;
        private Random rnd = new Random();

        public Food(int maxWidth, int maxHeight)
        {
            Generate(maxWidth, maxHeight);
        }

        public void Generate(int maxWidth, int maxHeight)
        {
            Pos = new Coordinate(rnd.Next(1, maxWidth - 1), rnd.Next(1, maxHeight - 1));
        }
    }
}
