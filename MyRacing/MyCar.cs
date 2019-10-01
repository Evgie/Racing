using Racing.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    public class MyCar : Figure
    {
        public delegate void MoveDelegate();

        public MyCar(char symbol, ConsoleColor color) :
            base(symbol, color)
        {
            this.InitializeState();
        }

        public event MoveDelegate MoveMyCarLeftEvent;

        public event MoveDelegate MoveMyCarRightEvent;

        protected override void InitializeState()
        {
            this.Nodes = new List<Node>()
            {
                new Node(3, 20),
                new Node(5, 20),
                new Node(4, 19),
                new Node(3, 18),
                new Node(4, 18),
                new Node(5, 18),
                new Node(4, 17)
            };
        }

        protected virtual void OnMoveMyCarLeftEvent()
        {
            this.MoveMyCarLeftEvent?.Invoke();
        }

        protected virtual void OnMoveMyCarRightEvent()
        {
            this.MoveMyCarRightEvent?.Invoke();
        }

        public override void Move(MoveDirection moveDirection)
        {
            switch (moveDirection)
            {
                case MoveDirection.Left:
                    this.OnMoveMyCarLeftEvent();
                    break;
                case MoveDirection.Right:
                    this.OnMoveMyCarRightEvent();
                    break;
            }
        }
    }
}