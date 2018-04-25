//The screen on which the game is displayed and played. Contains logic for level changing and screen
//Updates.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Twisted_Treeline.Model;
using System.Windows.Threading;
using Twisted_Treeline.View;
using System.Media;
using Twisted_Treeline;
using System.Reflection;
using System.IO;
using WpfAnimatedGif;

namespace Twisted_Treeline
{
    /// <summary>
    /// Interaction logic for GameScreen.xaml
    /// </summary>
    public partial class GameScreen : Window
    {
        //Timer to update the screen
        public static DispatcherTimer Ticky;


        private readonly ImageSource img;

        public GameScreen()
        {
            InitializeComponent();
        }


        //Makes the new timer and sets up all the wall objects before initially updating the screen
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Ticky = new DispatcherTimer() { Interval = new TimeSpan(10) };
            Ticky.Tick += Ticky_Tick;

            BuildTheWall();
            Setup();
            UpdateScreen();

            Ticky.Start();
        }

        //On every timer tick, checks if the game is over/Level is completed (See isGameOver
        //for Game Controller).
        //If not, Calls the UpdateScreen method
        //If so, performs logic to end the game or to load the next level
        public void Ticky_Tick(object sender, object e)
        {
            if (!GameController.Instance.isGameOver())
            {
                GameController.Instance.Update();
                UpdateScreen();
            }
            else
            {
                if (!GameController.Instance.Player.Dead)
                {
                    GameController.Instance.Points += 500 + (GameController.Instance.Difficulty * GameController.Instance.Player.HitPoints);
                    switch (GameController.Instance.LevelNum)
                    {
                        case 1:
                            //Abduction();
                            GameController.Instance.Level = new World();
                            GameController.Instance.SetUpLevelTwo();
                            GameController.Instance.InitialSetup();
                            GameController.Instance.LevelNum = 2;
                            txtLevel.Text = "Level Two";
                            UpdateScreen();
                            GameController.Instance.Update();
                            break;

                        case 2:
                            GameController.Instance.Level = new World();
                            GameController.Instance.SetUpLevelThreePtOne();
                            GameController.Instance.InitialSetup();
                            GameController.Instance.LevelNum = 3.1;
                            txtLevel.Text = "Level Three";
                            UpdateScreen();
                            GameController.Instance.Update();
                            break;

                        case 3.1:
                            GameController.Instance.Level = new World();
                            GameController.Instance.SetUpLevelThreePtTwo();
                            GameController.Instance.InitialSetup();
                            GameController.Instance.LevelNum = 3.2;
                            GameController.Instance.Level.Stars = 1;
                            UpdateScreen();
                            GameController.Instance.Update();
                            break;

                        case 3.2:
                            GameController.Instance.Player.HitPoints = 100;
                            GameController.Instance.Armageddon();
                            GameController.Instance.LevelNum = 4;
                            txtLevel.Text = "ARMAGEDDON";
                            WorldCanvas.Background = new SolidColorBrush(Colors.Red);
                            UpdateScreen();
                            break;

                        case 4:
                            Abduction();
                            break;
                    }
                }
                else
                {
                    Ticky.Stop();
                    HighscorePrompt hs = new HighscorePrompt();
                    hs.ScoreTitle.Text = "YOU FAILED";
                    hs.ShowDialog();
                }
            }
        }
        
        //Sets up all wall objects; only called at beginning of level setup
        private void BuildTheWall()
        {
            foreach (WorldObject obj in GameController.Instance.Level.WorldObj)
            {
                if (obj.Type == "Wall")
                {
                    Image i = new Image()
                    {
                        Tag = obj,
                        Source = new BitmapImage(new Uri(obj.Image, UriKind.Relative)),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(obj.Spot.Column * (WorldCanvas.Width / GameController.Instance.Level.Width), obj.Spot.Row * (WorldCanvas.Height / GameController.Instance.Level.Height), 0, 0),
                        Width = WorldCanvas.Width / GameController.Instance.Level.Width,
                    };

                    WorldCanvas.Children.Add(i);
                }
            }
        }

        //Called at the very end of the third level; adds a space ship above Scotty and launches 
        //new high score screen
        public void Abduction()
        {
            GameController.Instance.Difficulty = 0;
            Squirrel ship = new Squirrel() { HitPoints = 5000, Speed = 5000, Damage = 0, Image = "/EpicSpaceship.png", Spot = new Location() { Row = GameController.Instance.Player.Spot.Row - 2, Column = GameController.Instance.Player.Spot.Column - 1 } };

            GameController.Instance.Level.WorldObj.Add(ship);

            for (int i = 0; i < 10; i++)
            {
                GameController.Instance.Update();
                UpdateScreen();
            }

            Ticky.Stop();
            HighscorePrompt hs = new HighscorePrompt();
            hs.ScoreTitle.Text = "YOU WON";
            hs.ShowDialog();
        }

        //Adds every WorldObject except Walls to the screen at the beginning of the level
        public void Setup()
        {
            foreach (WorldObject obj in GameController.Instance.Level.WorldObj)
            {
                if (obj.Type != "Wall")
                {
                    var source = new BitmapImage(new Uri(obj.Image, UriKind.Relative));
                    var img = new Image()
                    {
                        Tag = obj,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(obj.Spot.Column * (WorldCanvas.Width / GameController.Instance.Level.Width), obj.Spot.Row * (WorldCanvas.Height / GameController.Instance.Level.Height), 0, 0),
                        Width = 20
                    };
                    ImageBehavior.SetAnimatedSource(img, source);

                    WorldCanvas.Children.Add(img);
                }
            }
        }

        //Called every timer tick
        //Updates the points, health, and number of stars of the player. 
        //Removes images of dead objects, adds new images, and updates locations and images of others
        private void UpdateScreen()
        {
            if (GameController.Instance.CurrentSound != null)
            {
                SoundPlayer player = new SoundPlayer(GameController.Instance.CurrentSound);
                Properties.Resources.BerSound.Position = 0;
                //Properties.Resources.SquirrelSound.Position = 0;
                Properties.Resources.punch.Position = 0;
                Properties.Resources.wolf_attack.Position = 0;
                GameController.Instance.CurrentSound.Position = 0;     // Manually rewind stream 
                player.Stream = null;    // Then we have to set stream to null 
                player.Stream = GameController.Instance.CurrentSound;  // And set it again, to force it to be loaded again... 
                player.Play();

            }

            txtPoints.Text = String.Format("Points: {0}", Convert.ToString(GameController.Instance.Points));
            prgHealth.Value = GameController.Instance.Player.HitPoints;
            imgStars.Source = new BitmapImage(new Uri(String.Format("/Star{0}.png", GameController.Instance.Level.Stars), UriKind.Relative));
            txtLevel.Text = String.Format("Level #{0}", Math.Floor(GameController.Instance.LevelNum));
            List<WorldObject> accounted = new List<WorldObject>();

            List<Image> toDestroy = new List<Image>();

            foreach (Image i in WorldCanvas.Children)
            {
                WorldObject o = i.Tag as WorldObject;

                if (GameController.Instance.Level.WorldObj.Contains(o))
                {
                    accounted.Add(o);
                    if (o.Type != "Wall")
                    {
                        i.Margin = new Thickness(o.Spot.Column * (WorldCanvas.Width / GameController.Instance.Level.Width), o.Spot.Row * (WorldCanvas.Height / GameController.Instance.Level.Height), 0, 0);
                        if (o.Image == "/EpicSpaceship.png")
                        {
                            i.Width = 80;
                        }
                        ImageBehavior.SetAnimatedSource(i, new BitmapImage(new Uri(o.Image, UriKind.Relative)));
                    }
                }
                else
                {
                    toDestroy.Add(i);
                }
            }

            foreach (Image i in toDestroy)
            {
                WorldCanvas.Children.Remove(i);
            }

            foreach (WorldObject obj in GameController.Instance.Level.WorldObj)
            {
                if (accounted.Contains(obj))
                {
                    continue;
                }
                else
                {
                    var img = new Image()
                    {
                        Tag = obj,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(obj.Spot.Column * (WorldCanvas.Width / GameController.Instance.Level.Width), obj.Spot.Row * (WorldCanvas.Height / GameController.Instance.Level.Height), 0, 0),
                        Width = 20
                    };

                    ImageBehavior.SetAnimatedSource(img, new BitmapImage(new Uri(obj.Image, UriKind.Relative)));

                    WorldCanvas.Children.Add(img);
                }
            }

            GameController.Instance.CurrentSound = null;
        }

        //Change player to Attack image when the space bar comes up
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Space)
            {
                GameController.Instance.Player.Attack();
                GameController.Instance.Player.Image = GameController.Instance.GenderImg;
            }
        }

        //Controls the user movements and attack
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                GameController.Instance.Player.PlayerMove("Up");
            }
            else if (e.Key == Key.A)
            {
                GameController.Instance.Player.PlayerMove("Left");
            }
            else if (e.Key == Key.S)
            {
                GameController.Instance.Player.PlayerMove("Down");
            }
            else if (e.Key == Key.D)
            {
                GameController.Instance.Player.PlayerMove("Right");
            }
            else if (e.Key == Key.Space)
            {
                GameController.Instance.Player.AttackImage();
            }
        }

        //Pauses the timer and opens the menu
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Ticky.Stop();
            Menu menu = new Menu();
            menu.ShowDialog();
            btnMenu.Focusable = false;
        }
    }
}

