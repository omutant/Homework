using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Game.Enemies
{
    class Orc : Enemy
    {
        
        public Orc()
        {
            maxHealth = 5;
            health = maxHealth;
            strength = 3;
            isSolid = true;
            NewTile("pack://application:,,,/Sprites/Orc_Enemy.png");
        }
        public override Enemy Punch(int strength)
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
                isSolid = false;
                return null;
            }
        }
    }
}
