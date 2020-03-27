using Game.Pickups;
using Game.Tiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Game.Enemies
{
    class Barrel : Enemy
    {
        readonly MainWindow _mainW;
        public Barrel()
        {
            _mainW = (MainWindow)Application.Current.MainWindow;
            maxHealth = 2;
            health = maxHealth;
            isSolid = true;
            NewTile("pack://application:,,,/Sprites/Barrel_Enemy.png");
        }

        public override Enemy Punch(int strength)
        {
            if (health > 0)
            {
                health--;
                return this;
            }
            else
            {
                SpawnPickup();
                return null;
            }
        }

        private void SpawnPickup()
        {
            tile.Visibility = Visibility.Hidden;
            isSolid = false;
            _mainW.mapReader._tempObjArr[_xCoord, _yCoord] = new Health_Pickup();
            _mainW.tileMap.UpdateTiles();
        }
    }
}
