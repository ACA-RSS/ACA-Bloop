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
        public static HighscoreManager Hm { get; set; }
        public List<Highscore> HighscoreList;
        public string Filename { get; set; }

        public HighscoreManager(string filename)
        {
            HighscoreList = new List<Highscore>();
            Filename = filename;
            Hm = this;
            //FileStream file = new FileStream(filename, FileMode.Open ,FileAccess.Write);
            //StreamWriter Writer = new StreamWriter(file);
        }

        /// <summary>
        /// Updates `HighscoreList` to reflect the txt file
        /// </summary>
        public void LoadList()
        {
            using(FileStream fstream = new FileStream(Filename, FileMode.Open, FileAccess.Read)) {
            using (StreamReader reader = new StreamReader(fstream))
            {
                    while (!reader.EndOfStream)
                    {
                        string scoreString = reader.ReadLine();
                        string[] scoreArray = scoreString.Split(',');
                        this.HighscoreList.Add(new Highscore(Convert.ToInt32(scoreArray[0]), scoreArray[1]));
                    }
                }
            }
        }
        /// <summary>
        /// Updates the txt file to reflect scores and names in `HighscoreList`
        /// </summary>
        public void SaveList(Highscore hscore)
        {
            using(StreamWriter writer = new StreamWriter(Filename))
            {
            foreach (Highscore highscore in this.HighscoreList)
                {
                    writer.WriteLine(highscore.Score + "," + highscore.Name);
                }
                writer.WriteLine(hscore.Score + "," + hscore.Name);
                writer.Flush();
            }
        }
    }
}