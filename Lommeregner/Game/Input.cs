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
        Thickness thiccHolder;
        int moveIncrement = 32;
        public Input()
        {
            mainW = (MainWindow)Application.Current.MainWindow;
        }
        public void KeyHandler(Key input)
        {
            switch (input)
            {
                case Key.Left:
                    thiccHolder.Left -= moveIncrement;
                    break;
                case Key.Right:
                    thiccHolder.Left += moveIncrement;
                    break;
                case Key.Up:
                    thiccHolder.Top -= moveIncrement;
                    break;
                case Key.Down:
                    thiccHolder.Top += moveIncrement;
                    break;
            }
            mainW.MainMap.Margin = thiccHolder;
        }
    }
}
