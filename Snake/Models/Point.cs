using Snake.Enams;
using Snake.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{
    //TODO: выделить нужные интерфейсы для каждого класса, где это необходимо.
    public class Point : IDrawable
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public char Symbol { get; private set; }

        public Point (int x, int y, char symbol)
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }        

        public void Move(MoveDirection direction, int count)
        {
            switch (direction)
            {
                case MoveDirection.Up:
                    Y -= count;
                    break;

                case MoveDirection.Right:
                    X += count;
                    break;

                case MoveDirection.Down:
                    Y += count;
                    break;

                case MoveDirection.Left:
                    X -= count;
                    break;  
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }

        public void Delete()
        {
            Symbol = ' ';
            Draw();
        }

        public bool IsHit(Point point)
        {
            return X == point.X && Y == point.Y;
        }

    }
}
