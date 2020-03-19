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

namespace Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Input input;
        Rectangle tile;
        public MainWindow()
        {
            InitializeComponent();
            input = new Input();
            tile = new Rectangle();
            tile.Width = 500;
            tile.Height = 500;
            tile.Fill = new SolidColorBrush(Colors.Red); ;
            MainMap.Children.Add(tile);
        }
        public void RouteKey(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.Key.ToString());
            input.KeyHandler(e.Key);
        }
    }
}
