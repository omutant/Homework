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
        public Barrel()
        {
            isSolid = true;
            NewTile("pack://application:,,,/Sprites/Barrel_Enemy.png");
        }

        public override Enemy Punch()
        {
            if (health > 0)
            {
                //MessageBox.Show(health + " health left");
                health--;
                return this;
            }
            else
            {
                tile.Visibility = Visibility.Hidden;
                return null;
            }
        }
    }
}
