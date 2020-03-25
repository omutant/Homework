using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Game.Player
{
    public class Collission
    {
        readonly MainWindow mainW;
        public Collission()
        {
            mainW = (MainWindow)Application.Current.MainWindow;
        }
        // Main Check void
        // Clockwise direction check ( 1 = up. 2 = right. 3 = down. 4 = left)
        public bool CanMoveCheck(int direction)
        {
            bool result;
            result = Solids(direction);
            // Edge();
            // Pickups();
            // Enemies();
            return result;
        }

        bool Solids(int direction){
            switch (direction)
            {
                case 1:
                    if (mainW.tileMap.tileArr[mainW.playerCoordX, mainW.playerCoordY -1].canWalkOn)
                        return true;
                    else
                        return false;
                case 2:
                    if (mainW.tileMap.tileArr[mainW.playerCoordX + 1, mainW.playerCoordY].canWalkOn)
                        return true;
                    else
                        return false;
                case 3:
                    if (mainW.tileMap.tileArr[mainW.playerCoordX, mainW.playerCoordY +1].canWalkOn)
                        return true;
                    else
                        return false;
                case 4:
                    if(mainW.tileMap.tileArr[mainW.playerCoordX - 1, mainW.playerCoordY].canWalkOn)
                        return true;
                    else
                        return false;
            }
            return true;
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
