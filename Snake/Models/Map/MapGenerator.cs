using SnakeApp.Enams;
using SnakeApp.Infrastructure;
using SnakeApp.Models.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp.Models.Map
{
    public class MapGenerator : IMapGenerator
    {
        private int _x;
        private int _y;

        public IMap Generate(MapType type, int height, int width, int x, int y)
        {
            _x = x;
            _y = y;

            IMap map = null;

            switch (type)
            {
                case MapType.Box:
                    map = GenerateBox(height, width);
                    break;
            }            

            map.GenerateFood();

            return map;
        }
                       
        private IMap GenerateBox(int height, int width)
        {   
            var upWall = new Line(_x, _y, width, "#", LineType.Horizontal, ConsoleColor.DarkCyan);
            var downWall = new Line(_x, _y + height, width, "#", LineType.Horizontal, ConsoleColor.DarkCyan);

            var leftWall = new Line(_x, _y, height, "#", LineType.Vertical, ConsoleColor.DarkCyan);
            var rightWall = new Line(_x + width, _y, height, "#", LineType.Vertical, ConsoleColor.DarkCyan);

            var walls = new List<GameObject>() { upWall, downWall, leftWall, rightWall };

            return new Map("Box", _x, _y, height, width, walls);
        }
    }
}
