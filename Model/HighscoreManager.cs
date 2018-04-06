using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO

namespace Twisted_Treeline.Model
{
    class HighscoreManager
    {
        public List<Highscore> HighscoreList;

        public HighscoreManager()
        {
            HighscoreList = new List<Highscore>();
        }

        /// <summary>
        /// Updates `HighscoreList` to reflect the txt file
        /// </summary>
        public void LoadList()
        {

        }
        /// <summary>
        /// Updates the txt file to reflect scores and names in `HighscoreList`
        /// </summary>
        public void SaveList(Highscore score)
        {
            using (StreamWriter writer = new StreamWriter("HighScores.txt"))
            {
                writer.WriteLine(score.Score + "," + score.Name);
                writer.Flush();
            }
        }
    }
}
