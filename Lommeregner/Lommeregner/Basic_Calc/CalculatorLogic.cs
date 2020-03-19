using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Linq;

namespace Lommeregner.Basic_Calc
{
    public class CalculatorLogic
    {
        public MainWindow _mainW;
        public bool hasFinishedMath = false;
        string[] _calcArr;
        string _calcString;
        public double result = 0;

        public CalculatorLogic()
        {
            _mainW = (MainWindow)Application.Current.MainWindow;
        }

        // Handles simple math ( + - * / )
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
            if (!_mainW.CalcText.Text.Contains('='))
            {
                char[] _endTrim = { '*', '/', '+', '-', ')', '(', ',' };
                _mainW.InputText.Text = _mainW.InputText.Text.TrimStart('0');
                _mainW.CalcText.Text += _mainW.InputText.Text;
                _mainW.CalcText.Text = _mainW.CalcText.Text.TrimEnd(_endTrim);
                _calcString = _mainW.CalcText.Text;
                ParentheseesSearch(_mainW.CalcText.Text);
                result = CalculateRemainder();
                if (final)
                {
                    _mainW.CalcText.Text += "=" + result;
                    _mainW.InputText.Text = result.ToString();
                    hasFinishedMath = true;
                }
            }
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
                                tempString = input[e..(i + 1)];
                                tempString = Regex.Replace(tempString, @"[()]", "");
                                _calcArr = Regex.Split(tempString, @"(\+)|(-)|(\*)|(/)");

                                input = _calcString.Remove(e, i - e + 1).Insert(e, SymbolSearch(_calcArr));
                                _calcString = input;
                            }
                        }
                    }
                }
            }
        }
        double CalculateRemainder()
        {
            _calcArr = Regex.Split(_calcString, @"(\+)|(-)|(\*)|(/)");
            List<string> tempArr = _calcArr.ToList();
            int counter = _calcArr.Count(x => x == "*" || x == "/" || x == "+" || x == "-");
            string tempRes = tempArr[0];
            int symbolIndex = 0;
            for (int i = 0; i < counter; i++)
            {
                tempRes = SymbolSearch(tempArr.ToArray());
                if (tempArr.Contains("*"))
                    symbolIndex = tempArr.IndexOf("*") - 1;
                else if (tempArr.Contains("/"))
                    symbolIndex = tempArr.IndexOf("/") - 1;
                else if (tempArr.Contains("+"))
                    symbolIndex = tempArr.IndexOf("+") - 1;
                else if (tempArr.Contains("-"))
                    symbolIndex = tempArr.IndexOf("-") - 1;
                else
                    MessageBox.Show("Error: couldn't find any usable symbols");
                tempArr.RemoveRange(symbolIndex, 3);
                tempArr.Insert(symbolIndex, tempRes);
            }
            result = Convert.ToDouble(tempRes);
            //hasFinishedMath = true;
            return result;
        }
        string SymbolSearch(string[] input)
        {
            string symbol = "";
            IList<string> calcParts = (IList<string>)input;
            try
            {

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
            catch (Exception)
            {
                MessageBox.Show("Error: Invalid calculation");
                _mainW.inH.Reset();
                return "";
            }
        }
    }
}
