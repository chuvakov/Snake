using SnakeApp.Models;

namespace SnakeApp.Infrastructure
{
    public interface IFoodGenerator
    {
        /// <summary>
        /// Сгенерировать еду
        /// </summary>        
        Point Generate();
    }
}
