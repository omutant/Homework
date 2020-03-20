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
        MainWindow mainW;
        Thickness mapOffset;
        public int CameraSpeed = 32;
        public Input()
        {
            mainW = (MainWindow)Application.Current.MainWindow;
        }
        public void KeyHandler(Key input)
        {
            //MessageBox.Show(e.Key.ToString());
            switch (input)
            {
                #region moveCam
                case Key.Left:
                    mapOffset.Left -= CameraSpeed;
                    break;
                case Key.Right:
                    mapOffset.Left += CameraSpeed;
                    break;
                case Key.Up:
                    mapOffset.Top -= CameraSpeed;
                    break;
                case Key.Down:
                    mapOffset.Top += CameraSpeed;
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
            }
            mainW.MainMap.Margin = mapOffset;
        }
    }
}
