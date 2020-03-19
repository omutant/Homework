using Lommeregner.Basic_Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lommeregner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        KeyboardInput keyIn;
        ButtonInput butIn;
        public CalculatorLogic calLog;
        public InputHandler inH;
        public MainWindow()
        {
            InitializeComponent();
            calLog = new CalculatorLogic();
            inH = new InputHandler();
            keyIn = new KeyboardInput(calLog, inH);
            butIn = new ButtonInput(calLog, inH);
        }

        // Routes all button input to the ButtonInput class
        public void RouteButton(object sender, RoutedEventArgs e)
        {
            object myValue = ((Button)sender).Tag;
            butIn.ButtonHandler(myValue);
        }

        // Routes all Keyboard input to the KeyboardInput class
        public void RouteKey(object sender, KeyEventArgs e)
        {
            keyIn.KeyHandler(e.Key);
        }

        // Handles swapping between the basic calculator and Shape calculator
        public void RouteMode(object sender, RoutedEventArgs e)
        {
            switch (RouteSelector.SelectedIndex)
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
