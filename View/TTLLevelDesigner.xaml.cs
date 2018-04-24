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
    public partial class TTLLevelDesigner : Window
    {
        public List<WorldObject> list = new List<WorldObject>();
        static int rownum = 24;
        static int colnum = 32;
        public Image[,] images = new Image[rownum, colnum];
        public TTLLevelDesigner()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int row = 0; row < rownum; ++row)
            {
                StackPanel rowPanel = new StackPanel()
                {
                    Orientation = Orientation.Horizontal
                };
                panel.Children.Add(rowPanel);
                for (int col = 0; col < colnum; ++col)
                {
                    //might be colnum instead of rownum....
                    int btnNum = row * rownum + col;
                    Image i = new Image() { Source = new BitmapImage(new Uri("/wall.png")) };
                    i.Tag = new Location() { Row = row, Column = col };
                    rowPanel.Children.Add(i);
                }
            }
            //add character and stars
            AddStar();
            AddStar();
            AddStar();
            AddCharacter();
        }
        private void Tree_Click(object sender, RoutedEventArgs e)
        {
            Image newimage = GetEmptySpace();
            newimage.Source = new BitmapImage(new Uri("/tree.png"));
            Location loc = (Location)newimage.Tag;
            list.Add(new Wall() { Spot = loc });
        }



        private void Bear_Click(object sender, RoutedEventArgs e)
        {
            Image newimage = GetEmptySpace();
            newimage.Source = new BitmapImage(new Uri("/bigber.png"));
            Location loc = (Location)newimage.Tag;
            list.Add(new Bear() { Spot = loc });
        }


        private void Wolf_Click(object sender, RoutedEventArgs e)
        {
            Image newimage = GetEmptySpace();
            newimage.Source = new BitmapImage(new Uri("/wolf.png"));
            Location loc = (Location)newimage.Tag;
            list.Add(new Wolf() { Spot = loc });
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
                    break;
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
            BitmapImage bi = new BitmapImage(new Uri("/wall.png"));
            Random r = new Random();
            while (true)
            {
                Image i = images[r.Next(rownum), r.Next(colnum)];
                if (i.Source == bi)
                {
                    return i;
                }
            }
        }
        private void AddStar()
        {
            Image newimage = GetEmptySpace();
            newimage.Source = new BitmapImage(new Uri("/steer.png"));
            Location loc = (Location)newimage.Tag;
            list.Add(new Star() { Spot = loc });
        }
        private void AddCharacter()
        {
            Image newimage = GetEmptySpace();
            newimage.Source = new BitmapImage(new Uri("/scotty.png"));
            Location loc = (Location)newimage.Tag;
            list.Add(new Character() { Spot = loc });
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void panel_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }
        private Button MakeButton(string src)
        {
            Button b = new Button();
            b.BorderBrush = new SolidColorBrush(Colors.Black);
            b.Width = 50;
            b.Height = 50;
            b.Margin = new Thickness(10);
            b.Content = "bigber.png";

            b.Click += btn_Click;
            return b;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }

}
