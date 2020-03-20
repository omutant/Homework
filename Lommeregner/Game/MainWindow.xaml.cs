using Game.Tiles;
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
        public Input input;
        public TileMap tileMap;
        public MainWindow()
        {
            InitializeComponent();
            input = new Input();
            tileMap = new TileMap(9, 15);
        }
        public void RouteKey(object sender, KeyEventArgs e)
        {
            input.KeyHandler(e.Key);
        }
    }
}
