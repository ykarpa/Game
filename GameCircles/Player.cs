using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCircles
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime DateTime { get; set; }

        public Player() { }
        public Player(string name, int score)
        {
            Name = name; 
            Score = score;
        }

        public override string ToString()
        {
            return $"{Name}, {Score}";
        }
    }
}
