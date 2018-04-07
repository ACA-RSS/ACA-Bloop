using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Threading;

namespace Twisted_Treeline.Model
{
    public class GameController
    {
        public string UserName { get; set; }

        public World Level {get; set;}

        public int Points {get; set;}

        public int Stars {get; set;}

        public Character Player { get; set; }

        DispatcherTimer Timer;

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

            Timer = new DispatcherTimer();
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(100000);
            Timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            foreach (WorldObject obj in GameController.Instance.Level.WorldObj)
            {
                if (obj.Type == "Animals")
                {
                    Animals a = obj as Animals;
                    a.CheckState();
                }

                GameController.Instance.Level.Squares[obj.Spot.Row, obj.Spot.Column] = obj;
            }
        }

        public void SetUpLevelOne()
        {
            Player = new Character();
            Player.Stick = new Stick(5);

            Bear fuzzy = new Bear() { Spot = new Location { Row = 1, Column = 1 } };
            Bear wuzzy = new Bear() { Spot = new Location { Row = 1, Column = 1 } };
            Bear buzzy = new Bear() { Spot = new Location { Row = 1, Column = 1 } };

            GameController.Instance.Level.WorldObj.Add(fuzzy);
            GameController.Instance.Level.WorldObj.Add(wuzzy);
            GameController.Instance.Level.WorldObj.Add(buzzy);




        }

        public void Save(){
            string saveData = "TwistedTLine";
            //adds highscores at the beginning of the file

            //Saves the player info
            using (StreamWriter writer = new StreamWriter("TTLSave.txt"))
            {
                writer.WriteLine(saveData);
                writer.WriteLine(Player.Serialize());
                foreach (WorldObject obj in Level.WorldObj)
                {
                    writer.WriteLine(obj.Serialize());
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
