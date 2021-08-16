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
        double firstNumber = 0;
        double secondNumber = 0;
        string operation = "";

        public MainWindow()
        {
            InitializeComponent();
        }


        //////////////////////////////////Helpers////////////////////////////
        #region Helpers
        private void ButtonLogic(int btnNbr)
        {
            //If an operation has not been provided we know its the first number
            if (operation == "")
            {
                //check to see if there is a decimal involved. 
                if (textDisplay.Text.Contains("."))
                {

                    //convert it to a string and then add it to the btnNumber to the end of the string and convert it back into a number
                    var firstNumStr = firstNumber.ToString();

                    //need to check to see if there was previously a . added to the firstNum
                    if (firstNumStr.Contains("."))
                    {
                        //add the btnNbr to the end of the first Num String
                        firstNumStr = firstNumStr + btnNbr;

                        //convert it back to the firstNumber 
                        firstNumber = Convert.ToDouble(firstNumStr);

                        //update the UI
                        textDisplay.Text = firstNumStr;

                    }
                    else
                    {
                        //firstNum did not previously contain the decimal need to add it in then concatnate the btnNumber
                        firstNumStr = firstNumStr + "." + btnNbr.ToString();

                        //conver the first number string back to a double
                        firstNumber = Convert.ToDouble(firstNumStr);

                        //update the UI
                        textDisplay.Text = firstNumStr;
                    }
                }
                else
                {
                    firstNumber = (firstNumber * 10) + btnNbr;
                    textDisplay.Text = firstNumber.ToString();
                }
            }
            else
            {
                
                    if (textDisplay.Text.Contains("."))
                    {

                        //convert it to a string and then add it to the btnNumber to the end of the string and convert it back into a number
                        var secondNumStr = secondNumber.ToString();

                        //need to check to see if there was previously a . added to the firstNum
                        if (secondNumStr.Contains("."))
                        {
                            //add the btnNbr to the end of the first Num String
                            secondNumStr = secondNumStr + btnNbr;

                            //convert it back to the firstNumber 
                            secondNumber = Convert.ToDouble(secondNumStr);

                            //update the UI
                            textDisplay.Text = secondNumStr;

                        }
                        else
                        {
                            //firstNum did not previously contain the decimal need to add it in then concatnate the btnNumber
                            secondNumStr = secondNumStr + "." + btnNbr.ToString();

                            //conver the first number string back to a double
                            secondNumber = Convert.ToDouble(secondNumStr);

                            //update the UI
                            textDisplay.Text = secondNumStr;
                        }
                    }
                    else
                    {
                        secondNumber = (secondNumber * 10) + btnNbr;
                        textDisplay.Text = secondNumber.ToString();
                    }

                
            }
        }
        private void OperationHandler(string op)
        {
            operation = op;
            textDisplay.Text = "0";
        }
        #endregion


        ////////////////////////////////Number Click Handlers///////////////////////////////////////////////////
        #region NumberClick Handlers
        private void Button_Click_One(object sender, RoutedEventArgs e)
        {
            ButtonLogic(1);
        }

        private void Button_Click_Two(object sender, RoutedEventArgs e)
        {
            ButtonLogic(2);
        }
        
        
        private void Button_Click_Three(object sender, RoutedEventArgs e)
        {
            ButtonLogic(3);
        }


        private void Button_Click_Four(object sender, RoutedEventArgs e)
        {
            ButtonLogic(4);
        }

        private void Button_Click_Five(object sender, RoutedEventArgs e)
        {
            ButtonLogic(5);
        }

        private void Button_Click_Six(object sender, RoutedEventArgs e)
        {
            ButtonLogic(6);
        }

        private void Button_Click_Seven(object sender, RoutedEventArgs e)
        {
            ButtonLogic(7);
        }

        private void Button_Click_Eight(object sender, RoutedEventArgs e)
        {
            ButtonLogic(8);
        }

        private void Button_Click_Nine(object sender, RoutedEventArgs e)
        {
            ButtonLogic(9);
        }

        private void Button_Click_Zero(object sender, RoutedEventArgs e)
        {
            ButtonLogic(0);
        }
        #endregion


        ///////////////////Operation Click Handlers ////////////////////////////////////
        #region Operation Handlers
        private void Button_Click_Plus(object sender, RoutedEventArgs e)
        {
            OperationHandler("+");
        }

        private void Button_Click_Minus(object sender, RoutedEventArgs e)
        {
            OperationHandler("-");
        }

        private void Button_Click_Divide(object sender, RoutedEventArgs e)
        {
            OperationHandler("/");
        }

        private void Button_Click_Multiply(object sender, RoutedEventArgs e)
        {
            OperationHandler("*");
        }


        private void Button_Click_Equals(object sender, RoutedEventArgs e)
        {
            double result = 0;
            
            switch (operation)
            {                
                case "+":
                    result = firstNumber + secondNumber;
                    textDisplay.Text = result.ToString();
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    textDisplay.Text = result.ToString();
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    textDisplay.Text = result.ToString();
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    textDisplay.Text = result.ToString();
                    break;
            }

            //I would like the operations to be able to be continued so make the second number the first number, and reset the second number and the operation
            firstNumber = result;
            secondNumber = 0;
            operation = "";

        }

        private void Button_Click_Decimal(object sender, RoutedEventArgs e)
        {

            //check to see if this is the first or second number
            if (operation == "")
            {
                if (firstNumber.ToString().Contains("."))
                {
                    textDisplay.Text = firstNumber.ToString();
                }
                else
                {
                    var firstConvertedString = firstNumber.ToString() + ".0";
                    textDisplay.Text = firstConvertedString;
                    firstNumber = Convert.ToDouble(firstConvertedString);
                }
            }
            else
            {
                if (secondNumber.ToString().Contains("."))
                {
                    textDisplay.Text = secondNumber.ToString();
                }
                else
                {
                    var secondConvertedString = secondNumber.ToString() + ".0";
                    textDisplay.Text = secondConvertedString;
                    secondNumber = Convert.ToDouble(secondConvertedString);
                }
            }
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            

            //check to see if its the first or second number
            if(operation == "")
            {
                
                string firstNumStr = firstNumber.ToString();
                
                //check to see if the first num length is 1 if so set it back to 0
                if(firstNumStr.Length == 1)
                {
                    firstNumber = 0;
                    textDisplay.Text = "0";

                }
                else
                {
                    firstNumStr = firstNumStr.Remove(firstNumStr.Length - 1, 1);

                    if (firstNumStr.EndsWith("."))
                    {
                        firstNumStr = firstNumStr.Remove(firstNumStr.Length - 1, 1);
                    }
                    textDisplay.Text = firstNumStr;
                    firstNumber = Convert.ToDouble(firstNumStr);
                }

                

                
                //check to see if the last character is a "." if it is remove that as well
            }
            else
            {
                string secondNumStr = secondNumber.ToString();

                //check to see if the first num length is 1 if so set it back to 0
                if (secondNumStr.Length == 1)
                {
                    secondNumber = 0;
                    textDisplay.Text = "0";

                }
                else
                {
                    secondNumStr = secondNumStr.Remove(secondNumStr.Length - 1, 1);

                    if (secondNumStr.EndsWith("."))
                    {
                        secondNumStr = secondNumStr.Remove(secondNumStr.Length - 1, 1);
                    }
                    textDisplay.Text = secondNumStr;
                    secondNumber = Convert.ToDouble(secondNumStr);
                }
            }

        }

        #endregion

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            if(textDisplay.Text != "0")
            {
                if (operation == "")
                {
                    firstNumber = 0;
                    textDisplay.Text = firstNumber.ToString();
                }
                else
                {
                    secondNumber = 0;
                    textDisplay.Text = secondNumber.ToString();
                }
            }
        }

        private void Button_Click_ClearEverything(object sender, RoutedEventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            operation = "";
            textDisplay.Text = firstNumber.ToString();
        }

        private void Button_Click_PosNeg(object sender, RoutedEventArgs e)
        {
            if(operation == "")
            {
                firstNumber = firstNumber * -1;
                textDisplay.Text = firstNumber.ToString();                
            }
            else
            {
                secondNumber = secondNumber * -1;
                textDisplay.Text = secondNumber.ToString();
            }
        }
    }
}
