using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game
{
    public class Input
    {
        readonly MainWindow mainW;
        Thickness mapOffset;
        public int moveLength = 32;
        public Input()
        {
            mainW = (MainWindow)Application.Current.MainWindow;
        }

        public void SetCam2Speed(int newSpeed)
        {
            moveLength = newSpeed;
        }
        public void KeyHandler(Key input)
        {
            //MessageBox.Show(e.Key.ToString());
            switch (input)
            {
                #region moveCam
                case Key.Left:
                    if (mainW.playerCoordX > 0)
                    {
                        mainW.mainCam.FollowCam(2);
                        mapOffset.Left -= moveLength;
                        mainW.player.Move(-moveLength, true);
                    }
                    break;
                case Key.Right:
                    if (mainW.playerCoordX < mainW.mapSizeX - 1)
                    {
                        mainW.mainCam.FollowCam(4);
                        mapOffset.Left += moveLength;
                        mainW.player.Move(moveLength, true);
                    }
                    break;
                case Key.Up:
                    if (mainW.playerCoordY > 0)
                    {
                        mainW.mainCam.FollowCam(1);
                        mapOffset.Top -= moveLength;
                        mainW.player.Move(-moveLength, false);
                    }
                    break;
                case Key.Down:
                    if (mainW.playerCoordY < mainW.mapSizeY - 1)
                    {
                        mainW.mainCam.FollowCam(3);
                        mapOffset.Top += moveLength;
                        mainW.player.Move(moveLength, false);
                    }
                    break;
                #endregion moveCam
                #region zoomCam
                case Key.Add:
                    mainW.tileMap.Zoom(true);
                    break;
                case Key.Subtract:
                    mainW.tileMap.Zoom(false);
                    break;
                #endregion zoomCam
                #region debugger
                case Key.F12:
                    if(mainW.debugger.Visibility == Visibility.Visible)
                    {
                        mainW.debugger.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        mainW.debugger.Visibility = Visibility.Visible;
                    }
                    break;
                    #endregion debugger
            }
            mainW.mainCam.DebuggerUpdate();
        }
    }
}
