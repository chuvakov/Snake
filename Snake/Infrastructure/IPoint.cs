using SnakeApp.Enams;
using System;

namespace SnakeApp.Infrastructure
{
    public interface IPoint : IDrawable, ICloneable
    {
        int X { get; }
        int Y { get; }

        ConsoleColor Color { get; set; }

        string Symbol { get; set; }

        /// <summary>
        /// Передвинуть точку
        /// </summary>        
        void Move(MoveDirection direction, int count);

        /// <summary>
        /// Затереть(удалить) точку
        /// </summary>
        void Delete();

        /// <summary>
        /// Соприкосновение точки
        /// </summary>        
        bool IsHit(IPoint point);

    }
}
