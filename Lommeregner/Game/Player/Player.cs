using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game.Player
{
    public class TPlayer
    {
        public Thickness playerOffset;

        readonly MainWindow _mainW;
        Rectangle _playerRect;
        ImageBrush _textureBrush;

        public TPlayer(int x, int y)
        {
            _mainW = (MainWindow)Application.Current.MainWindow;
            Setup(x, y);
        }

        public void Setup(int x, int y)
        {
            SetMargin(x, y);
            SetTexture();
            _playerRect = new Rectangle()
            {
                Width = _mainW.input.moveLength,
                Height = _mainW.input.moveLength,
                Margin = playerOffset,
                Fill = _textureBrush
            };
            Panel.SetZIndex(_playerRect, 3);
            _mainW.MainMap.Children.Add(_playerRect);
        }

        void SetMargin(int x, int y)
        {
            playerOffset.Left = _mainW.input.moveLength * x;
            playerOffset.Top = _mainW.input.moveLength * y;
        }
        void SetTexture()
        {
            _textureBrush = new ImageBrush();
            BitmapImage textureImg = new BitmapImage();
            textureImg.BeginInit();
            textureImg.UriSource = new Uri("pack://application:,,,/Sprites/Player_Base.png");
            textureImg.EndInit();
            _textureBrush.ImageSource = textureImg;
        }

        public void Move(int offset, bool isMovingHorizontal)
        {
            if (isMovingHorizontal)
            {
                playerOffset.Left += offset;
                _mainW.playerCoordX = (int)(playerOffset.Left / _mainW.input.moveLength);
            }
            else
            {
                playerOffset.Top += offset;
                _mainW.playerCoordY = (int)(playerOffset.Top / _mainW.input.moveLength);
            }
            _playerRect.Margin = playerOffset;
        }
    }
}
