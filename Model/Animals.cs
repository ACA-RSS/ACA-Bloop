//Contains all code for the Base Animals class; derives from Animate

//abstract class for all animals. contains attack and move information and methods
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace Twisted_Treeline.Model
{
    public abstract class Animals : Animate
    {
        //Number of timer ticks between each attack
        public double AttackSpeed { get; set; }

        //Number of timer ticks since last attack
        public int AttackTime { get; set; }

        //number of timer ticks for move
        public double MoveTime { get; set; }

        //holds the name of the sound file to be played on animal attack
        public Stream Sound { get; set; }

        //Image that is shown while the animals is attacking
        public string AttackImage { get; set; }


        //Every animal has an attack speed, which is how many timer ticks between
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

                Image = AttackImage;
                GameController.Instance.CurrentSound = Sound;
                return Damage;
                
            }
            else return 0;
        }

        //Moves the animal every `speed` calls
        public void checkMove()
        {
            MoveTime++;

            if (MoveTime >= Speed)
            {
                MoveTime = 0;
                Move();
            }
        }

        //defines how the animal will move and returns the location of the next square to move to
        public abstract Location Move();

        //animal attacks player if in range and checks if move requirements are met
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
            checkMove();
        }
    }
}
