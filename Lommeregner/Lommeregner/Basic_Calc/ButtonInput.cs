using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Lommeregner.Basic_Calc
{
    class ButtonInput
    {
        CalculatorLogic _calLog;

        public ButtonInput()
        {
            _calLog = new CalculatorLogic();
        }
        public void ButtonHandler(object stringInput)
        {
            //MessageBox.Show(stringInput.GetType() + " : " + stringInput);

            switch (stringInput)
            {
                #region signButtons
                case "+":
                    _calLog.SignInput("+");
                    break;
                case "-":
                    _calLog.SignInput("-");
                    break;
                case "*":
                    _calLog.SignInput("*");
                    break;
                case "/":
                    _calLog.SignInput("/");
                    break;
                case "=":
                    _calLog.CalculationSetup(true);
                    break;
                #endregion signButtons
                #region numberButtons
                case "0":
                    _calLog.NumInput("0");
                    break;
                case "1":
                    _calLog.NumInput("1");
                    break;
                case "2":
                    _calLog.NumInput("2");
                    break;
                case "3":
                    _calLog.NumInput("3");
                    break;
                case "4":
                    _calLog.NumInput("4");
                    break;
                case "5":
                    _calLog.NumInput("5");
                    break;
                case "6":
                    _calLog.NumInput("6");
                    break;
                case "7":
                    _calLog.NumInput("7");
                    break;
                case "8":
                    _calLog.NumInput("8");
                    break;
                case "9":
                    _calLog.NumInput("9");
                    break;
                #endregion numberButtons
                #region specialButtons
                case "Delete":
                    _calLog.RemoveInput();
                    break;
                case "Cancel":
                    _calLog.Reset();
                    break;
                case "(":
                    _calLog.ParentheseesInput("(");
                    break;
                case ")":
                    _calLog.ParentheseesInput(")");
                    break;
                case ",":
                    _calLog.CommaInput();
                    break;
                #endregion specialButtons
                default:
                    MessageBox.Show("Error: Key not implemented");
                    break;
            }
            
        }
    }
}
