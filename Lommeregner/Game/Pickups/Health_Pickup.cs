using Game.Tiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game.Pickups
{
    public class Health_Pickup : Pickup
    {
        private readonly int _healValue = 15;
        readonly MainWindow _mainW;
        public Health_Pickup()
        {
            _mainW = (MainWindow)Application.Current.MainWindow;
            name = "Health Pickup";
            NewTile("pack://application:,,,/Sprites/Health_Pickup.png");
        }

        public override void Take()
        {
            if(_mainW.player.pHealth != _mainW.player.maxHealth)
            {
                if (_mainW.player.pHealth + _healValue > _mainW.player.maxHealth)
                    _mainW.player.pHealth = _mainW.player.maxHealth;
                else{
                    _mainW.player.pHealth += _healValue;
                }
            }
            _mainW.Player_Healthbar.Value = _mainW.player.pHealth;
            tile.Visibility = Visibility.Hidden;
            _mainW.tileMap.objArr[_xCoord, _yCoord] = null;
            _mainW.mapReader._tempObjArr[_xCoord, _yCoord] = null;
        }
    }
}
