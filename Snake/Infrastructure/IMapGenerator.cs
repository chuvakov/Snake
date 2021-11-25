using SnakeApp.Enams;
using SnakeApp.Models.Map;

namespace SnakeApp.Infrastructure
{
    public interface IMapGenerator
    {
        /// <summary>
        /// Сгенерировать карту
        /// </summary>        
        IMap Generate(MapType type, int height, int width, int x, int y);        
    }
}
