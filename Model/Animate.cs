﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public enum Direction { Up, Down, Left, Right}
    public abstract class Animate : WorldObject
    {
        public int Speed { get; set; }
        public int HitPoints { get; set; }
        public int Damage { get; set; }
        public bool Dead { get; set; }
        public int PointValue { get; set; }
        public Direction DirFacing { get; set; }


        public abstract int Attack();

        public void TakeDamage(int damage)
        {
            HitPoints -= damage;

            if (HitPoints <= 0)
            {
                Dead = true;
                GameController.Instance.Points += PointValue;
            }
        }
    }
}
