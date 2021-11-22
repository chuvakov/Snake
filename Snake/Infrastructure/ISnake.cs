using System;

namespace SnakeApp.Infrastructure
{
    public interface ISnake : IGameObject
    {
        /// <summary>
        /// Движение змейки
        /// </summary>        
        void Move();

        /// <summary>
        /// Нажатие клавиши
        /// </summary>
        void HandleKey(ConsoleKey key);

        /// <summary>
        /// Соприкосновение с хвостом
        /// </summary>        
        bool IsHitTail();

        /// <summary>
        /// Соприкосновение(съедание) еды
        /// </summary>        
        bool EatFood(IPoint food);
    }
}
