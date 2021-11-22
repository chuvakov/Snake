using SnakeApp.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace SnakeApp.Models.Map
{
    public class Map : IMap
    {
        public string Name { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public List<GameObject> Walls { get; private set; }

        public IPoint Food { get; private set; }

        private readonly FoodGenerator _foodGenerator;

        public Map(string name, int height, int width, List<GameObject> walls)
        {
            Name = name;
            Height = height;
            Width = width;
            Walls = walls;

            _foodGenerator = new FoodGenerator(Height, Width, "O");
        }

        public void Draw()
        {
            foreach (var wall in Walls)
            {
                wall.Draw();
            }

            Food.Draw();
        }
                
        public void GenerateFood()
        {
            Food = _foodGenerator.Generate();             
        }

        public bool IsHit(IGameObject figure)
        {
            return Walls.Any(x => x.IsHit(figure));
        }
    }
}
