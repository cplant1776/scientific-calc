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
            this.DisplayControl.Update(NewValue: NewValue, IsNewTerm: IsNewTerm, Operation: Operation);
            this.Display = this.DisplayControl.Text;
        }

        private void EvaluateExpression()
        {
            this.DisplayControl.Evaluate();
            this.Display = this.DisplayControl.Text;
        }

        private string TransformCurrentValue(string Value, string Transform)
        {
            return String.Format("{0}({1})", Transform, Value);
        }

        private async void TesterFunc()
        {
            this.Display += "?";
        }

        private void MC_Click(object sender, RoutedEventArgs e)
        {
            TesterFunc();
        }

        private void MR_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MPlus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MMinus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MS_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Squared_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void XToTheY_Click(object sender, RoutedEventArgs e)
        {
            //TODO
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
            //TODO
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            this.Display = "0";
            this.DisplayControl.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

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

        private void PlusMinus_Click(object sender, RoutedEventArgs e)
        {
            //TODO
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
    }
}
