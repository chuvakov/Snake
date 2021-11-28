using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeApp.Models
{
    public class LeaderBoard
    {
        public List<Player> Players { get; private set; } = new List<Player>();

        public void Print()
        {
            Console.Clear();

            int num = 1;

            Console.WriteLine(Menu.GetDivider(60));

            string header = String.Format("| {0,5} | {1,10}       | {2,6}   | {3,11}        |", "Место", "Ник", "Очки", "Дата");

            Console.WriteLine(header);
            Console.WriteLine($"|{Menu.GetDivider(58)}|");

            if (Players.Count == 0)
            {
                Console.WriteLine(String.Format("|{0,30}              |", "Нет результатов"));
                Console.WriteLine(Menu.GetDivider(46));
            }

            foreach (var player in Players.OrderByDescending(x => x.Points).Take(10))
            {
                Console.WriteLine(String.Format("| {0,3}   | {1,10}       | {2,6}   | {3,4} |", num++, player.Name, player.Points, player.DateTime));                
            }

            Console.WriteLine(Menu.GetDivider(60));
        }

        public void UpdatePlayerPoints(Player player)
        {
            Player existPlayer = Players.FirstOrDefault(x => x.Name == player.Name);

            if (existPlayer == null)
            {
                Players.Add(player);
            }
            else if (player.Points > existPlayer.Points)
            {
                existPlayer.Points = player.Points;
            }
        }
    }
}
