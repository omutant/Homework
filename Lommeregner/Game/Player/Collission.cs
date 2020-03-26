using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Game.Player
{
    public class Collission
    {
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
            int px = _mainW.playerCoordX;
            int py = _mainW.playerCoordY;
            switch (direction)
            {
                case 1:
                    if (_mainW.tileMap.objArr[px, py - 1] != null)
                        _mainW.tileMap.objArr[px, py - 1].Take();
                    return true;
                case 2:
                    if (_mainW.tileMap.objArr[px + 1, py] != null)
                        _mainW.tileMap.objArr[px + 1, py].Take();
                    return true;
                case 3:
                    if (_mainW.tileMap.objArr[px, py + 1] != null)
                        _mainW.tileMap.objArr[px, py + 1].Take();
                    return true;
                case 4:
                    if (_mainW.tileMap.objArr[px - 1, py] != null)
                        _mainW.tileMap.objArr[px - 1, py].Take();
                    return true;
            }
            return true;
        }
        bool Enemies(int direction)
        {
            int px = _mainW.playerCoordX;
            int py = _mainW.playerCoordY;
            switch (direction)
            {
                case 1:
                    if (_mainW.tileMap.enemyArr[px, py - 1] != null)
                    {
                        if (_mainW.tileMap.enemyArr[px, py - 1].isSolid)
                        {
                            _mainW.tileMap.enemyArr[px, py - 1] =
                            _mainW.tileMap.enemyArr[px, py - 1].Punch();
                            return false;
                        }
                    }
                    return true;
                case 2:
                    if (_mainW.tileMap.enemyArr[px + 1, py] != null)
                    {
                        if (_mainW.tileMap.enemyArr[px + 1, py].isSolid)
                        {
                            _mainW.tileMap.enemyArr[px + 1, py] =
                            _mainW.tileMap.enemyArr[px + 1, py].Punch();
                            return false;
                        }
                    }
                    return true;
                case 3:
                    if (_mainW.tileMap.enemyArr[px, py + 1] != null)
                    {
                        if (_mainW.tileMap.enemyArr[px, py + 1].isSolid)
                        {
                            _mainW.tileMap.enemyArr[px, py + 1] =
                            _mainW.tileMap.enemyArr[px, py + 1].Punch();
                            return false;
                        }
                    }
                    return true;
                case 4:
                    if (_mainW.tileMap.enemyArr[px - 1, py] != null)
                    {
                        if (_mainW.tileMap.enemyArr[px - 1, py].isSolid)
                        {
                            _mainW.tileMap.enemyArr[px - 1, py] =
                            _mainW.tileMap.enemyArr[px - 1, py].Punch();
                            return false;
                        }
                    }
                    return true;
            }
            return true;
        }
    }
}
