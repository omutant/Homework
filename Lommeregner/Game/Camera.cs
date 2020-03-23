using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Game
{
    public class Camera
    {
        readonly MainWindow mainW;


        public Camera()
        {
            mainW = (MainWindow)Application.Current.MainWindow;
            DebuggerUpdate();
        }

        public void DebuggerUpdate()
        {
            double topDistance = mainW.MainMap.Margin.Top + mainW.player.playerOff.Top;
            double leftDistance = mainW.MainMap.Margin.Left + mainW.player.playerOff.Left;
            double botDistance = ((int)mainW.RenderSize.Height - mainW.player.playerOff.Top) -mainW.MainMap.Margin.Top;
            double rightDistance = ((int)mainW.RenderSize.Width - mainW.player.playerOff.Left) - mainW.MainMap.Margin.Left;

            /*
            double centerX = mainW.RenderSize.Width / 2;
            double centerY = mainW.RenderSize.Height / 2;
            mainW.debugger_Text.Text = "distance from center - X:" + ((mainW.playerCoordX * mainW.input.moveLength) - centerX) + " Y: " + ((mainW.playerCoordY * mainW.input.moveLength) - centerY);
            */
            mainW.debugger_Text.Text = "Distance to edges" +
                "\nTop: " + topDistance +
                "\nBottom: " + botDistance +
                "\nRight: " + rightDistance +
                "\nLeft: " + leftDistance;

            //FollowCam();
        }

        public void FollowCam(int direction)
        {
            Thickness updatedThicc = mainW.MainMap.Margin;
            switch (direction)
            {
                case 1:
                    if (mainW.MainMap.Margin.Top + mainW.player.playerOff.Top <= 64)
                    {
                        updatedThicc.Top += mainW.input.moveLength;
                    }
                    break;
                case 2:
                    if (mainW.MainMap.Margin.Left + mainW.player.playerOff.Left <= 64)
                    {
                        updatedThicc.Left += mainW.input.moveLength;
                    }
                    break;
                case 3:
                    if ((mainW.RenderSize.Height - mainW.player.playerOff.Top) - mainW.MainMap.Margin.Top <= 128)
                    {
                        updatedThicc.Top -= mainW.input.moveLength;
                    }
                    break;
                case 4:
                    if ((mainW.RenderSize.Width - mainW.player.playerOff.Left) - mainW.MainMap.Margin.Left <= 128)
                    {
                        updatedThicc.Left -= mainW.input.moveLength;
                    }
                    break;
            }
            mainW.MainMap.Margin = updatedThicc;
        }

        /*
            1. Get distance to screen edges 
        */
    }
}
