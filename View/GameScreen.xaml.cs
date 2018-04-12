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

namespace Twisted_Treeline
{
    /// <summary>
    /// Interaction logic for GameScreen.xaml
    /// </summary>
    public partial class GameScreen : Window
    {
        DispatcherTimer Ticky { get; set; }

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
            UpdateScreen();
            
            Ticky.Start();

        }

        //On every timer tick, checks if the game is over (See isGameOver for Game Controller
        //And if not, updates the animal locations and then updates the scree with these changes
        public void Ticky_Tick(object sender, object e)
        {
            if (!GameController.Instance.isGameOver())
            {
                GameController.Instance.Update();
                UpdateScreen();
                
            }
            else
            {
                GameController.Instance.Points += 500;
                Ticky.Stop();
                HighscorePrompt hs = new HighscorePrompt();
                hs.ShowDialog();
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
                        Width = 20
                    };

                    WorldCanvas.Children.Add(i);
                }
            }
        }

        //Called every timer tick
        //Updates the points, health, and number of stars of the player. 
        //Destroys all non-wall images, and then makes new ones with the world object's new location
        private void UpdateScreen()
        {
            txtPoints.Text = String.Format("Points: {0}", Convert.ToString(GameController.Instance.Points));
            txtHealth.Text = String.Format("Health Percent: {0}", Convert.ToString(GameController.Instance.Player.HitPoints));
            imgStars.Source = new BitmapImage(new Uri(String.Format("/Star{0}.png", GameController.Instance.Level.Stars), UriKind.Relative));

            List<Image> toDestroy = new List<Image>();
            foreach (Image i in WorldCanvas.Children)
            {
                WorldObject o = i.Tag as WorldObject;

                if (o.Type != "Wall")
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
                if (obj.Type != "Wall")
                {
                    Image i = new Image()
                    {
                        Tag = obj,
                        Source = new BitmapImage(new Uri(obj.Image, UriKind.Relative)),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(obj.Spot.Column * (WorldCanvas.Width / GameController.Instance.Level.Width), obj.Spot.Row * (WorldCanvas.Height / GameController.Instance.Level.Height), 0, 0),
                        Width = 20
                    };

                    WorldCanvas.Children.Add(i);
                }
            }

        }

        //Controls the user movements and attack
        private void Window_KeyUp(object sender, KeyEventArgs e)
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
                GameController.Instance.Player.Attack();
            }

        }

        //Pauses the timer and opens the menu
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Ticky.Stop();
            Menu menu = new Menu();
            menu.ShowDialog();
        }

    }
}

