using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Player
{
    class Collission
    {
        // Main Check void
        public void Check()
        {
            // Solids();
            // Edge();
            // Pickups();
            // Enemies();
        }
        // 1. Check for Solid blocks
        /*
            get player coordinates --> get block at the index the player wants to move to --> reject move if(map[x,y].tile.isSolid == true)
        */
        // 2. Check for map Edge
        /*
            get map size --> get player coordinates --> reject move if(player.coordinates >= map.size)
        */
        // 3. Check for Check for pickups
        /*
            get player coordinates --> get block at the index the player wants to move to --> allow move if(map[x,y].tile.hasPickup == true)
            --> apply pickup to player --> remove pickup from tile --> set map[x,y].tile.hasPickup to false
        */
        // 4. Check for Check for Enemies
        /*
            get play coordinates -->
        */
    }
}
