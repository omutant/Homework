using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows;
using System.Reflection;
using Microsoft.Win32;
using Game.Pickups;
using Game.Enemies;

namespace Game.Tiles
{
    public class MapReader
    {
        public Tile GetTile(int x, int y) => _tempTileArr[x, y];
        public Pickup GetObject(int x, int y) => _tempObjArr[x, y];
        public Enemy GetEnemy(int x, int y) => _tempEnemyArr[x, y];

        readonly MainWindow _mainW;
        readonly string[] _properties = { "Title", "Description", "MapData", "UnitData" };
        readonly Tile[,] _tempTileArr;
        readonly Pickup[,] _tempObjArr;
        readonly Enemy[,] _tempEnemyArr;
        public MapReader()
        {
            _mainW = (MainWindow)Application.Current.MainWindow;
            _tempTileArr = new Tile[_mainW.mapSizeX, _mainW.mapSizeY];
            _tempObjArr = new Pickup[_mainW.mapSizeX, _mainW.mapSizeY];
            _tempEnemyArr = new Enemy[_mainW.mapSizeX, _mainW.mapSizeY];
            ReadMap("TestingMap");
        }

        // Unused because it isn't finished yet!
        /* Write Map (Not finished)
        void WriteMap()
        {
            // Uncomment to set save path.
            SaveFileDialog sav = new SaveFileDialog
            {
                FileName = "TestingMap.txt"
            };
            sav.ShowDialog();
            File.WriteAllLines(sav.FileName, DefaultText());
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
            _properties[0] + "=",
            _properties[1] + "=",
            _properties[2] + "="
        };
            for (int y = 0; y < _mainW.mapSizeY; y++)
            {
                string width = "";
                for (int x = 0; x < _mainW.mapSizeX; x++)
                {
                    width += " 0";
                }
                content.Add(width);
            }
            content.Add(_properties[3] + "=");
            for (int y = 0; y < _mainW.mapSizeY; y++)
            {
                string width = "";
                for (int x = 0; x < _mainW.mapSizeX; x++)
                {
                    width += " N";
                }
                content.Add(width);
            }

            return content;
        }
        */



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
                    for (int i = 0; i < _properties.Length; i++)
                        if (output.StartsWith(_properties[i]))
                            switch (i)
                            {
                                case 2:
                                    for (int y = 0; y < _mainW.mapSizeY; y++)
                                        SetupTiles(reader.ReadLine(), y);
                                    break;
                                case 3:
                                    for (int y = 0; y < _mainW.mapSizeY; y++)
                                        SetupObjects(reader.ReadLine(), y);
                                    break;
                            }
            }
        }
        void SetupTiles(string input, int y)
        {
            string[] inputs = input.Split(' ');
            for (int x = 0; x < inputs.Length; x++)
                switch (inputs[x])
                {
                    case "0":
                        _tempTileArr[x, y] = new WallTile();
                        break;
                    case "1":
                        _tempTileArr[x, y] = new FloorTile();
                        break;
                }
        }
        void SetupObjects(string input, int y)
        {
            string[] inputs = input.Split(' ');
            for (int x = 0; x < inputs.Length; x++)
                switch (inputs[x])
                {
                    case "4":
                        _tempObjArr[x, y] = new Health_Pickup();
                        break;
                    case "5":
                        _tempEnemyArr[x, y] = new Barrel();
                        break;
                }
        }
    }
}
