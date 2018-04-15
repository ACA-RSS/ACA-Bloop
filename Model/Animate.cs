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
        public int Speed { get; set; }
        public int Damage { get; set; }
        public int PointValue { get; set; }
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
        public void Die()
        {
            GameController.Instance.Level.WorldObj.Remove(this);
        }
    }
}
