using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Game.Pickups
{
    class Goal : Pickup
    {
        readonly MainWindow _mainW;
        public Goal()
        {
            _mainW = (MainWindow)Application.Current.MainWindow;
            NewTile("pack://application:,,,/Sprites/Goal_Pickup.png");
        }
        public override void Take()
        {
            _mainW.winText.Text = "!!! :D YOU WIN :D !!!";
            _mainW.winScreen.Visibility = Visibility.Visible;
            _mainW.UI.Visibility = Visibility.Hidden;
            _mainW.player.isDead = true;
        }
    }
}
