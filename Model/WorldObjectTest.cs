using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twisted_Treeline.Model
{
    [TestClass]
    public class WorldObjectTest
    {

        [TestMethod]
        public void Animal_TakeDamage_Success()
        {
            Wolf wolfy = new Wolf();
            wolfy.TakeDamage(5);
            Assert.IsTrue(wolfy.HitPoints == 15);

        }

        [TestMethod]
        public void Animal_Death_Success()
        {
            Wolf wolfy = new Wolf();
            Assert.IsTrue(wolfy.Dead == false);
            wolfy.TakeDamage(5);
            Assert.IsTrue(wolfy.Dead == false);
            wolfy.TakeDamage(20);
            Assert.IsTrue(wolfy.Dead == true);

            Wolf fuzzy = new Wolf();
            Assert.IsTrue(fuzzy.Dead == false);
            wolfy.TakeDamage(20);
            Assert.IsTrue(fuzzy.Dead == true);
        }

        [TestMethod]
        public void Bear_Attack_Sucess()
        {
            Bear beary = new Bear();
            int firstHit = beary.Attack();
            int secondHit = beary.Attack();
            int thirdHit = beary.Attack();
            Assert.IsTrue(firstHit == 0);
            Assert.IsTrue(secondHit == 15);
            Assert.IsTrue(thirdHit == 0);

        }
    }
} 
