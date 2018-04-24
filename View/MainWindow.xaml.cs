<<<<<<< HEAD
﻿using System;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Sitar);
            player.Play();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            GameController.Instance.Level = new World();
            GameController.Instance.Load("TTLSave.txt");

            GameController.Instance.InitialSetup();
            GameController.Instance.Update();
            GameScreen game = new GameScreen();
            game.ShowDialog();
        }

        private void DifficultyLstBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DifficultyLstBox.SelectedIndex != -1)
            {
                GameController.Instance.Difficulty = DifficultyLstBox.SelectedIndex;
                Console.WriteLine(DifficultyLstBox.SelectedIndex);
                Console.WriteLine(GameController.Instance.Difficulty);
            }
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            GameController.Instance.Reset();
            GameController.Instance.SetUpLevelThreePtTwo();
            GameController.Instance.LevelNum = 3.2;
            GameController.Instance.InitialSetup();
            GameScreen game = new GameScreen();
            game.ShowDialog();
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            Help h = new Help();
            h.ShowDialog();
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }

        private void btnHighScores_Click(object sender, RoutedEventArgs e)
        {
            HighscoreScreen h = new HighscoreScreen();
            h.ShowDialog();
        }

        private void btnBoy_Click(object sender, RoutedEventArgs e)
        {
            GameController.Instance.GenderImg = "/Scotty.gif";

        }

        private void btnGirl_Click(object sender, RoutedEventArgs e)
        {
            GameController.Instance.GenderImg = "/Sue.gif";
        }

        private void btnTTLLevelDesigner_Click(object sender, RoutedEventArgs e)
        {
            TTLLevelDesigner ld = new TTLLevelDesigner();
            ld.Show();
        }
    }
=======
﻿using System;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Sitar);
            player.Play();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            GameController.Instance.Level = new World();
            GameController.Instance.Load("TTLSave.txt");

            GameController.Instance.InitialSetup();
            GameController.Instance.Update();
            GameScreen game = new GameScreen();
            game.ShowDialog();
        }

        private void DifficultyLstBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DifficultyLstBox.SelectedIndex != -1)
            {
                GameController.Instance.Difficulty = DifficultyLstBox.SelectedIndex;
                Console.WriteLine(DifficultyLstBox.SelectedIndex);
                Console.WriteLine(GameController.Instance.Difficulty);
            }
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            GameController.Instance.Reset();
            GameController.Instance.SetUpLevelOne();
            GameController.Instance.LevelNum = 1;
            GameController.Instance.InitialSetup();
            GameScreen game = new GameScreen();
            game.ShowDialog();
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            Help h = new Help();
            h.ShowDialog();
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }

        private void btnHighScores_Click(object sender, RoutedEventArgs e)
        {
            HighscoreScreen h = new HighscoreScreen();
            h.ShowDialog();
        }

        private void btnBoy_Click(object sender, RoutedEventArgs e)
        {
            GameController.Instance.GenderImg = "/Scotty.gif";

        }

        private void btnGirl_Click(object sender, RoutedEventArgs e)
        {
            GameController.Instance.GenderImg = "/Sue.gif";
        }

        private void btnTTLLevelDesigner_Click(object sender, RoutedEventArgs e)
        {
            TTLLevelDesigner ld = new TTLLevelDesigner();
            ld.Show();
        }
    }
>>>>>>> a6b39aa590fd61b3aed95acbb853b33ae1e2d635
}