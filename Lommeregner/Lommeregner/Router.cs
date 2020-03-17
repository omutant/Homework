using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Lommeregner
{
    /* ///  
     * For at kunne pege på elementer med X:Name elementet
     * skal du bruge endnu en partial instans af MainWindow.
    /// */

    //Router class
    public partial class MainWindow
    {
        public void RouteMode(object sender, RoutedEventArgs e)
        {
            switch (ModeSelector.SelectedIndex)
            {
                case 0:
                    BaseCalcScreen.Visibility = Visibility.Visible;
                    ShapeCalcScreen.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    ShapeCalcScreen.Visibility = Visibility.Visible;
                    BaseCalcScreen.Visibility = Visibility.Hidden;
                    break;
            }
        }
    }
}
