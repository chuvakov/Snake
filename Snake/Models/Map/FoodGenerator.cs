using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models.Map
{
    public class FoodGenerator
    {
        private readonly int _mapHeight;
        private readonly int _mapWidth;

        private readonly char _symbol;
        private readonly Random _random = new Random();

        public FoodGenerator(int mapHeight, int mapWidth, char symbol)
        {
            _mapHeight = mapHeight;
            _mapWidth = mapWidth;
            _symbol = symbol;
        }

        public Point Generate()
        {
            int x = _random.Next(2, _mapWidth - 2);
            int y = _random.Next(2, _mapHeight - 2);

            return new Point(x, y, _symbol);
        }
    }
}
