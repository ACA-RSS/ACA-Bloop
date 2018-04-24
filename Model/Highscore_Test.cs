 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Twisted_Treeline.Model
{    
[TestClass]
    public class Highscore_Test
    {    

        [TestMethod]
        public void Test_Highscore()
        {
            HighscoreManager manager = new HighscoreManager("HighScores_Test.txt");
            Highscore highscore = new Highscore(5609, "amy");
            manager.SaveList(highscore);
            manager.LoadList();
            //test first highscore
            int score = manager.HighscoreList[0].Score;
            Assert.IsTrue(score == 5609);
            string nickname = manager.HighscoreList[0].Name;
            Assert.IsTrue(nickname == "amy");

        }
        [TestMethod]
        public void Test_Multiple_Highscores()
        {
            HighscoreManager manager2 = new HighscoreManager("HighScores1_Test.txt");
            manager2.LoadList();
            Highscore highscore = new Highscore(5609, "amy");
            manager2.SaveList(highscore);
            Highscore highscore2 = new Highscore(60, "2ndplace");
            manager2.SaveList(highscore2);
            manager2.LoadList();
            int score2 = manager2.HighscoreList[1].Score;
            Assert.IsTrue(score2 == 60);
            string nickname2 = manager2.HighscoreList[1].Name;
            Assert.IsTrue(nickname2 == "2ndplace");
        }

    }
}
