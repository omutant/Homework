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
        readonly CalculatorLogic _calLog;
        readonly InputHandler _inH;

        public KeyboardInput(CalculatorLogic calLogic, InputHandler inHandler)
        {
            _inH = inHandler;
            _calLog = calLogic;
        }

        public void KeyHandler(Key input)
        {
            //MessageBox.Show(input.ToString());
            NumKeyInput(input);
            SignKeyInput(input);
            SpecialKeyInput(input);
        }

        void NumKeyInput(Key input)
        {
            switch (input)
            {
                #region numKeys
                case Key.NumPad0:
                case Key.D0:
                    _inH.NumInput("0");
                    break;
                case Key.NumPad1:
                case Key.D1:
                    _inH.NumInput("1");
                    break;
                case Key.NumPad2:
                case Key.D2:
                    _inH.NumInput("2");
                    break;
                case Key.NumPad3:
                case Key.D3:
                    _inH.NumInput("3");
                    break;
                case Key.NumPad4:
                case Key.D4:
                    _inH.NumInput("4");
                    break;
                case Key.NumPad5:
                case Key.D5:
                    _inH.NumInput("5");
                    break;
                case Key.NumPad6:
                case Key.D6:
                    _inH.NumInput("6");
                    break;
                case Key.NumPad7:
                case Key.D7:
                    _inH.NumInput("7");
                    break;
                case Key.NumPad8:
                    _inH.NumInput("8");
                    break;
                case Key.D8:
                    if (Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
                    {
                        _inH.ParentheseesInput("(");
                    }
                    else
                    {
                        _inH.NumInput("8");
                    }
                    break;
                case Key.NumPad9:
                    _inH.NumInput("9");
                    break;
                case Key.D9:
                    if (Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
                    {
                        _inH.ParentheseesInput(")");
                    }
                    else
                    {
                        _inH.NumInput("9");
                    }

                    break;
                    #endregion numKeys
            }
        }
        void SignKeyInput(Key input)
        {
            switch (input)
            {
                #region signKeys
                case Key.Add:
                case Key.OemPlus:
                    _inH.SignInput("+");
                    break;
                case Key.Subtract:
                case Key.OemMinus:
                    _inH.SignInput("-");
                    break;
                case Key.Multiply:
                    _inH.SignInput("*");
                    break;
                case Key.Divide:
                    _inH.SignInput("/");
                    break;
                    #endregion signKeys
            }
        }
        void SpecialKeyInput(Key input)
        {
            switch (input)
            {
                #region specialKeys
                case Key.Back:
                case Key.Delete:
                    _inH.RemoveInput();
                    break;
                case Key.Return:
                    _calLog.CalculationSetup(true);
                    break;
                case Key.OemComma:
                case Key.Decimal:
                    _inH.CommaInput();
                    break;
                    #endregion specialKeys
            }
        }
    }
}
