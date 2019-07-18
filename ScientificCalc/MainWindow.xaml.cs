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
using System.ComponentModel;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace ScientificCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private DisplayControl DisplayControl = new DisplayControl();
        private bool isShowingError = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private string _display;
        public string Display
        {
            get { return _display; }
            set
            {
                if (string.Equals(value, _display))
                    return;
                _display = value;
                OnPropertyChanged("Display");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ButtonPressed(string NewValue, bool IsNewTerm = false, string Operation = "")
        {
            if (this.isShowingError)
                toggleErrorDisplay();

            this.DisplayControl.Update(NewValue: NewValue, IsNewTerm: IsNewTerm, Operation: Operation);
            this.Display = this.DisplayControl.Text;
        }

        private void EvaluateExpression()
        {
            try
            {
                this.DisplayControl.Evaluate();
                this.Display = this.DisplayControl.Text;
            }
            catch (LoreSoft.MathExpressions.ParseException e)
            {
                Console.WriteLine("Invalid expression: {0}", e);
                this.toggleErrorDisplay();
            }
        }

        private void toggleErrorDisplay()
        {
            if (this.isShowingError)
            {
                errorDisplay.Opacity = 0.0;
                this.isShowingError = false;
            }
            else
            {
                errorDisplay.Opacity = 1.0;
                this.isShowingError = true;
            }
               
        }


        private void MC_Click(object sender, RoutedEventArgs e)
        {
            this.DisplayControl.ClearMemory();
        }

        private void MR_Click(object sender, RoutedEventArgs e)
        {
            this.DisplayControl.RecallMemory();
        }

        private void MPlus_Click(object sender, RoutedEventArgs e)
        {
            EvaluateExpression();
            this.DisplayControl.StorePositiveValue(this.Display);
        }

        private void MMinus_Click(object sender, RoutedEventArgs e)
        {
            EvaluateExpression();
            this.DisplayControl.StoreNegativeValue(this.Display);
        }

        private void MS_Click(object sender, RoutedEventArgs e)
        {
            EvaluateExpression();
            this.DisplayControl.StoreValue(this.Display);
        }

        private void Squared_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "^(2)");
        }

        private void XToTheY_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "^");
        }

        private void Sin_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "", Operation: "sin");
        }

        private void Cos_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "", Operation: "cos");
        }

        private void Tan_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "", Operation: "tan");
        }

        private void SquareRoot_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "", Operation: "sqrt");
        }

        private void TenToX_Click(object sender, RoutedEventArgs e)
        {
            this.EvaluateExpression();
            this.ButtonPressed(NewValue: "", Operation: "10^");
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "", Operation: "log");
        }

        private void Exp_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "", Operation: "exp");
        }

        private void Mod_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "%");
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            this.Display = "0";
            this.DisplayControl.Clear();
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            this.Display = "0";
            this.DisplayControl.Clear();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "BACKSPACE");
        }

        private void Div_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "/");
        }

        private void Pi_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "pi");
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "7");
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "8");
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "9");
        }

        private void Mult_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "*");
        }

        private void Factorial_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "4");
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "5");
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "6");
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "-", IsNewTerm: true);
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "1");
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "2");
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "3");
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "+", IsNewTerm: true);
        }

        private void Open_par_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "(");
        }

        private void Close_par_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: ")");
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: "0");
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            this.ButtonPressed(NewValue: ".");
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            EvaluateExpression();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PlusMinus_Click(object sender, RoutedEventArgs e)
        {

        }

        //Keybindings
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                // Basic Digits
                case Key.D1:
                    this.One_Click(sender, e);
                    break;
                case Key.D2:
                    this.Two_Click(sender, e);
                    break;
                case Key.D3:
                    this.Three_Click(sender, e);
                    break;
                case Key.D4:
                    this.Four_Click(sender, e);
                    break;
                case Key.D5:
                    this.Five_Click(sender, e);
                    break;
                case Key.D6:
                    this.Six_Click(sender, e);
                    break;
                case Key.D7:
                    this.Seven_Click(sender, e);
                    break;
                case Key.D8:
                    this.Eight_Click(sender, e);
                    break;
                case Key.D9:
                    this.Nine_Click(sender, e);
                    break;
                case Key.D0:
                    this.Zero_Click(sender, e);
                    break;
                case Key.Decimal:
                    this.Decimal_Click(sender, e);
                    break;

                // Numpad digits
                case Key.NumPad1:
                    this.One_Click(sender, e);
                    break;
                case Key.NumPad2:
                    this.Two_Click(sender, e);
                    break;
                case Key.NumPad3:
                    this.Three_Click(sender, e);
                    break;
                case Key.NumPad4:
                    this.Four_Click(sender, e);
                    break;
                case Key.NumPad5:
                    this.Five_Click(sender, e);
                    break;
                case Key.NumPad6:
                    this.Six_Click(sender, e);
                    break;
                case Key.NumPad7:
                    this.Seven_Click(sender, e);
                    break;
                case Key.NumPad8:
                    this.Eight_Click(sender, e);
                    break;
                case Key.NumPad9:
                    this.Nine_Click(sender, e);
                    break;
                case Key.NumPad0:
                    this.Zero_Click(sender, e);
                    break;

                // Operations
                case Key.OemPlus:
                    this.Plus_Click(sender, e);
                    break;
                case Key.OemMinus:
                    this.Minus_Click(sender, e);
                    break;
                case Key.Multiply:
                    this.Mult_Click(sender, e);
                    break;
                case Key.Divide:
                    this.Div_Click(sender, e);
                    break;
                case Key.OemBackslash:
                    this.Div_Click(sender, e);
                    break;
                case Key.OemOpenBrackets:
                    this.Open_par_Click(sender, e);
                    break;
                case Key.OemCloseBrackets:
                    this.Close_par_Click(sender, e);
                    break;

                // Evaluation
                case Key.Enter:
                    this.Equal_Click(sender, e);
                    break;
                case Key.System:
                    this.Equal_Click(sender, e);
                    break;

                // Backspace
                case Key.Back:
                    this.Back_Click(sender, e);
                    break;

            }
        }


    }
}
