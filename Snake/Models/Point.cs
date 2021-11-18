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

        /// <summary>
        /// Двигает указатель
        /// </summary>
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

        /// <summary>
        /// Отрисовывание точек(символа)
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }

        /// <summary>
        /// Затирание точки(символа)
        /// </summary>
        public void Delete()
        {
            Symbol = " ";
            Draw();
        }
        /// <summary>
        /// Проверка соприкосновение точек
        /// </summary>
        public bool IsHit(IPoint point)
        {
            return X == point.X && Y == point.Y;
        }
        /// <summary>
        /// Клонирование точки
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Point(X, Y, Symbol);
        }
    }
}
