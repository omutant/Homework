﻿using Game.Tiles;
using Game.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Input input;
        public MapReader mapReader;
        public TileMap tileMap;
        public TPlayer player;
        public Camera mainCam;

        public int mapSizeX = 20;
        public int mapSizeY = 20;
        private readonly int _playerOriginX = 0;
        private readonly int _playerOriginY = 0;
        public int playerCoordX = 4;
        public int playerCoordY = 4;

        public MainWindow()
        {
            _playerOriginX = playerCoordX;
            _playerOriginY = playerCoordY;
            InitializeComponent();
            input = new Input();
            mapReader = new MapReader();
            tileMap = new TileMap(mapSizeX, mapSizeY);
            player = new TPlayer(playerCoordX, playerCoordY);
            mainCam = new Camera();
        }
        public void RouteKey(object sender, KeyEventArgs e)
        {
            input.KeyHandler(e.Key);
        }

        public void Reset()
        {
            MainMap.Children.Clear();
            mapReader = new MapReader();
            tileMap = new TileMap(mapSizeX, mapSizeY);
            player.Setup(_playerOriginX, _playerOriginY);
            winScreen.Visibility = Visibility.Hidden;
            UI.Visibility = Visibility.Visible;
            Player_Healthbar.Value = player.maxHealth;
            Enemy_Healthbar.Value = 0;
            /* Hard reset
                Process.Start("Game");
                Application.Current.Shutdown();
            */
        }

        public void EndGame(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
