using Snake.Enams;
using Snake.Models;
using Snake.Models.Figures;
using Snake.Models.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = MapGenerator.Generate(MapType.Box, 12, 30);
            map.Draw();
            map.GenerateFood();





            Console.ReadKey();
        }
    }
}
