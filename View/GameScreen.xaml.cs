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
    /// Interaction logic for GameScreen.xaml
    /// </summary>
    public partial class GameScreen : Window
    {
        public GameScreen()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GameController.Instance.Reset();
        }

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

            GameController.Instance.Update();
        }

        private void btnMenu_Click(object sender, KeyEventArgs e)
        {

        }

    }
}

