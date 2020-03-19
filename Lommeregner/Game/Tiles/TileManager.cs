using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Controls;

namespace Game.Tiles
{
    class TileManager
    {
        List<ITile> tiles = new List<ITile>();
        
        Canvas instantiateTiles()
        {
            Canvas newCan = new Canvas();
            tiles.Add(new WallTile(32,1,1));
            for (int i = 0; i < tiles.Count; i++)
            {
                Rectangle r = tiles[i].tile;
                newCan.Children.Add(r);
            }
            return new Canvas();
        }
    }
}
