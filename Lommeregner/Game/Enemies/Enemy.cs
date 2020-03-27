using Game.Tiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Game.Enemies
{
    public abstract class Enemy : Tile
    {
        public string name = "";
        public int maxHealth = 10;
        public int health = 10;
        public int strength = 0;

        public abstract Enemy Punch(int damage);
    }
}
