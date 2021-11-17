using SnakeApp.Enams;
using SnakeApp.Models.Map;

namespace SnakeApp.Infrastructure
{
    public interface IMapGenerator
    {
        Map Generate(MapType type, int height, int width);
    }
}
