using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Lommeregner.Basic_Calc
{
    class ButtonInput
    {
        public void ButtonHandler(object tempVal)
        {
            MessageBox.Show(tempVal.GetType() + " : " + tempVal);
        }
    }
}
