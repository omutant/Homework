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
    /// Interaction logic for Tile.xaml
    /// </summary>
    public partial class Tile : UserControl
    {
        public Rectangle tile;

        private string inputTexture = "";
        private Thickness _margin;
        private ImageBrush _textureBrush;
        private readonly int _tileSize = 32;

        public void Setup(string texturePath)
        {
            tile = new Rectangle();
            inputTexture = texturePath;

            SetTexture(inputTexture);
            UpdateSize(_tileSize);
            SetTileStats();
            
            InitializeComponent();
        }

        public void UpdateSize(int newSize)
        {
            size = newSize;
        }

        public void SetCoords(int x, int y)
        {
            xCoord = x;
            yCoord = y;
            SetTileStats();
            SetMargins();
            //UpdateSize(_tileSize);
        }

        public void SetTexture(string texturePath)
        {
            _textureBrush = new ImageBrush();
            BitmapImage textureImg = new BitmapImage();
            textureImg.BeginInit();
            textureImg.UriSource = new Uri(texturePath);
            textureImg.EndInit();
            _textureBrush.ImageSource = textureImg;
        }

        void SetMargins()
        {
            _margin.Left = size * xCoord;
            _margin.Top = size * yCoord;
            tile.Margin = _margin;
        }

        public void SetTileStats()
        {
            tile.Height = size;
            tile.Width = size;
            tile.Fill = _textureBrush;

            //SetCoords(XCoord, YCoord);

            SetMargins();
        }
        private int size = 0;
        private int xCoord = 0;
        private int yCoord = 0;
    }
}
