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
            DifficultyLstBox.Items.Add("Cheat");
            DifficultyLstBox.Items.Add("Hard");
            DifficultyLstBox.Items.Add("More Harder");
            DifficultyLstBox.Items.Add("Downright Impossible");
        }
    }
}
