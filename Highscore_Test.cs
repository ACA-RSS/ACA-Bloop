 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twisted_Treeline.Model;

namespace Twisted_Treeline
{    
[TestClass]
    public class Highscore_Test
    {

        [TestMethod]
        public void Test_Highscores()
        {
            Highscore highscore = new Highscore("amy", 5609);

            string rank = Highscore.Reader.ReadLine();
            Assert.IsTrue(rank == "1");
            string score = Highscore.Reader.ReadLine();
            Assert.IsTrue(score == "5609");
            string nickname = Highscore.Reader.ReadLine();
            Assert.IsTrue(nickname == "amy");

            Highscore highscore2 = new Highscore("Loser", 9);

            string rank2 = Highscore.Reader.ReadLine();
            Assert.IsTrue(rank == "2");
            string score2 = Highscore.Reader.ReadLine();
            Assert.IsTrue(score == "9");
            string nickname2 = Highscore.Reader.ReadLine();
            Assert.IsTrue(nickname == "Loser");

        }

    }
}
