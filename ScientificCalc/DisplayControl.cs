using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoreSoft.MathExpressions;

namespace ScientificCalc
{
    public class DisplayControl
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public string DisplayValue { get; set; }
        private MathEvaluator Eval = new MathEvaluator();

        public DisplayControl()
        {
            this.Value = "0";
            this.Text = "0";
        }

        public void Update(string NewValue, bool IsNewTerm = false, string Operation = "")
        {
            // Remove 0 if it is only current value
            if (this.Value == "0")
                this.Value = "";

            // Determine new value
            string UpdatedValue = "";
            if (IsNewTerm == true)
                UpdatedValue = "";
            else if (Operation != "")
                UpdatedValue = TransformCurrentValue(Value: this.Value, Transform: Operation);
            else
                UpdatedValue = this.Value + NewValue;

            // TODO: Check validity of Updated Value
            // Update display text
            UpdateText(NewValue: NewValue, UpdatedValue: UpdatedValue, Operation: Operation);
            // Update current value
            this.Value = UpdatedValue;
        }

        private string TransformCurrentValue(string Value, string Transform)
        {
            return String.Format("{0}({1})", Transform, Value);
        }

        public string UpdateText(string NewValue, string UpdatedValue, string Operation = "")
        {
            string result = this.Text;
            // Remove 0 if it is only current value
            if (result == "0")
                result = "";

            if (Operation != "")
            {
                result = ReplaceLastOccurrence(Source: result, Find: this.Value, Replace: UpdatedValue);
            }
            else
                result += NewValue;

            this.Text = result;
            return result;
        }

        private static string ReplaceLastOccurrence(string Source, string Find, string Replace)
        {
            int place = Source.LastIndexOf(Find);

            if (place == -1)
                return Source;

            string result = Source.Remove(place, Find.Length).Insert(place, Replace);
            return result;
        }

        public void Clear()
        {
            this.Text = "0";
            this.Value = "0";
        }

        public void Evaluate()
        {
            string result = Eval.Evaluate(this.Text).ToString();
            this.Value = result;
            this.Text = result;
        }
    }
}
