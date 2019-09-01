using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    public class Node
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Node(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Left()
        {
            this.X -= 3;
        }

        public void Right()
        {
            this.X += 3;
        }

        public void Up()
        {
            this.Y--;
        }

        public void Down()
        {
            this.Y++;
        }
    }
}
