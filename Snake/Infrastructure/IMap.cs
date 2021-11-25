using System.Collections.Generic;

namespace SnakeApp.Infrastructure
{
    public interface IMap : IDrawable
    {
        int X { get; }
        int Y { get; }
        
        int Height { get; }
        int Width { get; }

        string Name { get; }
        List<GameObject> Walls { get; }
        IPoint Food { get; }

        /// <summary>
        /// Соприкосновение с картой
        /// </summary>        
        bool IsHit(IGameObject figure);

        /// <summary>
        /// Сгенерировать еду
        /// </summary>
        void GenerateFood();
    }
}
