using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public DateTime DateTime { get; set; }

        public Player(string name)
        {
            Name = name;
        }
    }
}
