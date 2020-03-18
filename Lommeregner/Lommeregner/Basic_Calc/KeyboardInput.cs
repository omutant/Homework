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
        CalculatorLogic _calLog;

        public KeyboardInput()
        {
            _calLog = new CalculatorLogic();
        }

        public void KeyHandler(Key input)
        {
            //MessageBox.Show(input.ToString());
            switch (input)
            {
                #region numKeys
                case Key.NumPad0:
                case Key.D0:
                    _calLog.NumInput("0");
                    break;
                case Key.NumPad1:
                case Key.D1:
                    _calLog.NumInput("1");
                    break;
                case Key.NumPad2:
                case Key.D2:
                    _calLog.NumInput("2");
                    break;
                case Key.NumPad3:
                case Key.D3:
                    _calLog.NumInput("3");
                    break;
                case Key.NumPad4:
                case Key.D4:
                    _calLog.NumInput("4");
                    break;
                case Key.NumPad5:
                case Key.D5:
                    _calLog.NumInput("5");
                    break;
                case Key.NumPad6:
                case Key.D6:
                    _calLog.NumInput("6");
                    break;
                case Key.NumPad7:
                case Key.D7:
                    _calLog.NumInput("7");
                    break;
                case Key.NumPad8:
                case Key.D8:
                    _calLog.NumInput("8");
                    break;
                case Key.NumPad9:
                case Key.D9:
                    _calLog.NumInput("9");
                    break;
                #endregion numKeys
                #region signKeys
                case Key.Add:
                case Key.OemPlus:
                    _calLog.SignInput("+");
                    break;
                case Key.Subtract:
                case Key.OemMinus:
                    _calLog.SignInput("-");
                    break;
                case Key.Multiply:
                    _calLog.SignInput("*");
                    break;
                case Key.Divide:
                    _calLog.SignInput("/");
                    break;
                #endregion signKeys
                #region specialKeys
                case Key.Back:
                case Key.Delete:
                    _calLog.RemoveInput();
                    break;
                case Key.Return:
                    _calLog.CalculationSetup(true);
                    break;
                    #endregion specialKeys
            }


        }


    }
}
