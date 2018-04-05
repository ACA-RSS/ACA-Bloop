using System;
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
            for (int i = -1; i < 2; i++)
            {
                if (Spot.Row + i  == GameController.Instance.Player.Spot.Row || Spot.Column + i == GameController.Instance.Player.Spot.Column)
                {
                    Attack();
                    return;
                }
            }
            Move();
            }
        }
    }
