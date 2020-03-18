using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Linq;

namespace Lommeregner.Basic_Calc
{
    class CalculatorLogic
    {
        MainWindow _mainW;
        bool _hasFinishedMath = false;
        string[] _calcArr;
        string _calcString;
        double _result = 0;

        public CalculatorLogic()
        {
            _mainW = (MainWindow)Application.Current.MainWindow;
        }

        string Calculate(double num1, char symbol, double num2)
        {
            switch (symbol)
            {
                case '*':
                    return (num1 * num2).ToString();
                case '/':
                    return (num1 / num2).ToString();
                case '+':
                    return (num1 + num2).ToString();
                case '-':
                    return (num1 - num2).ToString();
            }
            return "";
        }

        public void CalculationSetup(bool final)
        {
            _mainW.InputText.Text = _mainW.InputText.Text.TrimStart('0');
            _mainW.CalcText.Text += _mainW.InputText.Text;
            _calcString = _mainW.CalcText.Text;
            ParentheseesSearch(_mainW.CalcText.Text);
            _result = calcRest();
            if (final)
            {
                _mainW.CalcText.Text += "=" + _result;
                _mainW.InputText.Text = _result.ToString();
            }
            _hasFinishedMath = true;
        }

        void ParentheseesSearch(string input)
        {

            for (int p = Regex.Matches(_mainW.CalcText.Text, @"\)").Count; p > -1; p--)
            {
                string tempString = "";
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == ')')
                    {
                        for (int e = i; e > -1; e--)
                        {
                            if (input[e] == '(')
                            {
                                tempString = input.Substring(e, (i + 1) - e);
                                tempString = Regex.Replace(tempString, @"[()]", "");
                                _calcArr = Regex.Split(tempString, @"(\+)|(-)|(\*)|(/)");
                                //string remover = _calcString[e] + tempString + _calcString[i];
                                //_calcString.Replace(remover, "PLACEHOLDER");
                                //_calcString.Replace("PLACEHOLDER", CalcSearch(_calcArr));

                                input = _calcString.Remove(e, i - e + 1).Insert(e, CalcSearch(_calcArr));
                                _calcString = input;
                                MessageBox.Show(_calcString);
                            }
                        }
                    }
                }
            }
        }
        double calcRest()
        {
            _calcArr = Regex.Split(_calcString, @"(\+)|(-)|(\*)|(/)");
            List<string> tempArr = _calcArr.ToList();
            int counter = _calcArr.Count(x => x == "*" || x == "/" || x == "+" || x == "-");
            for (int i = 0; i < counter; i++)
            {
                if (tempArr.Count > 3)
                {
                    string tempResult = CalcSearch(tempArr.ToArray());
                    tempArr.RemoveRange(0, 3);
                    tempArr.Insert(0, tempResult);
                    int cutLength = tempArr[0].Length + tempArr[1].Length + tempArr[2].Length;
                    _calcString = _calcString.Remove(0, cutLength).Insert(0, tempResult);
                }
                else
                {
                    _calcString = CalcSearch(tempArr.ToArray());
                }
            }
            _result = Convert.ToDouble(_calcString);
            return _result;
        }

        string CalcSearch(string[] input)
        {
            string symbol = "";
            IList<string> calcParts = (IList<string>)_calcArr;

            if (calcParts.Contains("*"))
            {
                symbol = "*";
                return Calculate(
                    Convert.ToDouble(calcParts[calcParts.IndexOf(symbol) - 1]),
                    Convert.ToChar(calcParts[calcParts.IndexOf(symbol)]),
                    Convert.ToDouble(calcParts[calcParts.IndexOf(symbol) + 1]));
            }
            else if (calcParts.Contains("/"))
            {
                symbol = "/";
                return Calculate(
                    Convert.ToDouble(calcParts[calcParts.IndexOf(symbol) - 1]),
                    Convert.ToChar(calcParts[calcParts.IndexOf(symbol)]),
                    Convert.ToDouble(calcParts[calcParts.IndexOf(symbol) + 1]));
            }
            else if (calcParts.Contains("+"))
            {
                symbol = "+";
                return Calculate(
                    Convert.ToDouble(calcParts[calcParts.IndexOf(symbol) - 1]),
                    Convert.ToChar(calcParts[calcParts.IndexOf(symbol)]),
                    Convert.ToDouble(calcParts[calcParts.IndexOf(symbol) + 1]));
            }
            else if (calcParts.Contains("-"))
            {
                symbol = "-";
                return Calculate(
                    Convert.ToDouble(calcParts[calcParts.IndexOf(symbol) - 1]),
                    Convert.ToChar(calcParts[calcParts.IndexOf(symbol)]),
                    Convert.ToDouble(calcParts[calcParts.IndexOf(symbol) + 1]));
            }
            else
            {
                return input[0];
            }
        }

        public void NumInput(string input)
        {
            if (_hasFinishedMath)
            {
                Reset();
                _hasFinishedMath = false;
            }
            _mainW.InputText.Text += input;
        }
        public void SignInput(string input)
        {
            if (_hasFinishedMath)
            {
                Reset();
                _mainW.CalcText.Text = _result.ToString() + input;
                _hasFinishedMath = false;
            }
            if (_mainW.InputText.Text.Length > 0 || _mainW.CalcText.Text.EndsWith(')'))
            {
                _mainW.InputText.Text = _mainW.InputText.Text.TrimStart('0');
                _mainW.CalcText.Text += _mainW.InputText.Text + input;
                _mainW.InputText.Text = "";
            }
        }
        public void ParentheseesInput(string input)
        {
            if (input == ")")

                if (Regex.Matches(_mainW.CalcText.Text, @"\(").Count >= Regex.Matches(_mainW.CalcText.Text, @"\)").Count + 1)
                {
                    _mainW.InputText.Text += ")";
                    _mainW.CalcText.Text += _mainW.InputText.Text;
                    _mainW.InputText.Text = "";
                }
                else { }
            else if (input == "(")
            {
                if (_hasFinishedMath)
                {
                    Reset();
                    _mainW.CalcText.Text = input + _result.ToString();
                    _hasFinishedMath = false;
                }
                _mainW.InputText.Text += "(";
            }
            else { }
        }
        public void CommaInput()
        {
            if (_mainW.InputText.Text.Length > 0)
            {
                if (_hasFinishedMath)
                {
                    Reset();
                    //_mainW.CalcText.Text = _result.ToString();
                    _mainW.InputText.Text = _result.ToString();
                    _hasFinishedMath = false;
                }
                _mainW.InputText.Text += ",";
            }
            else
            {

                _mainW.InputText.Text += "0,";
            }
        }
        public void RemoveInput()
        {
            if (_mainW.InputText.Text.Length > 0)
            {
                _mainW.InputText.Text = _mainW.InputText.Text.Remove(_mainW.InputText.Text.Length - 1, 1);
            }
        }
        public void Reset()
        {
            _mainW.CalcText.Text = "";
            _mainW.InputText.Text = "";
        }
    }
}
