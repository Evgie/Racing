using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    public class Display
    {
        public void LaunchGame()
        {
            this.PrintStart();
            ConsoleKeyInfo key;
            while (true)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                this.PrintStart();
            }

            this.EraseStart();
            this.PrintData();
            this.OutputData();
        }

        public void SetData()
        {
            GameLogic.Score++;
            this.PrintScore();

            if (GameLogic.Score % 30 == 0)
            {
                GameLogic.SetNextLevel();
                GameLogic.SetSpeed();
                this.PrintLevel();
            }
        }

        public void PrintStart()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(15, 10);
            Console.WriteLine("Press <ENTER>");
            Console.SetCursorPosition(17, 11);
            Console.Write("to Start");
        }

        private void EraseStart()
        {
            Console.SetCursorPosition(15, 10);
            for (int i = 0; i < 13; i++)
                Console.Write(" ");
            Console.SetCursorPosition(17, 11);
            for (int i = 0; i < 10; i++)
                Console.Write(" ");
        }

        public void PrintData()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(15, 2);
            Console.WriteLine("Score: ");
            Console.SetCursorPosition(15, 10);
            Console.Write("Lives: ");
            Console.SetCursorPosition(15, 18);
            Console.Write("Level: ");
        }

        public void OutputData()
        {
            this.PrintScore();
            this.PrintLives();
            this.PrintLevel();
        }

        public void PrintScore()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(22, 2);
            Console.WriteLine(GameLogic.Score);
        }

        public void PrintLives()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(22, 10);
            Console.Write(GameLogic.Lives);
        }

        private void PrintLevel()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(22, 18);
            Console.Write(GameLogic.Level);
        }
    }
}
