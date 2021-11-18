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
        /// <summary>
        /// Генерирует карту по типу (шаблону)
        /// </summary>        
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

        /// <summary>
        /// Генерирует карту типа Box
        /// </summary>        
        private IMap GenerateBox(int height, int width)
        {   
            var upWall = new Line(0, 0, width, "#", LineType.Horizontal);
            var downWall = new Line(0, height, width, "#", LineType.Horizontal);

            var leftWall = new Line(0, 0, height, "#", LineType.Vertical);
            var rightWall = new Line(width, 0, height, "#", LineType.Vertical);

            var walls = new List<Figure>() { upWall, downWall, leftWall, rightWall };

            return new Map("Box", height, width, walls);
        }
    }
}
