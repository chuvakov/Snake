using SnakeApp.Enams;
using SnakeApp.Infrastructure;
using SnakeApp.Models;
using SnakeApp.Models.Figures;
using SnakeApp.Models.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IMapGenerator mapGenerator = new MapGenerator();
            IMap map = mapGenerator.Generate(MapType.Box, 12, 30);
            map.Draw();
            map.GenerateFood();

            
            var tail = new Point(5, 5, "■");
            var snake = new Snake(tail, 5, MoveDirection.Right);
            snake.Draw();



            Console.ReadKey();
        }
    }
}
