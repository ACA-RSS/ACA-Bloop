using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Updates the txt file to reflect scores, names and ranks in `HighscoreList`
        /// </summary>
        public void SaveList()
        {
            this.HighscoreList
        }
    }
}
