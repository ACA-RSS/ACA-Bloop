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

namespace Twisted_Treeline.View
{
    /// <summary>
    /// Interaction logic for HighscoreScreen.xaml
    /// </summary>
    public partial class HighscoreScreen : Window
    {
        public HighscoreScreen()
        {
            LoadHighScores();
            InitializeComponent();

            
        }
        public void LoadHighScores()
        {
            HighscoreManager hsm = new HighscoreManager("HighScores.txt");
            hsm.LoadList();
            foreach (Highscore hs in hsm.HighscoreList)
            {
                Scores.Text += hs.Name + "   " + hs.Score + "\n";
            }
        }
    }
}
