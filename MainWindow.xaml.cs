using System.Windows;
using System.Windows.Controls;


namespace Calculator
{
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        private  SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out double tempNumber))
            {

                tempNumber = tempNumber / 100;
                if (lastNumber != 0)
                {
                    tempNumber *= lastNumber;
                }
                ResultLabel.Content = tempNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                ResultLabel.Content = lastNumber.ToString();    
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "0";
            result = 0;
            lastNumber = 0;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
            {
                ResultLabel.Content = "0";
            }

            if (sender == MultiplyButton)
            {
                selectedOperator = SelectedOperator.Multiplication;
            }

            if (sender == DivideButton)
            {
                selectedOperator = SelectedOperator.Division;
            }

            if(sender == PlusButton)
            {
                selectedOperator  = SelectedOperator.Additon;
            }

            if (sender == MinusButton)
            {
                selectedOperator = SelectedOperator.Subtraction;
            }

        }

    

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && int.TryParse(button.Content.ToString(), out int selectedValue))
            {
                if (ResultLabel.Content.ToString() == "0")
                {
                    ResultLabel.Content = $"{selectedValue}";
                }
                else
                {
                    ResultLabel.Content = $"{ResultLabel.Content}{selectedValue}";
                }
            }
        }


        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (ResultLabel.Content != null && ResultLabel.Content.ToString()!.Contains('.'))
            {
            }
            else
            {
                ResultLabel.Content = $"{ResultLabel.Content}.";
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(ResultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber , newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Additon:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtract(lastNumber, newNumber);
                        break;
                }
                ResultLabel.Content = result.ToString();
            }
        }
    }

    public enum SelectedOperator
    {
        Additon, 
        Subtraction, 
        Division, 
        Multiplication

    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2) => n1 + n2;
        public static double Subtract(double n1, double n2) => n1 - n2;

        public static double Multiply(double n1, double n2) => n1 * n2;

        public static double Divide(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Division by 0 is not supported", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
               
         return   n1 / n2;
        }

    }


}