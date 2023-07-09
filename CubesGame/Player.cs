using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CubesGame
{
    internal class Player
    {
        public string PlayerName { get; set; }
        public int PlayerScore { get; set; }

        public Player(string Name)
        {
            this.PlayerName = Name;
            this.PlayerScore = 0;
        }
    }
}
