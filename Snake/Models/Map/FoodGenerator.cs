using SnakeApp.Infrastructure;
using System;

namespace SnakeApp.Models.Map
{
    public class FoodGenerator : IFoodGenerator
    {
        private readonly int _mapHeight;
        private readonly int _mapWidth;

        private readonly string _symbol;
        private readonly Random _random = new Random();

        private readonly ConsoleColor _color;

        public FoodGenerator(int mapHeight, int mapWidth, string symbol, ConsoleColor color)
        {
            _mapHeight = mapHeight;
            _mapWidth = mapWidth;
            _symbol = symbol;
            _color = color;
        }
              
        public Point Generate()
        {
            int x = _random.Next(2, _mapWidth - 2);
            int y = _random.Next(2, _mapHeight - 2);

            return new Point(x, y, _symbol, _color);
        }
    }
}
