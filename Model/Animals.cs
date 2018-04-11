﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public abstract class Animals : Animate
    {
        public double AttackSpeed { get; set; }
        public int AttackTime { get; set; }

        public override int Attack()
        {
            AttackTime++;

            if (AttackTime >= AttackSpeed)
            {
                AttackTime = 0;

                return Damage;
            }
            else return 0;
        }

        public abstract Location Move();

        public void CheckState()
        {
            for (int r = -1; r < 2; r++)
            {
                for (int c = -1; c < 2; c++)
                {
                    if (Spot.Row + r == GameController.Instance.Player.Spot.Row && Spot.Column + c == GameController.Instance.Player.Spot.Column)
                    {
                        GameController.Instance.Player.TakeDamage(Attack());
                        return;
                    }
                }
            }
            Move();
        }
    }
}
