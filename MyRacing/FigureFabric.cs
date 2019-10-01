using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    public class FigureFabric
    {
        public Field GetField()
        {
            return new Field();
        }

        public MyCar GetMyCar(char symbol, ConsoleColor color)
        {
            return new MyCar(symbol, color);
        }

        public Border GetBorder(char symbol, ConsoleColor color)
        {
            return new Border(symbol, color);
        }

        public GameLogic GetGameLogic()
        {
            return new GameLogic();
        }

        public Display GetDisplay()
        {
            return new Display();
        }
    }
}
