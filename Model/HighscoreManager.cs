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
        StreamWriter Writer;

        public HighscoreManager(string filename)
        {
            HighscoreList = new List<Highscore>();
            Filename = filename;
            Writer = new StreamWriter(Filename);
        }

        /// <summary>
        /// Updates `HighscoreList` to reflect the txt file
        /// </summary>
        public void LoadList()
        {

            using (StreamReader reader = new StreamReader(Filename))
            {
                while (!reader.EndOfStream)
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
            Writer.WriteLine(hscore.Score + "," + hscore.Name);
            Writer.Flush();
        }
    }
}