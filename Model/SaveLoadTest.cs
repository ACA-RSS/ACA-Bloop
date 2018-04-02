﻿using System;
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
            GameController gc = new GameController();
            gc.Load("TTLSave.txt");
            Assert.IsTrue(gc.Player.HitPoints == 100);
            Assert.IsTrue(gc.Stars == 0);

        }
    }
}
