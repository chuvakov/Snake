using SnakeApp.Enams;
using SnakeApp.Infrastructure;
using System;

namespace SnakeApp.Models
{
    public class Point : IPoint
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public string Symbol { get; set; }

        public Point(int x, int y, string symbol)
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
            Symbol = " ";
            Draw();
        }
        
        public bool IsHit(IPoint point)
        {
            return X == point.X && Y == point.Y;
        }
        
        public object Clone()
        {
            return new Point(X, Y, Symbol);
        }
    }
}
