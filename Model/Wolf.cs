using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public class Wolf: Animals
    {
        public Wolf(){

            HitPoints = 20;
            AttackSpeed = 1;
            Speed = 5;
            Damage = 10;
            Dead = false;
        }

        public override int Attack() {

            throw NotImplemetedError();
            
        }

        public override Location Move(){

            throw NotImplemetedError();

        }

        public override TakeDamage(int damage){
            
            throw NotImplemetedError();
        }
    }
}
