using System;

namespace SnakeApp.Infrastructure
{
    public interface ISnake : IFigure
    {
        /// <summary>
        /// Движение змейки
        /// </summary>        
        void Move();
        void HandleKey(ConsoleKey key);
        bool IsHitTail();
        bool EatFood(IPoint food);
    }
}
