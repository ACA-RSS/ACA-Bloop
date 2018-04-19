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
           /* DifficultyLstBox.Items.Add("Cheat Mode");
            DifficultyLstBox.Items.Add("Hard");
            DifficultyLstBox.Items.Add("More Hardlier");
            DifficultyLstBox.Items.Add("Downright Impossible");*/
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            GameController.Instance.Reset();
            GameController.Instance.Load("TTLSave.txt");
            int howHard = 0;
            string diff = Convert.ToString(DifficultyLstBox.SelectionBoxItem);
            if (diff == "Cheat Mode")
            {
                howHard = 0;
            }
            else if (diff == "Hard")
            {
                howHard = 1;
            }
            else if (diff == "More Hardlier")
            {
                howHard = 2;
            }
            else
            {
                howHard = 3;
            }

            GameController.Instance.Difficulty = howHard;
            GameController.Instance.InitialSetup();
            GameScreen game = new GameScreen();
            game.ShowDialog();
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            GameController.Instance.Reset();
            int howHard = 0;
            string diff = Convert.ToString(DifficultyLstBox.Text);
            if (diff == "Cheat Mode")
            {
                howHard = 0;
            }
            else if (diff == "Hard")
            {
                howHard = 1;
            }
            else if (diff == "More Hardlier")
            {
                howHard = 2;
            }
            else
            {
                howHard = 3;
            }

            GameController.Instance.SetUpLevelOne();
            GameController.Instance.Difficulty = howHard;

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
    }
}
