using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScientificCalc;

namespace ScientificCalcTests
{
    [TestClass]
    public class DisplayTests
    {
        [TestMethod]
        public void Single_Number()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act
            display.Update(NewValue: "1");
            // Assert
            string actual = display.Text;
            string expected = "1";
            Assert.AreEqual(expected, actual, "Failed Single Number");
        }

        [TestMethod]
        public void Multiple_Numbers()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act
            display.Update(NewValue: "1");
            display.Update(NewValue: "2");
            display.Update(NewValue: "3");
            // Assert
            string actual = display.Text;
            string expected = "123";
            Assert.AreEqual(expected, actual, "Failed Multiple_Numbers");
        }

        [TestMethod]
        public void Basic_Addition()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act
            display.Update(NewValue: "1.5");
            display.Update(NewValue: "+", IsNewTerm: true);
            display.Update(NewValue: "1.5");
            display.Evaluate();
            // Assert
            string actual = display.Text;
            string expected = "3";
            Assert.AreEqual(expected, actual, "Failed Basic Addition");
        }

        [TestMethod]
        public void Basic_Subtraction()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act
            display.Update(NewValue: "1.5");
            display.Update(NewValue: "-", IsNewTerm: true);
            display.Update(NewValue: "1");
            display.Evaluate();
            // Assert
            string actual = display.Text;
            string expected = "0.5";
            Assert.AreEqual(expected, actual, "Failed Basic Subtraction");
        }

        [TestMethod]
        public void Basic_Multiplication()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act
            display.Update(NewValue: "5");
            display.Update(NewValue: "*", IsNewTerm: true);
            display.Update(NewValue: "5");
            display.Evaluate();
            // Assert
            string actual = display.Text;
            string expected = "25";
            Assert.AreEqual(expected, actual, "Failed Basic Multiplication");
        }

        [TestMethod]
        public void Basic_Division()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act
            display.Update(NewValue: "25");
            display.Update(NewValue: "/", IsNewTerm: true);
            display.Update(NewValue: "5");
            display.Evaluate();
            // Assert
            string actual = display.Text;
            string expected = "5";
            Assert.AreEqual(expected, actual, "Failed Basic Division");
        }

        [TestMethod]
        public void Pi()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act
            display.Update(NewValue: "pi");
            display.Evaluate();
            // Assert
            string actual = display.Text;
            string expected = "3.14159265358979";
            Assert.AreEqual(expected, actual, "Failed Pi");
        }

        [TestMethod]
        public void Sin()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act sin(pi/2)
            display.Update(NewValue: "pi");
            display.Update(NewValue: "/");
            display.Update(NewValue: "2");
            display.Update(NewValue: "", Operation: "sin");
            display.Evaluate();
            // Assert
            string actual = display.Text;
            string expected = "1";
            Assert.AreEqual(expected, actual, "Failed Sin");
        }

        [TestMethod]
        public void Cos()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act
            display.Update(NewValue: "pi");
            display.Update(NewValue: "", Operation: "cos");
            display.Evaluate();
            // Assert
            string actual = display.Text;
            string expected = "-1";
            Assert.AreEqual(expected, actual, "Failed Cos");
        }

        [TestMethod]
        public void Tan()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act pi/4
            display.Update(NewValue: "pi");
            display.Update(NewValue: "/");
            display.Update(NewValue: "4");
            display.Update(NewValue: "", Operation: "tan");
            display.Evaluate();
            // Assert
            string actual = display.Text;
            string expected = "1";
            Assert.AreEqual(expected, actual, "Failed Tan");
        }

        [TestMethod]
        public void Exponential()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act
            display.Update(NewValue: "1");
            display.Update(NewValue: "", Operation: "exp");
            display.Evaluate();
            // Assert
            string actual = display.Text;
            string expected = "2.71828182845905";
            Assert.AreEqual(expected, actual, "Failed Exponential");
        }

        [TestMethod]
        public void Basic_Parentheses()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act (5+5)*(5+5)
            display.Update(NewValue: "(");
            display.Update(NewValue: "5");
            display.Update(NewValue: "+", IsNewTerm: true);
            display.Update(NewValue: "5");
            display.Update(NewValue: ")");
            display.Update(NewValue: "*");
            display.Update(NewValue: "(");
            display.Update(NewValue: "5");
            display.Update(NewValue: "+", IsNewTerm: true);
            display.Update(NewValue: "5");
            display.Update(NewValue: ")");
            display.Evaluate();
            // Assert
            string actual = display.Text;
            string expected = "100";
            Assert.AreEqual(expected, actual, "Failed Basic_Parentheses");
        }

        [TestMethod]
        public void Open_Parentheses_With_Operation()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act (5+5)*(5+5)*exp(1)
            display.Update(NewValue: "(");
            display.Update(NewValue: "5");
            display.Update(NewValue: "+", IsNewTerm: true);
            display.Update(NewValue: "5");
            display.Update(NewValue: ")");
            display.Update(NewValue: "*");
            display.Update(NewValue: "(");
            display.Update(NewValue: "5");
            display.Update(NewValue: "+", IsNewTerm: true);
            display.Update(NewValue: "5");
            display.Update(NewValue: ")");
            display.Update(NewValue: "*");
            display.Update(NewValue: "", Operation: "exp");
            display.Update(NewValue: "1");
            display.Update(NewValue: ")");
            display.Evaluate();
            // Assert
            string actual = display.Text;
            string expected = "271.828182845905";
            Assert.AreEqual(expected, actual, "Failed Open_Parentheses_With_Operation");
        }

        [TestMethod]
        public void Square()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act 4^(2)
            display.Update(NewValue: "4");
            display.Update(NewValue: "^2");
            display.Evaluate();
            // Assert
            string actual = display.Text;
            string expected = "16";
            Assert.AreEqual(expected, actual, "Failed Square");
        }

        [TestMethod]
        public void Power()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act 2^3
            display.Update(NewValue: "2");
            display.Update(NewValue: "^");
            display.Update(NewValue: "3");
            display.Evaluate();
            // Assert
            string actual = display.Text;
            string expected = "8";
            Assert.AreEqual(expected, actual, "Failed Square");
        }

        [TestMethod]
        public void Power_Negative()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act 2^(-3)
            display.Update(NewValue: "2");
            display.Update(NewValue: "^");
            display.Update(NewValue: "(");
            display.Update(NewValue: "-");
            display.Update(NewValue: "3");
            display.Update(NewValue: ")");
            display.Evaluate();
            // Assert
            string actual = display.Text;
            string expected = "0.125";
            Assert.AreEqual(expected, actual, "Failed Square");
        }

        [TestMethod]
        public void MC()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act
            display.ClearMemory();
            // Assert
            string actual = display.StoredValue;
            string expected = "";
            Assert.AreEqual(expected, actual, "Failed MC");
        }

        [TestMethod]
        public void MR()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act
            display.StoredValue = "210";
            display.RecallMemory();
            // Assert
            string actual = display.Text;
            string expected = "210";
            Assert.AreEqual(expected, actual, "Failed MR");
        }

        [TestMethod]
        public void MR_No_MS()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act
            display.RecallMemory();
            // Assert
            string actual = display.Text;
            string expected = "";
            Assert.AreEqual(expected, actual, "Failed MR_No_MS");
        }

        //M+
        [TestMethod]
        public void MPlus()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act
            display.Update(NewValue: "1");
            display.StorePositiveValue(display.Text);
            // Assert
            string actual = display.StoredValue;
            string expected = "1";
            Assert.AreEqual(expected, actual, "Failed MPlus");
        }

        [TestMethod]
        public void MMinus()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act
            display.Update(NewValue: "1");
            display.StoreNegativeValue(display.Text);
            // Assert
            string actual = display.StoredValue;
            string expected = "-1";
            Assert.AreEqual(expected, actual, "Failed MMinus");
        }

        [TestMethod]
        public void MS()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act
            display.Text = "1";
            display.StoreValue(display.Text);
            // Assert
            string actual = display.StoredValue;
            string expected = "1";
            Assert.AreEqual(expected, actual, "Failed MR");
        }

        [TestMethod]
        public void Backspace()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act
            display.Update(NewValue: "1");
            display.Update(NewValue: "2");
            display.Update(NewValue: "3");
            display.Backspace();
            // Assert
            string actual = display.Text;
            string expected = "12";
            Assert.AreEqual(expected, actual, "Failed Backspace");
        }

        [TestMethod]
        public void Backspace_No_Values()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act
            display.Backspace();
            // Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => display.Backspace());
        }


        [TestMethod]
        public void TenToX()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act
            display.Update(NewValue: "2");
            display.Evaluate();
            display.Update(NewValue: "", Operation: "10^");
            // Assert
            string actual = display.Text;
            string expected = "10^(2)";
            Assert.AreEqual(expected, actual, "Failed TenToX");
        }

        [TestMethod]
        public void Log()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act log(e)
            display.Text = "e^(1)";
            display.Update(NewValue: "", Operation: "log");
            display.Evaluate();
            // Assert
            string actual = display.Text;
            string expected = "1";
            Assert.AreEqual(expected, actual, "Failed Log");
        }

        [TestMethod]
        public void Mod_Divisor()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act log(e)
            display.Text = "16%4";
            display.Evaluate();
            // Assert
            string actual = display.Text;
            string expected = "0";
            Assert.AreEqual(expected, actual, "Failed Mod_Divisor");
        }

        [TestMethod]
        public void Mod_Non_Divisor()
        {
            // Arrange
            DisplayControl display = new DisplayControl();
            // Act log(e)
            display.Text = "16%5";
            display.Evaluate();
            // Assert
            string actual = display.Text;
            string expected = "1";
            Assert.AreEqual(expected, actual, "Failed Mod_Non_Divisor");
        }
    }
}
