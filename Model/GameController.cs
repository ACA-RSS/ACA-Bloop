using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Threading;
using Twisted_Treeline;

namespace Twisted_Treeline.Model
{
    public enum LevelNum { One, Two, Three };

    public class GameController
    {
        public string UserName { get; set; }

        public int Difficulty { get; set; }

        public LevelNum LevelNum { get; set; }

        public World Level { get; set; }

        public int Points { get; set; }

        public Character Player { get; set; }

        //Resets points, assumes difficulty 'easy', and makes the new world
        private GameController()
        {
            Level = new World();
            Points = 0;
            Difficulty = 1;
            Player = new Character();
            LevelNum = LevelNum.One;
        }

        //Returns true if the character is dead, or if the player has all three stars and is back at the starting
        //point of row 13, column 0. I used this to test whether to continue the game and animal movements

        public bool isGameOver()
        {
            if (Instance.Player.Dead)
            {
                return true;
            }
            else if (Instance.Level.Stars == 3 && Instance.Player.Spot.Column == Instance.Player.StartSpot.Column && Instance.Player.Spot.Row == Instance.Player.StartSpot.Row)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Clears the Level and points, mostly for startng a new level or testing
        public void Reset()
        {
            Level = new World();
            Points = 0;
        }

        //Hardcodes in the player and all of the wall pieces and animals and such, then adds all of them
        // to the Game Controller's WorldObj list. This is the only thing that changes from level to level
        public void SetUpLevelOne()
        {
            Player = new Character()
            {
                Stick = new Stick(5),
                StartSpot = new Location { Row = 12, Column = 0 },
                Spot = new Location { Row = Player.StartSpot.Row, Column = Player.StartSpot.Column }
            };

            Instance.Level.WorldObj.Add(Player);

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
            Wall.WallBuilder(2, 1, 5, "Vert");
            Wall.WallBuilder(7, 2, 7, "Horz");
            Wall.WallBuilder(0, 9, 7, "Vert");

            //Right Side

            Wall.WallBuilder(1, 11, 8, "Horz");
            Wall.WallBuilder(2, 11, 10, "Vert");
            Wall.WallBuilder(10, 13, 2, "Vert");
            Wall.WallBuilder(12, 14, 5, "Horz");
            Wall.WallBuilder(3, 19, 8, "Vert");
            Wall.WallBuilder(3, 13, 5, "Horz");
            Wall.WallBuilder(4, 13, 4, "Vert");
            Wall.WallBuilder(8, 14, 1, "Horz");
            Wall.WallBuilder(9, 15, 1, "Vert");
            Wall.WallBuilder(10, 16, 1, "Horz");
            Wall.WallBuilder(5, 17, 4, "Vert");
            Wall.WallBuilder(5, 15, 2, "Horz");
            Wall.WallBuilder(6, 15, 0, "Vert");

            //Bottom Left
            Wall.WallBuilder(11, 9, 2, "Vert");
            Wall.WallBuilder(10, 7, 2, "Vert");
            Wall.WallBuilder(9, 1, 4, "Vert");
            Wall.WallBuilder(9, 2, 8, "Horz");
            Wall.WallBuilder(11, 5, 2, "Vert");
            Wall.WallBuilder(11, 3, 1, "Horz");
            Wall.WallBuilder(12, 3, 0, "Vert");
        }

        public void SetUpLevelTwo()
        {
            Instance.Level.Height = 24;
            Instance.Level.Width = 31;

        }

        public void SetUpLevelThree()
        {
            Instance.Level.Height = 34;
            Instance.Level.Width = 41;
        }

        public void Save(string file)
        {
            string saveData = "TwistedTLine";

            //Saves the player info

            using (StreamWriter writer = new StreamWriter(file))
            {
                
                writer.WriteLine(saveData);
                writer.WriteLine(Instance.UserName);
                writer.WriteLine(Instance.Difficulty);
                writer.WriteLine(Instance.Points);
                writer.WriteLine(Instance.Level.Stars);
                foreach (WorldObject obj in Level.WorldObj)
                {
                    writer.WriteLine(obj.Serialize());
                }
            }
        }

        public void Load(string fileName)
        {

            using (StreamReader sr = new StreamReader(fileName))
            {
                string curLine;
                string saveTitle = sr.ReadLine();
                if (saveTitle != "TwistedTLine")
                {
                    Environment.Exit(1);
                }
                Instance.UserName = sr.ReadLine();
                //difficulty
                Instance.Difficulty = Convert.ToInt32(sr.ReadLine());
                //points
                Instance.Points = Convert.ToInt32(sr.ReadLine());
                //stars
                Instance.Level.Stars = Convert.ToInt32(sr.ReadLine());
                //check to make sure it isnt the last line in the file
                while (sr.Peek() >= 0)
                {
                    curLine = sr.ReadLine();
                    string type = curLine.Substring(0, 4);
                    WorldObject w;
                    switch (type)
                    {
                        case "Bear":
                            {
                                Bear b = new Bear();
                                w = b.Deserialize(curLine);
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
                                Instance.Player = w as Character;
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

        //Mostly made this to avoid errors on the first run through. It moves the location variables
        //Of all the world objects into a 2D array that keeps track of where things are.
        public void InitialSetup()
        {
            foreach (WorldObject obj in Instance.Level.WorldObj)
            {
                Instance.Level.Squares[obj.Spot.Row, obj.Spot.Column] = obj;
            }
        }

        //Updates Model based on Timer and user actions
        //Resets the 2D array of world object locations to equal null, unless it's a Wall since we don't
        //Wants to redraw all of those and they don't move. 
        //Then it goes through, updates everything's position, and then refills the Array (Squares) with the new
        //Locations
        public void Update()
        {
            foreach (WorldObject o in Instance.Level.Squares)
            {
                if (o != null)
                {
                    if (o.Type != "Wall")
                    {
                        Instance.Level.Squares[o.Spot.Row, o.Spot.Column] = null;
                    }
                }
            }
            foreach (WorldObject obj in Instance.Level.WorldObj)
            {
                if (obj.Type == "Hittable")

                {
                    Animals a = obj as Animals;
                    if (a != null)
                    {
                        a.CheckState();
                    }
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