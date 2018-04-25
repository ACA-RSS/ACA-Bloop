//makes a highscore with name and score
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twisted_Treeline.View;
using Twisted_Treeline;
using System.IO;

namespace Twisted_Treeline.Model
{
    class Highscore
    {
        //the player's score
        public int Score;

        //the players name
        public string Name;

        public Highscore(int score, string nickname)
        {
            Name = nickname;
            Score = score;
        }

    }
}
