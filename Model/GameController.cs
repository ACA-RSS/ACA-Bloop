using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Twisted_Treeline.Model
{
    public class GameController
    {
        public string UserName { get; set; }

        public World Level {get; set;}

        public int Points {get; set;}

        public int Stars {get; set;}

        public Character Player { get; set; }

        private GameController(){
            Level = new World();
            Points = 0;
            Stars = 0;
        }

        public void isGameOver(){
            throw new NotImplementedException();
        }

        public void Reset()
        {
            Level = new World();
            Points = 0;
            Stars = 0;
        }

        public void Save(){
            string saveData = "TwistedTLine";
            //adds highscores at the beginning of the file

            //Saves the player info
            using (StreamWriter writer = new StreamWriter("TTLSave.txt"))
            {
                writer.WriteLine(saveData);
                writer.WriteLine(Player.Save());
                foreach (WorldObject obj in Level.WorldObj)
                {
                    writer.WriteLine(obj.Save());
                }
            }
                

        }

        public void Load(string fileName)
        {
            using (StreamReader rd = new StreamReader("TTLSave.txt"))
            {
                //splits the file based on new line characters 
                //uses each of the remaining parts of the array to create all the objects 
            }
        }

        //Updates Model based on Timer and user actions
        public void Update()
        {
            throw new NotImplementedException();
        }

        private static GameController instance = new GameController();
        public static GameController Instance
        {
            get { return instance; }
        }


    }
}
