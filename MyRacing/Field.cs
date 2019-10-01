using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    public class Field
    {
        public int StartX { get; set; }

        public int StartY { get; set; }

        public int Width { get; }

        public int Height { get; }

        public Field()
        {
            this.StartX = 0;
            this.StartY = 0;
            this.Width = 12;
            this.Height = 22;
        }

        public void DrawField()
        {
            //
            // Drawing the maing field.
            //
            Console.SetCursorPosition(this.StartX + 1, this.StartY);
            for (int i = 0; i < this.Width - 2; i++)
                Console.Write("-");

            for (int j = 1; j < this.Height - 1; j++)
            {
                Console.SetCursorPosition(this.StartX, this.StartY + j);
                Console.WriteLine("|");
            }

            Console.SetCursorPosition(this.StartX + 1, this.StartY + this.Height - 1);
            for (int i = 0; i < this.Width - 2; i++)
                Console.Write("-");

            for (int j = 1; j < this.Height - 1; j++)
            {
                Console.SetCursorPosition(this.StartX + this.Width - 1, this.StartY + j);
                Console.WriteLine("|");
            }

            //
            // Drawing additional field.
            //
            Console.SetCursorPosition(this.Width - 1, this.StartY);
            for (int i = 0; i < 20; i++)
                Console.Write("-");

            Console.SetCursorPosition(this.Width - 1, this.StartY + this.Height - 1);
            for (int i = 0; i < 20; i++)
                Console.Write("-");

            for (int j = 1; j < this.Height - 1; j++)
            {
                Console.SetCursorPosition(this.Width - 1 + 20, this.StartY + j);
                Console.WriteLine("|");
            }
        }
    }
}