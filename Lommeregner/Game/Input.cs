using Game.Player;
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
        readonly Collission colCheck;
        Thickness mapOffset;
        public int moveLength = 32;
        public Input()
        {
            mainW = (MainWindow)Application.Current.MainWindow;
            colCheck = new Collission();
        }

        public void SetCam2Speed(int newSpeed)
        {
            moveLength = newSpeed;
        }
        public void KeyHandler(Key input)
        {
            //MessageBox.Show(input.ToString());
            switch (input)
            {
                #region moveCam
                case Key.Left:
                    if (colCheck.CanMoveCheck(4))
                    {
                        mainW.mainCam.FollowCam(2);
                        mapOffset.Left -= moveLength;
                        mainW.player.Move(-moveLength, true, mainW.player.isDead);
                    }
                    break;
                case Key.Right:
                    if (colCheck.CanMoveCheck(2))
                    {
                        mainW.mainCam.FollowCam(4);
                        mapOffset.Left += moveLength;
                        mainW.player.Move(moveLength, true, mainW.player.isDead);
                    }
                    break;
                case Key.Up:
                    if (colCheck.CanMoveCheck(1))
                    {
                        mainW.mainCam.FollowCam(1);
                        mapOffset.Top -= moveLength;
                        mainW.player.Move(-moveLength, false, mainW.player.isDead);
                    }
                    break;
                case Key.Down:
                    if (colCheck.CanMoveCheck(3))
                    {
                        mainW.mainCam.FollowCam(3);
                        mapOffset.Top += moveLength;
                        mainW.player.Move(moveLength, false, mainW.player.isDead);
                    }
                    break;
                #endregion moveCam
                #region zoomCam
                case Key.Add:
                    mainW.mainCam.Zoom(true);
                    break;
                case Key.Subtract:
                    mainW.mainCam.Zoom(false);
                    break;
                #endregion zoomCam
                #region debugger
                case Key.F12:
                    if (mainW.debugger.Visibility == Visibility.Visible)
                    {
                        mainW.debugger.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        mainW.debugger.Visibility = Visibility.Visible;
                    }
                    break;
                #endregion debugger
                #region specials
                case Key.Enter:
                case Key.Escape:
                    if (mainW.player.isDead)
                        Application.Current.Shutdown();
                    break;
                    #endregion specials
            }
            mainW.mainCam.DebuggerUpdate();
        }
    }
}
