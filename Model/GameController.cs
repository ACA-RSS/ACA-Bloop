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

    public class GameController
    {
        public int Difficulty { get; set; }

        public int LevelNum { get; set; }

        public World Level { get; set; }

        public int Points { get; set; }

        public Character Player { get; set; }

        public Stream CurrentSound { get; set; }

        public string GenderImg { get; set; }

        //Resets points, assumes difficulty 'easy', and makes the new world
        private GameController()
        {
            Level = new World();
            Points = 0;
            Difficulty = 1;
            Player = new Character(GenderImg);
            LevelNum = 1;
            CurrentSound = null;
            //  GenderImg = "/Scotty.gif";
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
            else if (Instance.Level.Stars == 3 && Instance.LevelNum == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Armageddon()
        {
            Bear famine = new Bear() { Spot = new Location { Row = Player.Spot.Row, Column = Player.Spot.Column + 1 }, Damage = 5 * Instance.Difficulty };
            Bear plague = new Bear() { Spot = new Location { Row = Player.Spot.Row, Column = Player.Spot.Column - 1}, Damage = 5 * Instance.Difficulty };
            Bear war = new Bear() { Spot = new Location { Row = Player.Spot.Row - 1, Column = Player.Spot.Column }, Damage = 5 * Instance.Difficulty };
            Bear death = new Bear() { Spot = new Location { Row = Player.Spot.Row + 1, Column = Player.Spot.Column }, Damage = 5 * Instance.Difficulty };

            Instance.Level.WorldObj.Add(famine);
            Instance.Level.WorldObj.Add(plague);
            Instance.Level.WorldObj.Add(war);
            Instance.Level.WorldObj.Add(death);
        }

        //Clears the Level and points, mostly for startng a new level or testing
        public void Reset()
        {
            Level = new World();
            Points = 0;
            LevelNum = 1;
            CurrentSound = null;
        }

        //Hardcodes in the player and all of the wall pieces and animals and such, then adds all of them
        // to the Game Controller's WorldObj list. This is the only thing that changes from level to level
        public void SetUpLevelOne()
        {
            Player = new Character(GameController.Instance.GenderImg)
            {
                Stick = new Stick(5),
                StartSpot = new Location { Row = 13, Column = 1 },
                Spot = new Location { Row = 13, Column = 1 }
            };

            Instance.Level.WorldObj.Add(Player);

            Bear fuzzy = new Bear() { Spot = new Location { Row = 5, Column = 6 } };
            Bear wuzzy = new Bear() { Spot = new Location { Row = 8, Column = 16 } };
            Bear buzzy = new Bear() { Spot = new Location { Row = 11, Column = 4 } };

            Instance.Level.WorldObj.Add(fuzzy);
            Instance.Level.WorldObj.Add(wuzzy);
            Instance.Level.WorldObj.Add(buzzy);

            Star glitter = new Star() { Spot = new Location { Row = 5, Column = 5 } };
            Star gleam = new Star() { Spot = new Location { Row = 13, Column = 5 } };
            Star glow = new Star() { Spot = new Location { Row = 10, Column = 17 } };


            Instance.Level.WorldObj.Add(glitter);
            Instance.Level.WorldObj.Add(gleam);
            Instance.Level.WorldObj.Add(glow);

            Wolf wolfy = new Wolf() { Spot = new Location { Row = 9, Column = 11 } };
            Wolf bitey = new Wolf() { Spot = new Location { Row = 12, Column = 17 } };
            Wolf growly = new Wolf() { Spot = new Location { Row = 14, Column = 7 } };

            Instance.Level.WorldObj.Add(wolfy);
            Instance.Level.WorldObj.Add(bitey);
            Instance.Level.WorldObj.Add(growly);


            Wall.BuildEdges();

            //Edges of smaller map

            Wall.WallBuilder(14, 1, 20, "Horz");
            Wall.WallBuilder(1, 22, 13, "Vert");

            //Swirl in top left
            Wall.WallBuilder(4, 4, 2, "Horz");
            Wall.WallBuilder(5, 4, 1, "Vert");
            Wall.WallBuilder(6, 5, 3, "Horz");
            Wall.WallBuilder(2, 8, 3, "Vert");
            Wall.WallBuilder(2, 2, 5, "Horz");
            Wall.WallBuilder(3, 2, 5, "Vert");
            Wall.WallBuilder(8, 3, 7, "Horz");
            Wall.WallBuilder(1, 10, 7, "Vert");

            //Right Side

            Wall.WallBuilder(2, 12, 8, "Horz");
            Wall.WallBuilder(3, 12, 10, "Vert");
            Wall.WallBuilder(11, 14, 2, "Vert");
            Wall.WallBuilder(13, 15, 5, "Horz");
            Wall.WallBuilder(4, 20, 8, "Vert");
            Wall.WallBuilder(4, 14, 5, "Horz");
            Wall.WallBuilder(5, 14, 4, "Vert");
            Wall.WallBuilder(9, 15, 1, "Horz");
            Wall.WallBuilder(10, 16, 1, "Vert");
            Wall.WallBuilder(11, 17, 1, "Horz");
            Wall.WallBuilder(6, 18, 4, "Vert");
            Wall.WallBuilder(6, 16, 2, "Horz");
            Wall.WallBuilder(7, 16, 0, "Vert");

            //Bottom Left
            Wall.WallBuilder(12, 10, 2, "Vert");
            Wall.WallBuilder(11, 8, 2, "Vert");
            Wall.WallBuilder(10, 2, 4, "Vert");
            Wall.WallBuilder(10, 3, 8, "Horz");
            Wall.WallBuilder(12, 6, 2, "Vert");
            Wall.WallBuilder(12, 4, 1, "Horz");
            Wall.WallBuilder(13, 4, 0, "Vert");
        }

        public void SetUpLevelTwo()
        {

            Instance.Level = new World()
            {
                Height = 24,
                Width = 32,
                Squares = new WorldObject[24, 32]
            };

            Wall.BuildEdges();

            for (int i = 1; i < 5; i++)
            {
                Wall.LevelTwo(i);
            }

            Instance.Player = new Character()
            {
                Stick = new Stick(5),
                StartSpot = new Location { Row = 1, Column = 0 },
                Spot = new Location { Row = 1, Column = 0 }
            };

            Instance.Level.WorldObj.Add(Player);

            Bear fuzzy = new Bear() { Spot = new Location { Row = 17, Column = 4 } };
            Bear wuzzy = new Bear() { Spot = new Location { Row = 5, Column = 25 } };
            Bear buzzy = new Bear() { Spot = new Location { Row = 8, Column = 27 } };
            Bear juzzy = new Bear() { Spot = new Location { Row = 17, Column = 24 } };

            Instance.Level.WorldObj.Add(fuzzy);
            Instance.Level.WorldObj.Add(wuzzy);
            Instance.Level.WorldObj.Add(buzzy);
            Instance.Level.WorldObj.Add(juzzy);

            Star glitter = new Star() { Spot = new Location { Row = 13, Column = 1 } };
            Star gleam = new Star() { Spot = new Location { Row = 3, Column = 26 } };
            Star glow = new Star() { Spot = new Location { Row = 22, Column = 28 } };

            Instance.Level.WorldObj.Add(glitter);
            Instance.Level.WorldObj.Add(gleam);
            Instance.Level.WorldObj.Add(glow);

            Wolf wolfy = new Wolf() { Spot = new Location { Row = 4, Column = 8 } };
            Wolf bitey = new Wolf() { Spot = new Location { Row = 13, Column = 10 } };
            Wolf growly = new Wolf() { Spot = new Location { Row = 22, Column = 12 } };
            Wolf snippy = new Wolf() { Spot = new Location { Row = 13, Column = 18 } };
            Wolf snappy = new Wolf() { Spot = new Location { Row = 13, Column = 26 } };

            Instance.Level.WorldObj.Add(wolfy);
            Instance.Level.WorldObj.Add(bitey);
            Instance.Level.WorldObj.Add(growly);
            Instance.Level.WorldObj.Add(snippy);
            Instance.Level.WorldObj.Add(snappy);

            Stump s = new Stump(new Stick() { HitPoints = 10, Damage = 20 }, 15) { Spot = new Location { Row = 6, Column = 19 } };
            Stump hiddenOne = new Stump(new Boost(), 15) { Spot = new Location { Row = 4, Column = 23 }, Image = "/Tree_Dark.png" };
            Stump hiddenTwo = new Stump(new Boost() { Bonus = 10 }, 20) { Spot = new Location { Row = 11, Column = 29 }, Image = "/Tree_Dark.png" };

            Instance.Level.WorldObj.Add(s);
            Instance.Level.WorldObj.Add(hiddenOne);
            Instance.Level.WorldObj.Add(hiddenTwo);

        }

        public void SetUpLevelThree()
        {
            Instance.Level = new World()
            {
                Height = 24,
                Width = 32,
                Squares = new WorldObject[24, 32]
            };

            Player = new Character(GameController.Instance.GenderImg)
            {
                Stick = new Stick(5),
                StartSpot = new Location { Row = 11, Column = 1 },
                Spot = new Location { Row = 1, Column = 0 }
            };
            Instance.Level.WorldObj.Add(Player);

            //Walls setup
            Wall.LevelThree();
            //boost setup
            Boost b1 = new Boost() { Spot = new Location { Row = 2, Column = 7 } };
            Boost b2 = new Boost() { Spot = new Location { Row = 21, Column = 7 } };
            Boost b3 = new Boost() { Spot = new Location { Row = 8, Column = 30 } };
            Instance.Level.WorldObj.Add(b1);
            Instance.Level.WorldObj.Add(b2);
            Instance.Level.WorldObj.Add(b3);




        }

        public void Save(string file)
        {
            string title = "TwistedTLine";

            //Saves the player info

            using (StreamWriter writer = new StreamWriter(file))
            {

                writer.WriteLine(title);
                writer.WriteLine(Instance.LevelNum);
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
                Instance.Difficulty = Convert.ToInt32(sr.ReadLine());
                //difficulty

                //level number
                Instance.LevelNum = Convert.ToInt32(sr.ReadLine());
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
                        case "Star":
                            {
                                Star sta = new Star();
                                w = sta.Deserialize(curLine);
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