using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Racing
{
    public class GameLogic
    {
        public static bool isPaused; // Shows if the Game is paused or not.

        public static bool isFreezedLeft; // Flag for drawing not to merge.

        public static bool isFreezedRight;

        public static bool isAlive; // Shows if Lives is more than 0.

        public static int Score;

        public static int Level;

        public static int Lives;

        public static int Speed;

        public static bool isGameOver;

        public delegate void PauseDelegate();

        public event PauseDelegate PauseEvent;

        protected virtual void OnPauseEvent()
        {
            this.PauseEvent?.Invoke();
        }

        public GameLogic()
        {
            isFreezedLeft = false;
            isFreezedRight = false;
            isPaused = false;
            isAlive = true;
            Lives = 3;
            Level = 0;
            Score = 0;
            Speed = 300;
            isGameOver = false;
        }

        public void SetPause()
        {
            this.OnPauseEvent();
        }

        public static void TakeLive()
        {
            Lives--;
            if (Lives == 0)
                isAlive = false;
        }

        public void StartGame()
        {
            Console.CursorVisible = false;
            Renderer renderer = new Renderer();
            renderer.GetFigures();
            renderer.DrawInitialView();

            Task[] tasks = new Task[2]
             {
                 new Task(() => renderer.KeyControl()),
                 new Task(() => renderer.MoveFigures())
             };
            foreach (var t in tasks)
                t.Start();

            Task.WaitAny(tasks);

            if (!isAlive || isGameOver)
                renderer.GameOver();
        }
        public static void SetNextLevel()
        {
            Level++;
        }

        public static void SetSpeed()
        {
            if (Speed > 50)
                Speed -= 10;
        }
    }
}
