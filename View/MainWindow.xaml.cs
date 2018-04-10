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

        private void DifficultyLstBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cheat = new ComboBoxItem() { Content = "Cheat Mode" };
            ComboBoxItem easy = new ComboBoxItem() { Content = "Hard" };
            ComboBoxItem medium = new ComboBoxItem() { Content = "More Harder" };
            ComboBoxItem hard = new ComboBoxItem() { Content = "Downright Impossible" };

            DifficultyLstBox.Items.Add(cheat);
            DifficultyLstBox.Items.Add(easy);
            DifficultyLstBox.Items.Add(medium);
            DifficultyLstBox.Items.Add(hard);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            GameController.Instance.Reset();
            GameController.Instance.UserName = txtUsername.Text;
            int howHard = 0;
            if (DifficultyLstBox.Text == "Cheat Mode")
            {
                howHard = 0;
            }
            else if (DifficultyLstBox.Text == "Hard")
            {
                howHard = 1;
            }
            else if (DifficultyLstBox.Text == "More Harder")
            {
                howHard = 2;
            }
            else if (DifficultyLstBox.Text == "Downright Impossible")
            {
                howHard = 3;
            }

            GameController.Instance.Difficulty = howHard;
            GameScreen game = new GameScreen();
            game.ShowDialog();
        }
    }
}
