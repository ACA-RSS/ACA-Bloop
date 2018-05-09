//abstract class for animals that move. Contains direction and action information and attack method
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public enum Direction { Up, Down, Left, Right }
    public abstract class Animate : Hittable
    {
        //How many timer ticks before animal moves
        public int Speed { get; set; }

        //how much damage the animal attack does to player
        public int Damage { get; set; }

        //how many points an animal is worth
        public int PointValue { get; set; }

        //the direction (left,right) the animal is facing
        public Direction DirFacing { get; set; }
        
        public abstract int Attack();
        

        //Removes the received attack from the object's hit points, and checks if it's hit points are at
        // or below 0. If so, it updates it's 'dead' attribute and adds it's points to the player's points
        public override void TakeDamage(int damage)
        {
            HitPoints -= damage;

            if (HitPoints <= 0)
            {
                Dead = true;
                GameController.Instance.Points += PointValue * (GameController.Instance.Difficulty);
                Die();
            }
        }

        //Removes the object from the World's list of objects
        public virtual void Die()
        {
            if (Type != "Character")
            {
                GameController.Instance.Level.WorldObj.Remove(this);
            }
        }
    }
}
