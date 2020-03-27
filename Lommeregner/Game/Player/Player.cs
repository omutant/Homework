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
        public int maxHealth = 30;
        public int pHealth = 30;
        public bool isDead = false;
        private readonly int _strength = 4;

        public TPlayer(int x, int y)
        {
            _mainW = (MainWindow)Application.Current.MainWindow;
            _mainW.Player_Healthbar.Maximum = pHealth;
            _mainW.Player_Healthbar.Value = pHealth;
            Setup(x, y);
        }

        public int Attack(int health, int attack)
        {
            pHealth -= attack;
            _mainW.Player_Healthbar.Value = pHealth;
            if (pHealth <= 0)
            {
                _mainW.winText.Text = ":C You died :C";
                _mainW.winScreen.Visibility = Visibility.Visible;
                _mainW.UI.Visibility = Visibility.Hidden;
                isDead = true;

            }
            return health - _strength;
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

        public void Move(int offset, bool isMovingHorizontal, bool isDead)
        {
            if (!isDead)
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
