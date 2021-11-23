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
        private readonly Menu _menu;

        private IMap _map;
        private ISnake _snake;

        public Player CurentPlayer { get; private set; }
        public MapType SelectedMapType { get; set; } = MapType.Box;
        public LeaderBoard LeaderBoard { get; private set; }

        public Game()
        {
            _mapGenerator = new MapGenerator();
            _menu = new Menu(this);

            CurentPlayer = new Player("Player"); //TODO: Тянуть ник из БД
            LeaderBoard = new LeaderBoard();    //TODO: Тянуть из БД
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
                    CurentPlayer.Points += 100;
                    _map.GenerateFood();
                }

                _snake.Move();
                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    _snake.HandleKey(Console.ReadKey().Key);
                }
            }

            LeaderBoard.UpdatePlayerPoints(CurentPlayer);
        }

        private void InitGame()
        { 
            Console.SetWindowSize(91, 31);
            Console.Clear();

            CurentPlayer.Points = 0;

            InitMap();
            InitSnake();
        }

        private void InitSnake()
        {
            var tail = new Point(5, 5, "*", ConsoleColor.Green);
            _snake = new Snake(tail, 5, MoveDirection.Right);
            _snake.Draw();
        }

        private void InitMap()
        {
            _map = _mapGenerator.Generate(SelectedMapType, 30, 90);
            _map.Draw();            
        }

        public void Start()
        {    
            while (true)
            {
                _menu.Print();
                _menu.ScanMenuItem();
            }
        }

        public void ChangePlayerNickname(string nickname)
        {
            CurentPlayer.Name = nickname;
        }
    }
}
