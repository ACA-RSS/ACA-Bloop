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
            gc.Save();
            gc.Reset();
            gc.Load("TTLSave.txt");
            Assert.IsTrue(gc.Level.Stars == 0);
            Assert.IsTrue(gc.Level.WorldObj.Count == 3);
            gc.Reset();

        }
        [TestMethod]
        public void Save_Succes()
        {
            GameController gc = GameController.Instance;
            gc.Reset();
            gc.Save();
            gc.Load("TTLSave.txt");
            Assert.IsTrue(gc.Player.HitPoints == 100);
            Assert.IsTrue(gc.Level.Stars == 0);

        }
        [TestMethod]
        public void Load_Dmg_Success()
        {
            GameController gc = GameController.Instance;
            gc.Reset();
            Wolf wolfy = new Wolf();
            wolfy.TakeDamage(5);
            gc.Level.WorldObj.Add(wolfy);
            gc.Save();
            gc.Reset();
            gc.Load("TTLSave.txt");
            Wolf coyote = gc.Level.WorldObj[1] as Wolf;
            Assert.IsTrue(coyote.HitPoints == 15);
        }
    }
}
