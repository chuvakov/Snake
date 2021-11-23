using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeApp.Models
{
    public class LeaderBoard
    {
        private readonly List<Player> _players = new List<Player>();

        public void Print()
        {
            Console.Clear();

            int num = 1;

            Console.WriteLine(Menu.GetDivider(46));

            string header = String.Format("| {0,5} | {1,10}       | {2,6}   | {3,4} |", "Место", "Ник", "Очки", "Дата");

            Console.WriteLine(header);
            Console.WriteLine($"|{Menu.GetDivider(44)}|");

            if (_players.Count == 0)
            {
                Console.WriteLine(String.Format("|{0,30}              |", "Нет результатов"));
                Console.WriteLine(Menu.GetDivider(46));
            }

            foreach (var player in _players)
            {
                Console.WriteLine($"{num++} {player.Name} {player.Points} {player.DateTime}");
            }
        }

        public void UpdatePlayerPoints(Player player)
        {
            Player existPlayer = _players.FirstOrDefault(x => x.Name == player.Name);

            if (existPlayer == null)
            {
                _players.Add(player);
            }
            else if (player.Points > existPlayer.Points)
            {
                existPlayer.Points = player.Points;
            }
        }
    }
}
