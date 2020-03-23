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
        readonly MainWindow mainW;
        Rectangle playerRect;
        ImageBrush _textureBrush;
        public Thickness playerOff;
        public TPlayer(int x, int y)
        {
            mainW = (MainWindow)Application.Current.MainWindow;
            Setup(x,y);
        }

        public void Setup(int x, int y)
        {
            playerRect = new Rectangle();

            SetMargin(x,y);
            SetTexture();
            playerRect.Width = mainW.input.moveLength;
            playerRect.Height = mainW.input.moveLength;
            playerRect.Margin = playerOff;
            playerRect.Fill = _textureBrush;
            Panel.SetZIndex(playerRect, 2);

            mainW.MainMap.Children.Add(playerRect);
        }

        void SetMargin(int x, int y)
        {
            playerOff.Left = mainW.input.moveLength * x;
            playerOff.Top = mainW.input.moveLength * y;
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
            if (isMovingHorizontal){
                playerOff.Left += offset;
                mainW.playerCoordX = (int)(playerOff.Left / mainW.input.moveLength);
            }
            else{
                playerOff.Top += offset;
                mainW.playerCoordY = (int)(playerOff.Top / mainW.input.moveLength);
            }
            playerRect.Margin = playerOff;
        }
    }
}
