//Runs the Title Screen of the game; contains buttons to start a new game, access the menu,
//Load a saved game, view highs scores, or read about the authors

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
using Twisted_Treeline;
using Twisted_Treeline.View;
using System.Media;

namespace Twisted_Treeline
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Plays introductory music
        public SoundPlayer player;

        public MainWindow()
        {
            InitializeComponent();
        }

        //Plays introductory music
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            player = new SoundPlayer(Properties.Resources.Sitar);
            player.Play();
        }

        //Loads old game from file
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
            GameController.Instance.Level = new World();
            GameController.Instance.Load("TTLSave.txt");
            GameController.Instance.InitialSetup();
            GameController.Instance.Update();
            GameScreen game = new GameScreen();
            game.ShowDialog();
        }

        //Updates the Game Controller difficulty when the user selects a difficulty
        private void DifficultyLstBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DifficultyLstBox.SelectedIndex != -1)
            {
                GameController.Instance.Difficulty = DifficultyLstBox.SelectedIndex;
                Console.WriteLine(DifficultyLstBox.SelectedIndex);
                Console.WriteLine(GameController.Instance.Difficulty);
            }
        }

        //Starts a new game by resetting Game Controller, setting up level 1, and launching a game screen
        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
            GameController.Instance.Reset();
            GameController.Instance.SetUpLevelOne();
            GameController.Instance.LevelNum = 1;
            GameController.Instance.InitialSetup();
            GameScreen game = new GameScreen();
            game.ShowDialog();
        }

        //Opens the Help window
        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            Help h = new Help();
            h.ShowDialog();
        }

        //Opens the about window
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }

        //Displays high scores from the high score file
        private void btnHighScores_Click(object sender, RoutedEventArgs e)
        {
            HighscoreScreen h = new HighscoreScreen();
            h.ShowDialog();
        }

        //Selects the male character image
        private void btnBoy_Click(object sender, RoutedEventArgs e)
        {
            GameController.Instance.GenderImg = "/Scotty.gif";

        }

        //Selects the female character image
        private void btnGirl_Click(object sender, RoutedEventArgs e)
        {
            GameController.Instance.GenderImg = "/Sue.gif";
        }


    }
}