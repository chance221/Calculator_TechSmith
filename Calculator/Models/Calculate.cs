using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Calculator.Models
{
    public class Calculate : INotifyPropertyChanged 
    {
        private double firstNumber = 0;
        private double secondNumber = 0;
        private string operation = "";
        private string errorMessage = ""; 

        public double FirstNumber
        {
            get
            {
                return firstNumber;
            }
            set
            {
                firstNumber = value;
                OnPropertyChanged("FirstNumber");
            }
        }

        public double SecondNumber
        {
            get
            {
                return secondNumber;
            }
            set
            {
                secondNumber = value;
                OnPropertyChanged("SecondNumber");
            }
        }

        public string Operation
        {
            get
            {
                return operation;
            }
            set
            {
                operation = value;
                OnPropertyChanged("Operation");
            }
        }


        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
