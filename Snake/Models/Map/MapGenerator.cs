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
        public IMap Generate(MapType type, int height, int width)
        {
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
            var upWall = new Line(0, 0, width, "#", LineType.Horizontal, ConsoleColor.DarkCyan);
            var downWall = new Line(0, height, width, "#", LineType.Horizontal, ConsoleColor.DarkCyan);

            var leftWall = new Line(0, 0, height, "#", LineType.Vertical, ConsoleColor.DarkCyan);
            var rightWall = new Line(width, 0, height, "#", LineType.Vertical, ConsoleColor.DarkCyan);

            var walls = new List<GameObject>() { upWall, downWall, leftWall, rightWall };

            return new Map("Box", height, width, walls);
        }
    }
}
