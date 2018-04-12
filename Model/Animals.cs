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


        //This is an odd one. Every animal has an attack speed, which is how many timer ticks between
        //Each attack while the player is in an adjacent square. Its timer (Attack Time) starts at 0
        //And the animal does damage to the player when it reaches the attack speed, assuming the pllayer stays in
        //The adjacent square. This method returns an integer every time it's called, but returns 0
        //Unless the attack time is greater than the attack speed
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

        //NEEDS SOME HELP
        //Checks if the player is plus or minus one row, and then one space from the animal's space.
        //If so, it attacks (See Attack()); otherwise it calls the move method.
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
