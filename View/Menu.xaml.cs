//Allows user to save or access game information during game play

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

namespace Twisted_Treeline
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        //Links to the About screen
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            Help h = new Help();
            h.ShowDialog();
        }

        //Saves the game to the game file
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            GameController.Instance.Save("TTLSave.txt");
        }

        //Restarts the game timer and closes the window
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            GameScreen.Ticky.Start();
            Close();

        }
    }
}
