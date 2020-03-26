using Game.Tiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Game.Enemies
{
    public abstract class Enemy : Tile
    {
        protected int health = 1;

        public abstract Enemy Punch();
    }
}
