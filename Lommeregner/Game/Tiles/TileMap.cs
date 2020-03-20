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
        List<Tile> tiles = new List<Tile>();
        MainWindow mainW;
        /*Only set from other classes*/
        private int mapX = 0;
        private int mapY = 0;
        private int tileSize = 32;

        public TileMap(int mapSizeX,int mapSizeY)
        {
            mainW = (MainWindow)Application.Current.MainWindow;
            mapX = mapSizeX;
            mapY = mapSizeY;
            InstantiateTiles();
        }

        public void Zoom(bool isZoomingIn)
        {
            if (isZoomingIn && tileSize <= 128)
            {
                tileSize *= 2;
                UpdateTiles();
            }
            else if (!isZoomingIn && tileSize >= 8)
            {
                tileSize /= 2;
                UpdateTiles();
            }
        }

        public void UpdateTiles()
        {
            ClearMap();
            for (int x = 0; x < mapX; x++)
            {
                for (int y = 0; y < mapY; y++)
                {
                    Tile tempTile = new FloorTile();
                    tempTile.UpdateSize(tileSize);
                    tempTile.SetCoords(x, y);
                    tiles.Add(tempTile);
                }
            }
            TileInstantiation();
        }

        public void InstantiateTiles()
        {
            for (int x = 0; x < mapX; x++)
            {
                for (int y = 0; y < mapY; y++)
                {
                    Tile tempTile = new FloorTile();
                    tempTile.SetCoords(x, y);
                    tiles.Add(tempTile);
                }
            }
            TileInstantiation();
        }

        void ClearMap()
        {
            mainW.MainMap.Children.Clear();
            tiles.Clear();
        }
        void TileInstantiation()
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                mainW.MainMap.Children.Add(tiles[i].tile);
            }
        }


    }
}
