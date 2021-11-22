using System;
using System.Collections.Generic;

namespace SnakeApp.Models
{
    public class LeaderBoard
    {
        public List<Player> Players { get; set; } = new List<Player>();



        public void Print()
        {
            int num = 1;

            Console.WriteLine(Menu.GetDivider(46));

            string header = String.Format("| {0,5} | {1,10}       | {2,6}   | {3,4} |", "Место", "Ник", "Очки", "Дата");

            Console.WriteLine(header);
            Console.WriteLine($"|{Menu.GetDivider(44)}|");

            if (Players.Count == 0)
            {
                Console.WriteLine(String.Format("|{0,30}              |", "Нет результатов"));
                Console.WriteLine(Menu.GetDivider(46));
            }

            foreach (var player in Players)
            {
                Console.WriteLine($"{num++} {player.Name} {player.Point} {player.DateTime}");
            }
        }

    }
}
