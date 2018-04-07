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
        public int Score;
        public string Name;

        public Highscore(int score, string nickname)
        {
            Name = nickname;
            Score = score;
        }

        //private object GetRank()
        //{
        //    int max = 0;
        //    foreach (Highscore hscore in manager.HighscoreList)
        //    {
        //        if (hscore.Score> max)
        //        {
        //            max = hscore.Score;
        //        }
        //    }
        //    return max;
        //}

        /// <summary>
        /// Searches Highscores for the location to insert `score`
        /// </summary>
        /// <param name="score"></param>
        /// <returns>index in Highscores where to insert Highscore with score `score`. -1 if less than all scores</returns>

    }
}
