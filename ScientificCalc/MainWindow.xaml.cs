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
using LoreSoft.MathExpressions;

namespace ScientificCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string CurrentValue = "";
        private MathEvaluator Eval = new MathEvaluator();

        public MainWindow()
        {
            this.Display = "0";
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

        private void UpdateCurrentValue(string NewValue, bool IsNewTerm=false, string Operation="")
        {
            // Remove 0 if it is only current value
            if (this.Display == "0")
            {
                this.Display = "";
                this.CurrentValue = "";
            }

            // Determine new value
            string UpdatedValue = "";
            if (IsNewTerm == true)
                UpdatedValue = "";
            else if (Operation != "")
                UpdatedValue = TransformCurrentValue(Value: this.CurrentValue, Transform: Operation);
            else
                UpdatedValue = this.CurrentValue + NewValue;

            // TODO: Check validity of Updated Value

            if (Operation != "")
            {
                string NewDisplay = ReplaceLastOccurrence(Source: this.Display, Find: this.CurrentValue, Replace: UpdatedValue);
                this.Display = NewDisplay;
            }
            else
                Display += NewValue;

            // Update current value
            this.CurrentValue = UpdatedValue;
        }

        public static string ReplaceLastOccurrence(string Source, string Find, string Replace)
        {
            int place = Source.LastIndexOf(Find);

            if (place == -1)
                return Source;

            string result = Source.Remove(place, Find.Length).Insert(place, Replace);
            return result;
        }

        private string EvaluateExpression(string Expression)
        {
            double result = Eval.Evaluate(this.Display);
            this.Display = result.ToString();
            return "placeholder";
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
            UpdateCurrentValue(NewValue: "", Operation: "sin");
        }

        private void Cos_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "", Operation: "cos");
        }

        private void Tan_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "", Operation: "tan");
        }

        private void SquareRoot_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "", Operation: "sqrt");
        }

        private void TenToX_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "", Operation: "log");
        }

        private void Exp_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "", Operation: "exp");
        }

        private void Mod_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "%", IsNewTerm: true);
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
            this.CurrentValue = "0";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Div_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "/", IsNewTerm: true);
        }

        private void Pi_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "pi");
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "7");
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "8");
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "9");
        }

        private void Mult_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "*", IsNewTerm: true);
        }

        private void Factorial_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "4");
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "5");
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "6");
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "-", IsNewTerm: true);
        }

        private void PlusMinus_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "1");
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "2");
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "3");
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "+", IsNewTerm: true);
        }

        private void Open_par_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "(", IsNewTerm: true);
        }

        private void Close_par_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: ")", IsNewTerm: true);
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: "0");
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentValue(NewValue: ".");
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            EvaluateExpression(this.Display);
        }
    }
}
