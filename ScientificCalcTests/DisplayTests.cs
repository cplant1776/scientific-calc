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
            // Act
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
            // Act
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
            display.Update(NewValue: "", Operation:"exp");
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
    }
}
