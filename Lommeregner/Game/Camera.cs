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
            mainW.debugger_Text.Text = 
                "Controls: \n" +
                " WASD Or Arrow keys - Move \n" +
                " R - Reset - \n" +
                " Plus or minus on numpad - Zoom \n" +
                " I - Toggle this screen";
        }
        public void Zoom(bool isZoomingIn)
        {
            Thickness updatedThickness = mainW.MainMap.Margin;

            if (isZoomingIn && mainW.tileMap.tileSize <= 64)
                mainW.tileMap.tileSize *= 2;
            else if (!isZoomingIn && mainW.tileMap.tileSize >= 8)
                mainW.tileMap.tileSize /= 2;
            mainW.input.moveLength = mainW.tileMap.tileSize;
            updatedThickness.Left = -((mainW.playerCoordX -2) * mainW.input.moveLength);
            updatedThickness.Top = -((mainW.playerCoordY -2) * mainW.input.moveLength);
            mainW.MainMap.Margin = updatedThickness;
            mainW.tileMap.UpdateTiles();
        }

        public void FollowCam(int direction)
        {
            Thickness updatedThicc = mainW.MainMap.Margin;
            switch (direction)
            {
                case 1:
                    if (mainW.MainMap.Margin.Top + mainW.player.playerOffset.Top <= 64)
                        updatedThicc.Top += mainW.input.moveLength;
                    break;
                case 2:
                    if (mainW.MainMap.Margin.Left + mainW.player.playerOffset.Left <= 64)
                        updatedThicc.Left += mainW.input.moveLength;
                    break;
                case 3:
                    if ((mainW.RenderSize.Height - mainW.player.playerOffset.Top) - mainW.MainMap.Margin.Top <= 128)
                        updatedThicc.Top -= mainW.input.moveLength;
                    break;
                case 4:
                    if ((mainW.RenderSize.Width - mainW.player.playerOffset.Left) - mainW.MainMap.Margin.Left <= 128)
                        updatedThicc.Left -= mainW.input.moveLength;
                    break;
            }
            mainW.MainMap.Margin = updatedThicc;
        }
    }
}
