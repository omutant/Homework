using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lommeregner.Basic_Calc
{
    class KeyboardInput
    {



        public void KeyHandler(Key input)
        {
            #region numKeys
            switch (input)
            {
                case Key.NumPad0:
                case Key.D0:
                    MessageBox.Show("0 Pressed!");
                    break;
                case Key.NumPad1:
                case Key.D1:
                    MessageBox.Show("1 Pressed!");
                    break;
                case Key.NumPad2:
                case Key.D2:
                    MessageBox.Show("2 Pressed!");
                    break;
                case Key.NumPad3:
                case Key.D3:
                    MessageBox.Show("3 Pressed!");
                    break;
                case Key.NumPad4:
                case Key.D4:
                    MessageBox.Show("4 Pressed!");
                    break;
                case Key.NumPad5:
                case Key.D5:
                    MessageBox.Show("5 Pressed!");
                    break;
                case Key.NumPad6:
                case Key.D6:
                    MessageBox.Show("6 Pressed!");
                    break;
                case Key.NumPad7:
                case Key.D7:
                    MessageBox.Show("7 Pressed!");
                    break;
                case Key.NumPad8:
                case Key.D8:
                    MessageBox.Show("8 Pressed!");
                    break;
                case Key.NumPad9:
                case Key.D9:
                    MessageBox.Show("9 Pressed!");
                    break;
            }
            #endregion numKeys

        }
    
        
    }
}
