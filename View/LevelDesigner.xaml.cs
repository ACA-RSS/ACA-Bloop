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
using System.IO;
using Twisted_Treeline.Model;

namespace Twisted_Treeline
{
    /// <summary>
    /// Interaction logic for LevelDesigner.xaml
    /// </summary>
    public partial class LevelDesigner : Window
    {
        public List<WorldObject> list = new List<WorldObject>();
        public Image[,] images = new Image[24,32];
        public LevelDesigner()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int row = 0; row < 24; ++row)
            {
                StackPanel rowPanel = new StackPanel()
                {
                    Orientation = Orientation.Horizontal
                };
                panel.Children.Add(rowPanel);
                for (int col = 0; col < 32; ++col)
                {
                    int btnNum = row * 24 + col;
                    Image i = new Image() { };
                    i.Tag = new Location() { Row = row, Column = col };
                    rowPanel.Children.Add(i);
                }
            }
        }
                    private void Tree_Click(object sender, RoutedEventArgs e)
        {
            Image newimage = GetEmptySpace();
            Location loc = (Location)newimage.Tag;
        }



        private void Bear_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Wolf_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string filestring = "";
            for (int i = 1; i <= 10; i++)
            {
                filestring = "DesignerLevel" + i.ToString();
                if (!File.Exists(filestring))
                {
                    File.Create(filestring);
                }

            }
            if (filestring == "")
            {
                return;
            }
            StreamWriter w = new StreamWriter(filestring);
            foreach (WorldObject item in list)
            {
                w.WriteLine(item.Serialize());
            }


        }
        private Image GetEmptySpace()
        {
            throw new NotImplementedException();
        }
    }
}
