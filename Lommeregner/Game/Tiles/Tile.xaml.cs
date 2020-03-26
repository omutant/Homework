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
    public class Tile
    {
        public void SetTileSize(int newSize) => _size = newSize;
        public Rectangle tile;
        public bool isSolid = false;

        private Thickness _margin;
        private ImageBrush _textureBrush;
        private readonly int _tileSize = 32;
        private int _size = 0;
        private int _xCoord = 0;
        private int _yCoord = 0;

        public void NewTile(string texturePath)
        {
            SetTileSize(_tileSize);
            SetTexture(texturePath);
            tile = new Rectangle() 
            { 
                Fill = _textureBrush
            };
            UpdateTile();
        }

        public void SetCoords(int x, int y)
        {
            _xCoord = x;
            _yCoord = y;
            UpdateTile();
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

        public void UpdateTile()
        {
            tile.Height = _size;
            tile.Width = _size;
            tile.Fill = _textureBrush;
            _margin.Left = _size * _xCoord;
            _margin.Top = _size * _yCoord;
            tile.Margin = _margin;
        }

    }
}
