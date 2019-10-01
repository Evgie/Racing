using Racing.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    public abstract class Figure
    {
        public List<Node> Nodes { get; set; }

        public char Symbol { get; }

        public ConsoleColor Color { get; set; }

        public Figure(char symbol, ConsoleColor color)
        {
            this.Symbol = symbol;
            this.Color = color;
        }

        protected abstract void InitializeState();

        public abstract void Move(MoveDirection moveDirection);

        public void EraseFigure()
        {
            foreach (var node in this.Nodes)
                if ((node.Y > 0 && node.Y < 21) && (!GameLogic.isPaused))
                {
                    Console.SetCursorPosition(node.X, node.Y);
                    Console.Write(" ");
                }
        }

        public void DrawFigure()
        {
            foreach (var node in this.Nodes)
                if ((node.Y > 0 && node.Y < 21) && (!GameLogic.isPaused))
                {
                    Console.SetCursorPosition(node.X, node.Y);
                    Console.ForegroundColor = this.Color;
                    Console.WriteLine(this.Symbol);
                }
        }
    }
}