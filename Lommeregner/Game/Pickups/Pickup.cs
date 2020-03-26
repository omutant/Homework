using Game.Tiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Game.Pickups
{
    public abstract class Pickup : Tile
    {
        protected string name;

        public abstract void Take();

    }
}
