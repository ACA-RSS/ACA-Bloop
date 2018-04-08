 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twisted_Treeline.Model
{    
[TestClass]
    public class Highscore_Test
    {
            HighscoreManager manager = new HighscoreManager("HighScores_Test.txt");

        [TestMethod]
        public void Test_Highscore()
        {
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
            Highscore highscore = new Highscore(5609, "amy");
            manager.SaveList(highscore);
            Highscore highscore2 = new Highscore(60, "2ndplace");
            manager.SaveList(highscore2);
            manager.LoadList();
            int score2 = manager.HighscoreList[1].Score;
            Assert.IsTrue(score2 == 60);
            string nickname2 = manager.HighscoreList[1].Name;
            Assert.IsTrue(nickname2 == "2ndplace");


        }

    }
}
