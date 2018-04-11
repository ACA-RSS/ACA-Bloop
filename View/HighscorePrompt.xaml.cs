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
using System.Windows.Shapes;
using Twisted_Treeline.Model;
using System.IO;

namespace Twisted_Treeline.View
{
    /// <summary>
    /// Interaction logic for HighscorePrompt.xaml
    /// </summary>
    public partial class HighscorePrompt : Window
    {
        HighscoreManager manager = new HighscoreManager("Highscores.txt");
        public HighscorePrompt()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            manager.LoadList();
            string name = Name.Text;
            int score = Convert.ToInt32(Score.Text);
            manager.SaveList(new Highscore(score,name));
            HighscoreScreen hscreen = new HighscoreScreen();
            hscreen.Show();
        }
    }
}