using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace Game.Tiles
{
    public class TileMap
    {
        readonly MainWindow mainW;

        readonly Tile[,] tileArr;

        private int tileSize = 32;

        public TileMap(int mapSizeX, int mapSizeY)
        {
            mainW = (MainWindow)Application.Current.MainWindow;
            tileArr = new Tile[mapSizeX, mapSizeY];
            MapSetup();
        }

        public void Zoom(bool isZoomingIn)
        {
            if (isZoomingIn && tileSize <= 128)
            {
                tileSize *= 2;
                mainW.input.moveLength = tileSize;
                UpdateTiles();
            }
            else if (!isZoomingIn && tileSize >= 8)
            {
                tileSize /= 2;
                mainW.input.moveLength = tileSize;
                UpdateTiles();
            }
        }

        public void UpdateTiles()
        {
            ClearMap();
            MapSetup();
        }

        public void MapSetup()
        {
            for (int x = 0; x < tileArr.GetLength(0); x++)
            {
                for (int y = 0; y < tileArr.GetLength(1); y++)
                {
                    Tile tempTile = new FloorTile();
                    tempTile.UpdateSize(tileSize);
                    tempTile.SetCoords(x, y);
                    tileArr[x, y] = tempTile;
                }
            }
            for (int x = 0; x < tileArr.GetLength(0); x++)
            {
                for (int y = 0; y < tileArr.GetLength(1); y++)
                {
                    Panel.SetZIndex(tileArr[x, y].tile, 1);
                    mainW.MainMap.Children.Add(tileArr[x,y].tile);
                }
            }
        }

        void ClearMap()
        {
            mainW.MainMap.Children.Clear();
            mainW.player.Setup(mainW.playerCoordX, mainW.playerCoordY);
        }


    }

    class TxtReader
    {
        /* map txt contents
         
            #Tile map for a rogue-like made in WPF
            Title= New Map
            Description= 

        */

        // void WriteNewMap(int xSize, int ySize) - Fill a map with floor tiles. Write a description of how to edit the map at the top of the document
        // void ReadMap(string mapName, tile[,] map) - replace the old map contents with the new ones from the doc
    }
}
