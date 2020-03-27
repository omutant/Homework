using Game.Enemies;
using Game.Pickups;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Game.Player
{
    public class Collission
    {
        int px = 0;
        int py = 0;
        readonly MainWindow _mainW;
        public Collission() => _mainW = (MainWindow)Application.Current.MainWindow;
        public bool CanMoveCheck(int direction)
        {
            return
                Edge(direction) &&
                Solids(direction) &&
                Pickups(direction) &&
                Enemies(direction)
                ? true : false;
        }
        bool Edge(int direction)
        {
            int px = _mainW.playerCoordX;
            int py = _mainW.playerCoordY;
            switch (direction)
            {
                case 1: return py > 0 ? true : false;
                case 2: return px < _mainW.mapSizeX - 1 ? true : false;
                case 3: return py < _mainW.mapSizeY - 1 ? true : false;
                case 4: return px > 0 ? true : false;
                default: break;
            }
            return false;
        }
        bool Solids(int direction)
        {
            int px = _mainW.playerCoordX;
            int py = _mainW.playerCoordY;
            switch (direction)
            {
                case 1: return !_mainW.tileMap.tileArr[px, py - 1].isSolid ? true : false;
                case 2: return !_mainW.tileMap.tileArr[px + 1, py].isSolid ? true : false;
                case 3: return !_mainW.tileMap.tileArr[px, py + 1].isSolid ? true : false;
                case 4: return !_mainW.tileMap.tileArr[px - 1, py].isSolid ? true : false;
                default: break;
            }
            return true;
        }
        bool Pickups(int direction)
        {
            px = _mainW.playerCoordX;
            py = _mainW.playerCoordY;
            switch (direction)
            {
                case 1:
                    py -= 1;
                    break;
                case 2:
                    px += 1;
                    break;
                case 3:
                    py += 1;
                    break;
                case 4:
                    px -= 1;
                    break;
            }
            if (_mainW.tileMap.objArr[px, py] != null)
                _mainW.tileMap.objArr[px, py].Take();
            return true;
        }
        bool Enemies(int direction)
        {
            px = _mainW.playerCoordX;
            py = _mainW.playerCoordY;
            Enemy target = null;
            switch (direction)
            {
                case 1:
                    py -= 1;
                    target = _mainW.tileMap.enemyArr[px, py];
                    break;
                case 2:
                    px += 1;
                    target = _mainW.tileMap.enemyArr[px, py];
                    break;
                case 3:
                    py += 1;
                    target = _mainW.tileMap.enemyArr[px, py];
                    break;
                case 4:
                    px -= 1;
                    target = _mainW.tileMap.enemyArr[px, py];
                    break;
            }
            if (target != null)
            {
                if (target.isSolid)
                {
                    _mainW.Enemy_Healthbar.Maximum = target.maxHealth;
                    _mainW.Enemy_Healthbar.Value = target.health;
                    
                    _mainW.tileMap.enemyArr[px, py] =
                    target.Punch(_mainW.player.Attack(target.health,
                        target.strength));
                    return false;
                }
            }
            else
            {
                return true;
            }
            return true;
        }
    }
}
