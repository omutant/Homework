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
        public Health_Pickup()
        {
            name = "Health Pickup";
            NewTile("pack://application:,,,/Sprites/Health_Pickup.png");
        }

        public override void Take()
        {
            //MessageBox.Show("Health up!");
            tile.Visibility = Visibility.Hidden;
        }
    }
}
