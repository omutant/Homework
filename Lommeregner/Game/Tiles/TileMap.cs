using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using Game.Pickups;
using Game.Enemies;

namespace Game.Tiles
{
    public class TileMap
    {
        readonly MainWindow mainW;

        public Tile[,] tileArr;
        public Pickup[,] objArr;
        public Enemy[,] enemyArr;

        public int tileSize = 32;

        public TileMap(int mapSizeX, int mapSizeY)
        {
            mainW = (MainWindow)Application.Current.MainWindow;
            tileArr = new Tile[mapSizeX, mapSizeY];
            objArr = new Pickup[mapSizeX, mapSizeY];
            enemyArr = new Enemy[mapSizeX, mapSizeY];

            MapSetup();
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
                    tileArr[x, y] = mainW.mapReader.GetTile(x, y);
                    tileArr[x, y].SetTileSize(tileSize);
                    tileArr[x, y].SetCoords(x, y);

                    objArr[x, y] = mainW.mapReader.GetObject(x, y);
                    if (objArr[x, y] != null)
                    {
                        objArr[x, y].SetTileSize(tileSize);
                        objArr[x, y].SetCoords(x, y);
                    }

                    enemyArr[x, y] = mainW.mapReader.GetEnemy(x, y);
                    if (enemyArr[x, y] != null)
                    {
                        enemyArr[x, y].SetTileSize(tileSize);
                        enemyArr[x, y].SetCoords(x, y);
                    }
                }
            }
            for (int x = 0; x < tileArr.GetLength(0); x++)
            {
                for (int y = 0; y < tileArr.GetLength(1); y++)
                {
                    Panel.SetZIndex(tileArr[x, y].tile, 1);
                    mainW.MainMap.Children.Add(tileArr[x, y].tile);
                    if (objArr[x, y] != null)
                    {
                        Panel.SetZIndex(objArr[x, y].tile, 3);
                        mainW.MainMap.Children.Add(objArr[x, y].tile);
                    }
                    if (enemyArr[x, y] != null)
                    {
                        Panel.SetZIndex(enemyArr[x, y].tile, 3);
                        mainW.MainMap.Children.Add(enemyArr[x, y].tile);
                    }

                }
            }
        }

        void ClearMap()
        {
            mainW.MainMap.Children.Clear();
            mainW.player.Setup(mainW.playerCoordX, mainW.playerCoordY);
        }
    }
}
