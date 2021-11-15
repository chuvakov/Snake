using Snake.Enams;
using Snake.Infrastructure;
using Snake.Models.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models.Map
{
    public static class MapGenerator
    {
        public static Map Generate(MapType type, int height, int width)
        {
            switch (type)
            {
                case MapType.Box:
                    return GenerateBox(height, width);                    

                default:
                    return null;
            }
        }

        private static Map GenerateBox(int height, int width)
        {   
            var upWall = new Line(0, 0, width, '#', LineType.Horizontal);
            var downWall = new Line(0, height, width, '#', LineType.Horizontal);

            var leftWall = new Line(0, 0, height, '#', LineType.Vertical);
            var rightWall = new Line(width, 0, height, '#', LineType.Vertical);

            var walls = new List<Figure>() { upWall, downWall, leftWall, rightWall };

            return new Map("Box", height, width, walls);
        }
    }
}
