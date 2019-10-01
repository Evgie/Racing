using Racing.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Racing
{
    public class Renderer
    {
        private Field field;

        private MyCar myCar;

        private Border border;

        private Border borderHoles;

        private GameLogic gameLogic;

        private Display display;

        private List<OtherCar> listOfOtherCars;

        public void GetFigures()
        {
            FigureFabric figureFabric = new FigureFabric();
            this.field = figureFabric.GetField();
            this.myCar = figureFabric.GetMyCar('o', ConsoleColor.White);
            this.border = figureFabric.GetBorder('*', ConsoleColor.DarkMagenta);
            this.borderHoles = figureFabric.GetBorder(' ', ConsoleColor.DarkMagenta);
            this.gameLogic = figureFabric.GetGameLogic();
            this.display = figureFabric.GetDisplay();
        }

        public void DrawInitialView()
        {
            this.field.DrawField();
            this.myCar.DrawFigure();
            this.border.DrawFigure();
            this.borderHoles.DrawFigure();

            this.display.PrintStart();
            this.display.LaunchGame();
            
            Subscription subscriptionMyCar = new Subscription(myCar, this);
            Subscription subscriptionGameLogic = new Subscription(gameLogic);
        }

        public void MoveFigures()
        {
            this.listOfOtherCars = new List<OtherCar>();
            this.listOfOtherCars.Add(new OtherCar('*', ConsoleColor.Cyan));
            int flagOtherCar = 0;
            bool isCrash = false;
            while (GameLogic.isAlive)
                if (!GameLogic.isPaused)
                {
                    //
                    // MyCar move.
                    //
                    if (GameLogic.isFreezedLeft)
                        this.MoveMyCarLeft();
                    if (GameLogic.isFreezedRight)
                        this.MoveMyCarRight();
                    this.myCar.DrawFigure();

                    //
                    // Move Border.
                    //
                    this.border.DrawFigure();
                    this.borderHoles.Move(MoveDirection.Down);
                    this.borderHoles.DrawFigure();

                    //
                    // Move Enemies.
                    //
                    if (this.listOfOtherCars[0].Nodes[0].Y == 5 || this.listOfOtherCars[0].Nodes[0].Y == 14)
                        this.listOfOtherCars.Add(new OtherCar('*', ConsoleColor.Cyan));
                    if (this.listOfOtherCars[0].Nodes[0].Y < 21)
                        for (int i = 0; i < this.listOfOtherCars.Count; i++)
                        {
                            listOfOtherCars[i].Move(MoveDirection.Down);
                            if (IsCarsCrash(this.myCar, this.listOfOtherCars[i]))
                            {
                                this.ChangeLives();
                                flagOtherCar = i;
                                isCrash = true;
                            }
                        }
                    else
                        this.listOfOtherCars.Remove(this.listOfOtherCars[0]);
                    if (isCrash)
                    {
                        this.listOfOtherCars[flagOtherCar].EraseFigure();
                        this.listOfOtherCars.Remove(this.listOfOtherCars[flagOtherCar]);
                        this.CrashCars();
                        isCrash = false;
                    }

                    //
                    // Set Data
                    //
                    this.display.SetData();

                    Thread.Sleep(GameLogic.Speed);
                }
        }

        private void CrashCars()
        {
            var tempColor = this.myCar.Color;
            this.myCar.Color = ConsoleColor.Red;
            this.myCar.DrawFigure();
            Thread.Sleep(1000);
            this.myCar.Color = tempColor;
        }

        private void ChangeLives()
        {
            GameLogic.TakeLive();
            this.display.PrintLives();
        }

        private bool IsCarsCrash(MyCar myCar, OtherCar otherCar)
        {
            bool result = false;
            foreach (var car in myCar.Nodes)
                foreach (var otherCars in otherCar.Nodes)
                    if (car.X == otherCars.X && car.Y == otherCars.Y)
                        result = true;
            return result;
        }

        private void MoveMyCarLeft()
        {
            this.myCar.EraseFigure();
            foreach (var node in this.myCar.Nodes)
                node.Left();
            GameLogic.isFreezedLeft = false;
        }

        private void MoveMyCarRight()
        {
            this.myCar.EraseFigure();
            foreach (var node in this.myCar.Nodes)
                node.Right();
            GameLogic.isFreezedRight = false;
        }

        public void GameOver()
        {
            Console.Clear();
            this.display.PrintData();
            this.display.OutputData();
        }

        public void KeyControl()
        {
            ConsoleKeyInfo key;
            while (GameLogic.isAlive)
            {
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                            this.myCar.Move(MoveDirection.Left);
                        break;
                    case ConsoleKey.RightArrow:
                            this.myCar.Move(MoveDirection.Right);
                        break;
                    case ConsoleKey.UpArrow:
                        GameLogic.SetSpeed();
                        break;
                    case ConsoleKey.Spacebar:
                        this.gameLogic.SetPause();
                        break;
                }
            }
        }
    }
}
