using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;

namespace Game.Tiles
{
    public interface ITile
    {
        public void UpdateStats();

        public Rectangle tile
        {
            get { return tile; }
            set { tile = value; }
        }
        private int size { get { return size; } set { size = value; } }
        private int xCoord { get { return xCoord; } set { xCoord = value; } }
        private int yCoord { get { return yCoord; } set { yCoord = value; } }
    }
}
