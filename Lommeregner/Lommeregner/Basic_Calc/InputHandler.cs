using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace Lommeregner.Basic_Calc
{
    public class InputHandler
    {
        MainWindow mainW;
        public CalculatorLogic _calLog;
        public InputHandler()
        {
            mainW = (MainWindow)Application.Current.MainWindow;
            _calLog = mainW.calLog;
        }
        public void NumInput(string input)
        {
            MathDoneCheck();
            _calLog._mainW.InputText.Text += input;
        }
        public void SignInput(string input)
        {
            MathDoneCheck("SignStart", input);
            if (_calLog._mainW.InputText.Text == "" && _calLog._mainW.CalcText.Text != "")
            {
                char[] _endTrim = { '*', '/', '+', '-' };
                _calLog._mainW.CalcText.Text = _calLog._mainW.CalcText.Text.TrimEnd(_endTrim);
                _calLog._mainW.CalcText.Text += input;
            }
            if (_calLog._mainW.InputText.Text.Length > 0 || _calLog._mainW.CalcText.Text.EndsWith(')'))
            {
                _calLog._mainW.InputText.Text = _calLog._mainW.InputText.Text.TrimStart('0');
                if (_calLog._mainW.InputText.Text.StartsWith(","))
                    _calLog._mainW.InputText.Text = "0" + _calLog._mainW.InputText.Text;
                _calLog._mainW.CalcText.Text += _calLog._mainW.InputText.Text + input;
                _calLog._mainW.InputText.Text = "";
            }

        }
        public void ParentheseesInput(string input)
        {
            switch (input)
            {
                case ")":
                    if (
                    Regex.Matches(_calLog._mainW.CalcText.Text, @"\(").Count >=
                    Regex.Matches(_calLog._mainW.CalcText.Text, @"\)").Count + 1)
                    {
                        _calLog._mainW.InputText.Text += ")";
                        _calLog._mainW.CalcText.Text += _calLog._mainW.InputText.Text;
                        _calLog._mainW.InputText.Text = "";
                    }
                    break;
                case "(":
                    _calLog._mainW.InputText.Text += "(";
                    MathDoneCheck("ParentheseesStart", input);
                    break;
            }
        }
        public void CommaInput()
        {

            MathDoneCheck();
            if (_calLog._mainW.InputText.Text.Length > 0 && !_calLog._mainW.InputText.Text.EndsWith(','))
            {
                MathDoneCheck("CommaStart");
                _calLog._mainW.InputText.Text += ",";
            }
            else
            {
                _calLog._mainW.InputText.Text += "0,";
            }
        }
        public void RemoveInput()
        {
            if (_calLog._mainW.InputText.Text.Length > 0)
            {
                _calLog._mainW.InputText.Text = _calLog._mainW.InputText.Text.Remove(_calLog._mainW.InputText.Text.Length - 1, 1);
            }
        }

        public void Reset()
        {
            _calLog._mainW.CalcText.Text = "";
            _calLog._mainW.InputText.Text = "";
            _calLog.hasFinishedMath = false;
        }
        public void MathDoneCheck()
        {
            if (_calLog.hasFinishedMath){
                Reset();
            }
        }
        public void MathDoneCheck(string specialCase)
        {
            if (_calLog.hasFinishedMath){
                Reset();
                switch (specialCase)
                {
                    case "CommaStart":
                        _calLog._mainW.InputText.Text = _calLog.result.ToString();

                        break;
                }
            }
        }
        public void MathDoneCheck(string specialCase, string input)
        {
            if (_calLog.hasFinishedMath){
                Reset();
                switch (specialCase)
                {
                    case "SignStart":
                        _calLog._mainW.CalcText.Text = _calLog.result.ToString() + input;
                        break;
                    case "ParentheseesStart":
                        _calLog._mainW.CalcText.Text = input;
                        _calLog._mainW.InputText.Text += _calLog.result;
                        break;
                }
            }
        }
    }
}
