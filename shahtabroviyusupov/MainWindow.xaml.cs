using System;
using System.Collections.Generic;
using System.Data;
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


namespace shahtabroviyusupov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string input = btn.Content.ToString();

            switch (input)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    AddNumber(input);
                    break;
                case ".":
                    AddDecimal();
                    break;
                case "+":
                case "-":
                case "*":
                case "/":
                    SetOperation(input);
                    break;
                case "=":
                    CalculateResult();
                    break;
            }
        }

        private void AddNumber(string input)
        {
            if (txtResult.Text == "0" || char.IsPunctuation(txtResult.Text[0]))
            {
                txtResult.Text = "";
            }
            txtResult.Text += input;
            try
            {
                currentNumber = double.Parse(txtResult.Text);
            }
            catch (FormatException)
            {
                // Обработать ошибку ввода (недопустимый формат числа)
                MessageBox.Show("Ошибка формата числа!", "Калькулятор", MessageBoxButton.OK, MessageBoxImage.Error);
                txtResult.Text = "0";
            }
        }

        private void AddDecimal()
        {
            if (!txtResult.Text.Contains("."))
            {
                txtResult.Text += ".";
            }
        }

        private void SetOperation(string op)
        {
            operation = op;
            try
            {
                currentNumber = double.Parse(txtResult.Text);
            }
            catch (FormatException)
            {
                // Обработать ошибку ввода (недопустимый формат числа)
                MessageBox.Show("Ошибка формата числа!", "Калькулятор", MessageBoxButton.OK, MessageBoxImage.Error);
                txtResult.Text = "0";
            }
            txtResult.Text = "";
        }

        private void CalculateResult()
        {
            if (operation == null)
            {
                return;
            }

            double secondNumber;
            try
            {
                secondNumber = double.Parse(txtResult.Text);
            }
            catch (FormatException)
            {
                // Обработать ошибку ввода (недопустимый формат числа)
                MessageBox.Show("Ошибка формата числа!", "Калькулятор", MessageBoxButton.OK, MessageBoxImage.Error);
                txtResult.Text = "0";
                return;
            }

            switch (operation)
            {
                case "+":
                    txtResult.Text = (currentNumber + secondNumber).ToString();
                    break;
                case "-":
                    txtResult.Text = (currentNumber - secondNumber).ToString();
                    break;
                case "*":
                    txtResult.Text = (currentNumber * secondNumber).ToString();
                    break;
                case "/":
                    if (secondNumber == 0)
                    {
                        MessageBox.Show("Деление на ноль!", "Калькулятор", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtResult.Text = "0";
                    }
                    else
                    {
                        txtResult.Text = (currentNumber / secondNumber).ToString();
                    }
                    break;
            }

            currentNumber = 0;
            operation = null;
        }
    }
}
