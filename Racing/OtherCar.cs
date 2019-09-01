using Racing.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Racing
{
    public class OtherCar : Figure
    {
        public OtherCar(char symbol, ConsoleColor color) :
            base(symbol, color)
        {
            this.InitializeState();
        }

        protected override void InitializeState()
        {
            Random random = new Random();
            int side = random.Next(1, 3);

            if (side == 1)
                this.Nodes = new List<Node>()
                {
                   new Node(3, -4),
                   new Node(5, -4),
                   new Node(4, -3),
                   new Node(3, -2),
                   new Node(4, -2),
                   new Node(5, -2),
                   new Node(4, -1)
                };
            if (side == 2)
                this.Nodes = new List<Node>()
                {
                   new Node(6, -4),
                   new Node(8, -4),
                   new Node(7, -3),
                   new Node(6, -2),
                   new Node(7, -2),
                   new Node(8, -2),
                   new Node(7, -1)
                };
        }

        public override void Move(MoveDirection moveDirection)
        {
            this.EraseFigure();
            foreach (var node in this.Nodes)
                node.Down();
            this.DrawFigure();
        }
    }
}