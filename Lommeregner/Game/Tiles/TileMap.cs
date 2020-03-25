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

        public Tile[,] tileArr;

        public int tileSize = 32;

        public TileMap(int mapSizeX, int mapSizeY)
        {
            mainW = (MainWindow)Application.Current.MainWindow;
            tileArr = new Tile[mapSizeX, mapSizeY];
            
            MapSetup();
        }



        public void UpdateTiles()
        {
            ClearMap();
            MapSetup();
        }

        public void MapSetup()
        {
            //mainW.mapReader.ReadMap("TestingMap");
            for (int x = 0; x < tileArr.GetLength(0); x++)
            {
                for (int y = 0; y < tileArr.GetLength(1); y++)
                {
                    tileArr[x, y] = mainW.mapReader.GetTile(x,y);
                    //Tile tempTile;
                    // Replace this line with _mapReader.GetTile(x,y)
                    /*
                    if (x == 0 || y == 0 || x == tileArr.GetLength(0) -1 || y == tileArr.GetLength(1) -1)
                    {
                        tempTile = new WallTile();
                    }
                    else
                    {
                        tempTile = new FloorTile();
                    }
                    */
                    tileArr[x, y].UpdateSize(tileSize);
                    tileArr[x, y].SetCoords(x,y);

                    //tempTile.UpdateSize(tileSize);
                    //tempTile.SetCoords(x, y);
                    //tileArr[x, y] = tempTile;
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
}
