﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Tiles
{
    class WallTile : Tile
    {
        public WallTile() {
            canWalkOn = false;
            Setup("pack://application:,,,/Textures/Stone_Wall_Tile_Base.png"); 
        }
    }
}
