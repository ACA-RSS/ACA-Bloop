using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twisted_Treeline.Model
{
    [TestClass]
    public class SaveLoadTest
    {

        [TestMethod]
        public void Load_Succes()
        {
            GameController gc = GameController.Instance;
            gc.Reset();
            Bear b = new Bear();
            gc.Level.WorldObj.Add(b);
            Squirrel s = new Squirrel();
            gc.Level.WorldObj.Add(s);
            gc.Save("TTL_Test.txt");
            gc.Reset();
            gc.Load("TTL_Test.txt");
            Assert.IsTrue(gc.Level.Stars == 0);
            Assert.IsTrue(gc.Level.WorldObj.Count == 2);
            gc.Reset();

        }
        [TestMethod]
        public void Save_Succes()
        {
            GameController gc2 = GameController.Instance;
            gc2.Reset();
            gc2.Save("TTL_Test2.txt");
            gc2.Load("TTL_Test2.txt");
            Assert.IsTrue(gc2.Player.HitPoints == 100);
            Assert.IsTrue(gc2.Level.Stars == 0);

        }
        [TestMethod]
        public void Load_Dmg_Success()
        {
            GameController gc3 = GameController.Instance;
            gc3.Reset();
            Wolf wolfy = new Wolf();
            wolfy.TakeDamage(5);
            gc3.Level.WorldObj.Add(wolfy);
            gc3.Save("TTL_Test3.txt");
            gc3.Reset();
            gc3.Load("TTL_Test3.txt");
            Wolf coyote = gc3.Level.WorldObj[0] as Wolf;
            Assert.IsTrue(coyote.HitPoints == 15);
        }
    }
}
