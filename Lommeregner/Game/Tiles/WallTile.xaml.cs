using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game.Tiles
{
    /// <summary>
    /// Interaction logic for WallTile.xaml
    /// </summary>
    public partial class WallTile : UserControl, ITile
    {
        private Thickness _margin;
        public WallTile(int startSize, int x, int y)
        {
            InitializeComponent();
            size = startSize;
            xCoord = x;
            yCoord = y;
            UpdateStats();
        }

        public void UpdateStats()
        {
            tile.Width = size;
            tile.Height = size;
            _margin.Left = size * xCoord;
            _margin.Top = size * yCoord;
        }

        private int size { get { return size; } set { size = value; } }
        private int xCoord { get { return xCoord; } set { xCoord = value; } }
        private int yCoord { get { return yCoord; } set { yCoord = value; } }
    }
}
