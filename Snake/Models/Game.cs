using SnakeApp.Enams;
using SnakeApp.Infrastructure;
using SnakeApp.Models.Figures;
using SnakeApp.Models.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeApp.Models
{
    public class Game
    {
        private readonly IMapGenerator _mapGenerator;
        private IMap _map;
        private ISnake _snake;

        public Game()
        {
            _mapGenerator = new MapGenerator();
        }

        public void Play()
        {
            InitGame();

            while (true)
            {
                if (_map.IsHit(_snake) || _snake.IsHitTail())
                {
                    break;
                }

                if (_snake.EatFood(_map.Food))
                {
                    _map.GenerateFood();
                }

                _snake.Move();
                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    _snake.HandleKey(Console.ReadKey().Key);
                }
            }
        }

        private void InitGame()
        {
            InitMap();
            InitSnake();
        }

        private void InitSnake()
        {
            var tail = new Point(5, 5, "*");
            _snake = new Snake(tail, 5, MoveDirection.Right);
            _snake.Draw();
        }

        private void InitMap()
        {
            _map = _mapGenerator.Generate(MapType.Box, 30, 90);
            _map.Draw();            
        }
    }
}
