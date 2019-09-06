using Racing.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Racing
{
    public class Border : Figure
    {
        public Border(char symbol, ConsoleColor color) :
            base(symbol, color)
        {
            if (symbol == ' ')
                this.InitializeStateHoles();
            else
                this.InitializeState();
        }

        protected override void InitializeState()
        {
            this.Nodes = new List<Node>();
            for (int i = 1; i <= 20; i++)
            {
                this.Nodes.Add(new Node(1, i));
                this.Nodes.Add(new Node(10, i));
            }
        }

        protected void InitializeStateHoles()
        {
            this.Nodes = new List<Node>();
            for (int i = 1; i <= 20; i++)
                if (i % 4 == 0)
                {
                    this.Nodes.Add(new Node(1, i));
                    this.Nodes.Add(new Node(10, i));
                }
        }
        
        public override void Move(MoveDirection moveDirection)
        {
            foreach (var node in this.Nodes)
            {
                node.Down();
                if (node.Y > 20)
                    node.Y = 1;
            }
        }
    }
}