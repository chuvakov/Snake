using Snake.Enams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{
    //TODO: реализовать класс карты (что бы ее так же можно было рисовать с помощью метода draw)
    public class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public char Symbol { get; set; }

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
    }
}
