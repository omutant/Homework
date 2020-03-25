using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows;
using System.Reflection;
using Microsoft.Win32;

namespace Game.Tiles
{
    public class MapReader
    {
        readonly MainWindow mainW;
        readonly string[] properties = { "Title", "Description", "MapData", "UnitData" };
        readonly Tile[,] tempTileArr;
        public MapReader()
        {
            mainW = (MainWindow)Application.Current.MainWindow;
            tempTileArr = new Tile[mainW.mapSizeX, mainW.mapSizeY];
            ReadMap("TestingMap");
            //WriteMap();
        }

        // Unused because it isn't finished yet!
        void WriteMap()
        {
            // Uncomment to reset save path. Set to MapData by default
            SaveFileDialog sav = new SaveFileDialog
            {
                FileName = "TestingMap.txt"
            };
            sav.ShowDialog();
            string path = sav.FileName;
            File.WriteAllLines(path, DefaultText());
        }
        public Tile GetTile(int x, int y)
        {
            return tempTileArr[x, y];
        }
        List<string> DefaultText()
        {
            List<string> content = new List<string>
            {
                "# Tile map for a rogue-like made in WPF ",
                "# Available tiles:",
                "# 0 - Wall tile",
                "# 1 - Floor tile",
                "# 2 - Water Tile",
                "# 3 - Grass tile",
                "# Available units:",
                "# N - Null (Can't place items here)",
                "# W - Water (Can only place select items here. Marked with W in the unit description)",
                "# G - Ground (Can only place select items here. Marked with G in the unit description)",
                "# 1 - Player",
                "# 2 - Enemy",
                "# 3 - Goal",
                "# 4 - Health Pickup",
                "# 5 - Breakable box",
                "# ",
                properties[0] + "=",
                properties[1] + "=",
                properties[2] + "="
            };
            for (int y = 0; y < mainW.mapSizeY; y++)
            {
                string width = "";
                for (int x = 0; x < mainW.mapSizeX; x++)
                {
                    width += " 0";
                }
                content.Add(width);
            }
            content.Add(properties[3] + "=");
            for (int y = 0; y < mainW.mapSizeY; y++)
            {
                string width = "";
                for (int x = 0; x < mainW.mapSizeX; x++)
                {
                    width += " N";
                }
                content.Add(width);
            }

            return content;
        }
        public void ReadMap(string mapSelection)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string tempPath = "Game.MapData." + mapSelection + ".txt";
            StreamReader reader = new StreamReader(assembly.GetManifestResourceStream(tempPath));
            string output;

            while (!reader.EndOfStream)
            {
                output = reader.ReadLine();
                if (!output.StartsWith('#'))
                {
                    for (int i = 0; i < properties.Length; i++)
                    {
                        if (output.StartsWith(properties[i]))
                        {
                            switch (i)
                            {
                                case 0:
                                    break;
                                case 1:
                                    break;
                                case 2:
                                    for (int y = 0; y < mainW.mapSizeY; y++)
                                    {
                                        output = reader.ReadLine();
                                        string[] inputs = output.Split(' ');
                                        for (int x = 0; x < inputs.Length; x++)
                                        {
                                            switch(inputs[x])
                                            {
                                                case "0":
                                                    tempTileArr[x, y] = new WallTile();
                                                    break;
                                                case "1":
                                                    tempTileArr[x, y] = new FloorTile();
                                                    break;
                                                default:
                                                    MessageBox.Show("Error: Invalid input in tileMap!");
                                                    break;
                                            }
                                        }
                                    }
                                    break;
                                case 3:
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
