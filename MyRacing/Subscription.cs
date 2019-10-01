using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    public class Subscription
    {
        private readonly MyCar myCar;

        private readonly GameLogic gameLogic;

        private readonly Renderer renderer;

        public Subscription(MyCar myCar, Renderer renderer)
        {
            this.renderer = renderer;
            this.myCar = myCar;
            this.myCar.MoveMyCarLeftEvent += MoveMyCarLeft;
            this.myCar.MoveMyCarRightEvent += MoveMyCarRight;
        }

        public Subscription(GameLogic gameLogic)
        {
            this.gameLogic = gameLogic;
            this.gameLogic.PauseEvent += PauseGame;
        }

        public void MoveMyCarLeft()
        {
            if (this.myCar.Nodes[0].X == 6)
            {
                GameLogic.isFreezedLeft = true;
            }
        }

        public void MoveMyCarRight()
        {
            if (this.myCar.Nodes[0].X == 3)
            {
                GameLogic.isFreezedRight = true;
            }
        }

        public void PauseGame()
        {
            GameLogic.isPaused = !GameLogic.isPaused;
        }
    }
}