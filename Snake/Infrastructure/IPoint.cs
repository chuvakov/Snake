using SnakeApp.Enams;
using System;

namespace SnakeApp.Infrastructure
{
    public interface IPoint : IDrawable, ICloneable
    {
        int X { get; }
        int Y { get; }

        string Symbol { get; set; }

        void Move(MoveDirection direction, int count);

        void Delete();

        bool IsHit(IPoint point);

    }
}
