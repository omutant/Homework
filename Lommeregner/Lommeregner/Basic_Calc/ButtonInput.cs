using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Lommeregner.Basic_Calc
{
    class ButtonInput
    {
        readonly CalculatorLogic _calLog;
        readonly InputHandler _inH;

        public ButtonInput(CalculatorLogic calLogic, InputHandler inHandler)
        {
            _inH = inHandler;
            _calLog = calLogic;
        }

        public void ButtonHandler(object inputTag)
        {
            NumberButtonInput(inputTag);
            SignButtonInput(inputTag);
            SpecialButtonInput(inputTag);
        }

        void NumberButtonInput(object inputTag)
        {
            switch (inputTag)
            {
                #region numberButtons
                case "0":
                    _inH.NumInput("0");
                    break;
                case "1":
                    _inH.NumInput("1");
                    break;
                case "2":
                    _inH.NumInput("2");
                    break;
                case "3":
                    _inH.NumInput("3");
                    break;
                case "4":
                    _inH.NumInput("4");
                    break;
                case "5":
                    _inH.NumInput("5");
                    break;
                case "6":
                    _inH.NumInput("6");
                    break;
                case "7":
                    _inH.NumInput("7");
                    break;
                case "8":
                    _inH.NumInput("8");
                    break;
                case "9":
                    _inH.NumInput("9");
                    break;
                    #endregion numberButtons
            }
        }
        void SignButtonInput(object inputTag)
        {
            switch (inputTag)
            {
                #region signButtons
                case "+":
                    _inH.SignInput("+");
                    break;
                case "-":
                    _inH.SignInput("-");
                    break;
                case "*":
                    _inH.SignInput("*");
                    break;
                case "/":
                    _inH.SignInput("/");
                    break;
                case "=":
                    _calLog.CalculationSetup(true);
                    break;
                    #endregion signButtons
            }
        }
        void SpecialButtonInput(object inputTag)
        {
            switch (inputTag)
            {
                #region specialButtons
                case "Delete":
                    _inH.RemoveInput();
                    break;
                case "Cancel":
                    _inH.Reset();
                    break;
                case "(":
                    _inH.ParentheseesInput("(");
                    break;
                case ")":
                    _inH.ParentheseesInput(")");
                    break;
                case ",":
                    _inH.CommaInput();
                    break;
                    #endregion specialButtons
            }

        }
    }
}
