using AngouriMath.Extensions;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool calcOn = false;
        private string CurrentExpression = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TurnOnCalc(object sender, RoutedEventArgs e)
        {
            calcOn = !calcOn;
            CalcDisplay.IsEnabled = calcOn;
            CalcDisplay.Text = "";
            CurrentExpression = "";
        }

        private void Equals(object sender, RoutedEventArgs e)
        {
            CurrentExpression = CalcDisplay.Text;

            string asd = CurrentExpression.EvalNumerical().ToString() ?? "";
            CalcDisplay.Text = asd.Replace(".", ",");

        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            CalcDisplay.Text = "";
            CurrentExpression = "";
        }

        private void AppendContentToCalcDisplay(object sender, RoutedEventArgs e)
        {
            if (!calcOn)
            {
                return;
            }
            Button button = (Button)sender;
            CalcDisplay.AppendText(button.Content.ToString());
        }
    }
}