using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Game.Enemies
{
    class Orc : Enemy
    {
        private string[] names = { "Herbert", "Alfred", "Monawa", "Moruug", "Little timmy" };
        private string[] titles = { "brave", "bi-curious", "bum scratcher", "strange", "ugly" };
        public Orc()
        {
            maxHealth = 5;
            health = maxHealth;
            strength = 3;
            isSolid = true;
            Random r = new Random();
            name = names[r.Next(0, names.Length)] + " the " + titles[r.Next(0, names.Length)];
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
