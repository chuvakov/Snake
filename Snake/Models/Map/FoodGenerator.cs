using SnakeApp.Infrastructure;
using System;

namespace SnakeApp.Models.Map
{
    public class FoodGenerator : IFoodGenerator
    {
        private readonly IMap _map;
        
        private readonly string _symbol;
        private readonly Random _random = new Random();

        private readonly ConsoleColor _color;

        public FoodGenerator(IMap map, string symbol, ConsoleColor color)
        {
            _map = map;
            _symbol = symbol;
            _color = color;
        }
              
        public Point Generate()
        {
            int x = _random.Next(_map.X + 2, _map.X + _map.Width - 2);
            int y = _random.Next(_map.Y + 2, _map.Y + _map.Height - 2);

            return new Point(x, y, _symbol, _color);
        }
    }
}
