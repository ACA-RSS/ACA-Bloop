using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Twisted_Treeline.Model
{
    class HighscoreManager
    {
        public List<Highscore> HighscoreList;
        public string Filename;

        public HighscoreManager(string filename)
        {
            HighscoreList = new List<Highscore>();
            Filename = filename;
        }

        /// <summary>
        /// Updates `HighscoreList` to reflect the txt file
        /// </summary>
        public void LoadList()
        {
            this.HighscoreList = new List<Highscore>();

            using (StreamReader reader = new StreamReader(Filename))
            {
                if (!reader.EndOfStream)
                {
                    string scoreString = reader.ReadLine();
                    string[] scoreArray = scoreString.Split(',');
                    this.HighscoreList.Add(new Highscore(Convert.ToInt32(scoreArray[0]), scoreArray[1]));
                }
            }
        }
        /// <summary>
        /// Updates the txt file to reflect scores and names in `HighscoreList`
        /// </summary>
        public void SaveList(Highscore hscore)
        {
            using (StreamWriter writer = new StreamWriter(Filename))
            {
                writer.WriteLine(hscore.Score + "," + hscore.Name);
                writer.Flush();
            }
        }
    }
}