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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {

        private static string operand1 = "0";
        private static string operand2 = "";
        private static bool clearBox = false;
        private static bool resultWasJustCalculated = false;
        private static bool justOpenedCalculator = true;

        public MainWindow()
        {
            InitializeComponent();
            initializeResultBox();
        }

        public struct Operator
        {
            string operation;

            public string Sign
            {
                get
                {
                    return operation;
                }
                set
                {
                    operation = value;
                }
            }
        }
        Operator current_operator = new Operator();

        private void calculateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((result.Text != null && operand1 != null) || resultWasJustCalculated) //if on first operation, or operation was just calculated..
                {
                    operand2 = result.Text;
                    result.Text = "";
                    float outcome = 0;

                    if (current_operator.Sign == "addition")
                    {
                        outcome = addValues();
                    }
                    else if (current_operator.Sign == "subtraction")
                    {
                        outcome = subtractValues();
                    }
                    else if (current_operator.Sign == "multiplication")
                    {
                        outcome = multiplyValues();
                    }
                    else if (current_operator.Sign == "division")
                    {
                        outcome = divideValues();
                    }
                    else { }

                    clearBox = true; //set flag to clear box
                    resultWasJustCalculated = true;
                    justOpenedCalculator = false;
                    operand1 = outcome.ToString();
                    operand2 = "";
                }
                else
                {
                    throw new InvalidOperationException("No operator selected");
                }
            }
            catch (FormatException fEx)
            {
                result.Text = fEx.Message;
            }
            catch (OverflowException oEx)
            {
                result.Text = oEx.Message;
            }
            //catch (InvalidOperationException ioEx)
            //{
            //    result.Text = ioEx.Message;
            //}
            catch (Exception ex)
            {
                result.Text = ex.Message;
            }
        }
        private void initializeResultBox()
        {
            try
            {
                result.Text = "0";
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
            }
        }

        private void numberPressed(string input)
        {
            try
            {
                if (justOpenedCalculator) //if just started program
                {
                    result.Text = input;
                    justOpenedCalculator = false;
                }
                else if (result.Text == "0")
                {
                    //just ignore extra zeroes...nobody needs 'em!
                }
                else
                {
                    string numberString = result.Text + input; //concat the number
                    result.Text = numberString;
                }
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
            }
        }


        private float addValues()
        {
            try
            {
                float lhs = float.Parse(operand1);
                float rhs = float.Parse(operand2);
                float outcome = 0;

                outcome = lhs + rhs;
                result.Text = outcome.ToString();
                expression.Text = operand1 + " + " + operand2 + " = " + outcome;
                return outcome;
            }
            catch (FormatException ex)
            {
                result.Text = "This is the addValue exception";
                return -1;
            }
        }

        private float subtractValues()
        {
            try
            {
                float lhs = float.Parse(operand1);
                float rhs = float.Parse(operand2);
                float outcome = 0;

                outcome = lhs - rhs;
                expression.Text = operand1 + " - " + operand2 + " = " + outcome;
                result.Text = outcome.ToString();
                return outcome;
            }
            catch (Exception ex)
            {

                result.Text = "ERROR";
                return -1;
            }
        }

        private float multiplyValues()
        {
            try
            {
                float lhs = float.Parse(operand1);
                float rhs = float.Parse(operand2);
                float outcome = 0;

                outcome = checked(lhs * rhs);
                expression.Text = operand1 + " * " + operand2 + " = " + outcome;
                result.Text = outcome.ToString();
                return outcome;
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
                return -1;
            }
        }

        private float divideValues()
        {
            try
            {
                float lhs = float.Parse(operand1);
                float rhs = float.Parse(operand2);
                float outcome = 0;

                outcome = lhs / rhs;
                expression.Text = operand1 + " / " + operand2 + " = " + outcome;
                result.Text = outcome.ToString();
                return outcome;
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
                return -1;
            }
        }

        private void quitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void inputZero_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (clearBox) //if someone just pressed clear...
                {
                    result.Text = "";
                    clearBox = false; //reset flag
                }
                numberPressed("0");
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
            }
        }

        private void inputOne_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (clearBox)
                {
                    result.Text = "";
                    clearBox = false; //reset flag
                }
                numberPressed("1");
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
            }
        }

        private void inputTwo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (clearBox)
                {
                    result.Text = "";
                    clearBox = false; //reset flag
                }
                numberPressed("2");
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
            }
        }

        private void inputThree_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (clearBox)
                {
                    result.Text = "";
                    clearBox = false; //reset flag
                }
                numberPressed("3");
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
            }
        }

        private void inputFour_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (clearBox)
                {
                    result.Text = "";
                    clearBox = false; //reset flag
                }
                numberPressed("4");
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
            }
        }

        private void inputFive_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (clearBox)
                {
                    result.Text = "";
                    clearBox = false; //reset flag
                }
                numberPressed("5");
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
            }
        }

        private void inputSix_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (clearBox)
                {
                    result.Text = "";
                    clearBox = false; //reset flag
                }
                numberPressed("6");
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
            }
        }

        private void inputSeven_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (clearBox)
                {
                    result.Text = "";
                    clearBox = false; //reset flag
                }
                numberPressed("7");
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
            }
        }

        private void inputEight_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (clearBox)
                {
                    result.Text = "";
                    clearBox = false; //reset flag
                }
                numberPressed("8");
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
            }
        }

        private void inputNine_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (clearBox)
                {
                    result.Text = "";
                    clearBox = false; //reset flag
                }
                numberPressed("9");
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
            }
        }

        private void decimalPoint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool decimalPointAlreadyExists = false;

                if (clearBox)
                {
                    result.Text = "";
                    clearBox = false; //reset flag
                }
                char[] letters = result.Text.ToCharArray();

                foreach (char letter in letters)
                { //check for pre-existing decimal points
                    if (letter == '.')
                    {
                        decimalPointAlreadyExists = true;
                    }
                }
                if (!decimalPointAlreadyExists)
                {
                    numberPressed(".");
                }
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                operand1 = "";
                operand2 = "";
                result.Text = "0";
                expression.Text = "";
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
            }
        }

        private void addition_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (result.Text != "" && operand2 == "")
                {
                    operand1 = result.Text; //stores current stuff in operand 1
                    expression.Text = operand1 + " " + "+";
                    clearBox = true; //will clear next iteration
                    current_operator.Sign = "addition";
                }
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
            }
        }
        private void subtraction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (result.Text != "" && operand2 == "")
                {
                    operand1 = result.Text;
                    expression.Text = operand1 + " " + "-";
                    clearBox = true; //will clear next iteration
                    current_operator.Sign = "subtraction";
                }
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
            }
        }
        private void multiplication_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (result.Text != "" && operand2 == "")
                {
                    operand1 = result.Text;
                    expression.Text = operand1 + " " + "*";
                    clearBox = true; //will clear next iteration
                    current_operator.Sign = "multiplication";
                }
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
            }
        }
        private void division_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (result.Text != "" && operand2 == "")
                {
                    operand1 = result.Text;
                    expression.Text = operand1 + " " + "/";
                    clearBox = true; //will clear next iteration
                    current_operator.Sign = "division";
                }
            }
            catch (Exception ex)
            {
                result.Text = "ERROR";
            }
        }
    }
}
