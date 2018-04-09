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

        public int Difficulty { get; set; }

        public World Level { get; set; }

        public int Points { get; set; }


        public Character Player { get; set; }

        public DispatcherTimer Timer;

        private GameController()
        {
            Level = new World();
            Points = 0;
            Difficulty = 1;
            Player = new Character();
        }

        public bool isGameOver()
        {
            if (Instance.Player.Dead)
            {
                return true;
            }
            else if (Instance.Level.Stars == 3 && Instance.Player.Spot.Column == 0 && Instance.Player.Spot.Row == 13)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void Reset()
        {
            Level = new World();
            Points = 0;

            Timer = new DispatcherTimer();
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(100000);
        }

        private void Timer_Tick(object sender, object e)
        {
            Update();
        }

        public void SetUpLevelOne()
        {
            Player = new Character()
            {
                Stick = new Stick(5),
                Spot = new Location { Row = 12, Column = 0 }
            };


            Bear fuzzy = new Bear() { Spot = new Location { Row = 4, Column = 5 } };
            Bear wuzzy = new Bear() { Spot = new Location { Row = 7, Column = 15 } };
            Bear buzzy = new Bear() { Spot = new Location { Row = 10, Column = 3 } };

            Instance.Level.WorldObj.Add(fuzzy);
            Instance.Level.WorldObj.Add(wuzzy);
            Instance.Level.WorldObj.Add(buzzy);

            Star glitter = new Star() { Spot = new Location { Row = 4, Column = 4 } };
            Star gleam = new Star() { Spot = new Location { Row = 12, Column = 4 } };
            Star glow = new Star() { Spot = new Location { Row = 9, Column = 16 } };

            Instance.Level.WorldObj.Add(glitter);
            Instance.Level.WorldObj.Add(gleam);
            Instance.Level.WorldObj.Add(glow);

            Wolf wolfy = new Wolf() { Spot = new Location { Row = 3, Column = 10 } };
            Wolf bitey = new Wolf() { Spot = new Location { Row = 6, Column = 16 } };
            Wolf growly = new Wolf() { Spot = new Location { Row = 13, Column = 6 } };

            Instance.Level.WorldObj.Add(wolfy);
            Instance.Level.WorldObj.Add(bitey);
            Instance.Level.WorldObj.Add(growly);

            //Swirl in top left
            Wall.WallBuilder(3, 3, 2, "Horz");
            Wall.WallBuilder(4, 3, 1, "Vert");
            Wall.WallBuilder(5, 4, 3, "Horz");
            Wall.WallBuilder(1, 7, 3, "Vert");
            Wall.WallBuilder(1, 1, 5, "Horz");
            Wall.WallBuilder(2, 1, 6, "Vert");
            Wall.WallBuilder(7, 2, 7, "Horz");
            Wall.WallBuilder(6, 0, 8, "Vert");

            //Right Side

            Wall.WallBuilder(1, 11, 8, "Horz");
            Wall.WallBuilder(2, 11, 10, "Vert");
            Wall.WallBuilder(10, 13, 2, "Vert");
            Wall.WallBuilder(12, 14, 5, "Horz");
            Wall.WallBuilder(3, 19, 8, "Vert");
            Wall.WallBuilder(3, 13, 5, "Horz");
            Wall.WallBuilder(4, 13, 5, "Vert");
            Wall.WallBuilder(8, 14, 1, "Horz");
            Wall.WallBuilder(9, 15, 1, "Vert");
            Wall.WallBuilder(10, 16, 1, "Horz");
            Wall.WallBuilder(5, 17, 4, "Vert");
            Wall.WallBuilder(5, 16, 1, "Horz");
            Wall.WallBuilder(6, 15, 0, "Vert");

            //Bottom Left
            Wall.WallBuilder(11, 9, 2, "Vert");
            Wall.WallBuilder(10, 7, 2, "Vert");
            Wall.WallBuilder(9, 1, 4, "Vert");
            Wall.WallBuilder(9, 2, 7, "Horz");
            Wall.WallBuilder(11, 5, 2, "Vert");
            Wall.WallBuilder(11, 3, 1, "Horz");
            Wall.WallBuilder(12, 3, 0, "Vert");
        }

        public void Save()
        {
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
            using (StreamReader sr = new StreamReader("TTLSave.txt"))
            {
                string curLine;
                string saveTitle = sr.ReadLine();
                if(saveTitle != "TwistedTLine")
                {
                    Environment.Exit(1);
                }
                //check to make sure it isnt the last line in the file
                while (sr.Peek() >= 0)
                {
                    curLine = sr.ReadLine();
                    string type = curLine.Substring(0, 3);
                    WorldObject w;
                    switch (type)
                    {
                        case "Bear":
                            {
                                Bear b = new Bear();
                                w =  b.Deserialize(curLine);
                                Instance.Level.WorldObj.Add(w);
                                break;
                            }
                        case "Wolf":
                            {
                                Wolf coyote = new Wolf();
                                w = coyote.Deserialize(curLine);
                                Instance.Level.WorldObj.Add(w);
                                break;
                            }
                        case "Squi":
                            {
                                Squirrel scrat = new Squirrel();
                                w = scrat.Deserialize(curLine);
                                Instance.Level.WorldObj.Add(w);
                                break;
                            }
                        case "Char":
                            {
                                Character alcatraz = new Character();
                                w = alcatraz.Deserialize(curLine);
                                Instance.Level.WorldObj.Add(w);
                                break;
                            }
                        case "Wall":
                            {
                                Wall china = new Wall();
                                w = china.Deserialize(curLine);
                                Instance.Level.WorldObj.Add(w);
                                break;
                            }
                        case "Stum":
                            {
                                Stump thump = new Stump();
                                w = thump.Deserialize(curLine);
                                Instance.Level.WorldObj.Add(w);
                                break;
                            }
                        case "Stic":
                            {
                                Stick discipline = new Stick();
                                w = discipline.Deserialize(curLine);
                                Instance.Level.WorldObj.Add(w);
                                break;
                            }
                    }

                }
            }
        }

        //Updates Model based on Timer and user actions
        public void Update()
        {
            foreach (WorldObject obj in Instance.Level.Squares)
            {
                Instance.Level.Squares[obj.Spot.Row, obj.Spot.Column] = null;
            }

            foreach (WorldObject obj in Instance.Level.WorldObj)
            {
                if (obj.Type == "Animals")
                {
                    Animals a = obj as Animals;
                    a.CheckState();
                }

                Instance.Level.Squares[obj.Spot.Row, obj.Spot.Column] = obj;
            }
        }

        private static GameController instance = new GameController();
        public static GameController Instance
        {
            get { return instance; }
        }


    }
}
