﻿using SnakeApp.Infrastructure;
using System;
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

        public int X { get; private set; }
        public int Y { get; private set; }

        private readonly FoodGenerator _foodGenerator;

        public Map(string name, int x, int y, int height, int width, List<GameObject> walls)
        {
            Name = name;

            X = x;
            Y = y;

            Height = height;
            Width = width;
            Walls = walls;

            _foodGenerator = new FoodGenerator(this, "O", ConsoleColor.DarkRed);
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
            Food.Draw();
        }

        public bool IsHit(IGameObject figure)
        {
            return Walls.Any(x => x.IsHit(figure));
        }
    }
}
