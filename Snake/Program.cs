using SnakeApp.Enams;
using SnakeApp.Infrastructure;
using SnakeApp.Models;
using SnakeApp.Models.Figures;
using SnakeApp.Models.Map;
using System;
using System.Threading;

namespace SnakeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LeaderBoard leaderBoard = new LeaderBoard();            

            Game game = new Game();
            //game.Play();
            game.Start();

            Console.ReadKey();
        }
    }
}
