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
        public StreamWriter writer = new StreamWriter("HighScoreList.txt");
        public StreamReader reader = new StreamReader("HighScoreList.txt");

        public int Score;
        public string Name;

        public Highscore(string nickname, int score)
        {
           Name = nickname;
           Score = score;
           AddToList(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="score"></param>
        /// <returns>index</returns>
        public int GetRank(int score)
        {
            return 0;
        }
        public void AddToList(Highscore highscore)
        {
            using (reader)
            {
                int score = 999999999;
                int rank = 0;
                while(score > highscore.Score)
                {
                        //read rank
                        reader.ReadLine();
                        //read score
                        score = Convert.ToInt32(reader.ReadLine());
                        //read nickname
                        reader.ReadLine();

                    
                }
            }
            using (writer)
            {
                writer.WriteLine("highscore.Rank.ToString()" + "\n" + highscore.Score.ToString() + "\n" + highscore.Name + "\n");
            }
        }
    }
}
