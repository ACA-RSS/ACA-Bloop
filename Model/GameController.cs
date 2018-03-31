using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisted_Treeline.Model
{
    public class GameController
    {
        public string UserName { get; set; }

        public World Level {get; set;}

        public int Points {get; set;}

        public int Stars {get; set;}

        public Character Player { get; set; }

        public GameController(){
            Level = new World();
            Points = 0;
            Stars = 0;


        }

        public void isGameOver(){
            throw new NotImplementedException();
        }

        public void Save(){
            throw new NotImplementedException();
        }

        public void Load(){
            throw new NotImplementedException();
        }

        //Updates Model based on Timer and user actions
        public void Update()
        {
            throw new NotImplementedException();
        }


    }
}
