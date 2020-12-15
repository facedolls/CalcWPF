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

namespace CalcWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double numbersFisrt = 0;
        double numbersSecond = 0;
        string operation = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_num_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            String num = button.Content.ToString();
            if (textBox.Text == "0")
                textBox.Text = num;
            else
                textBox.Text += num;

            if (operation == "")
                numbersFisrt = double.Parse(textBox.Text);
            else
                numbersSecond = double.Parse(textBox.Text);
        }
        private void btn_op_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Content.ToString();
            textBox.Text = "0";
        }
        private void btn_eq_Click(object sender, RoutedEventArgs e)
        {
            double result = 0;
            switch (operation)
            {
                case "x^y":
                    result = Math.Pow(numbersFisrt, numbersSecond);
                    break;
                case "/":
                    if(numbersSecond > 0)
                        result = numbersFisrt / numbersSecond;
                    break;
                case "*":
                    result = numbersFisrt * numbersSecond;
                    break;
                case "-":
                    result = numbersFisrt - numbersSecond;
                    break;
                case "+":
                    result = numbersFisrt + numbersSecond;
                    break;
                case "min":
                    result = Math.Min(numbersFisrt, numbersSecond);
                    break;
                case "max":
                    result = Math.Max(numbersFisrt, numbersSecond);
                    break;
                case "avg":
                    result = (numbersFisrt + numbersSecond) / 2;
                    break;
            }
            textBox.Text = result.ToString();
            operation = "";
            numbersFisrt = result;
            numbersSecond = 0;
        }

        private void btn_c_Click(object sender, RoutedEventArgs e)
        {
            numbersFisrt = 0;
            numbersSecond = 0;
            operation = "";
            textBox.Text = "0";
        }

        private void btn_ce_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
                numbersFisrt = 0;
            else
                numbersSecond = 0;
            textBox.Text = "0";
        }
        private void btn_backspace_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = DropLastChar(textBox.Text);
            if (operation == "")
                numbersFisrt = double.Parse(textBox.Text);
            else
                numbersSecond = double.Parse(textBox.Text);
        }

        private string DropLastChar(string text)
        {
            if (text.Length == 1)
                text = "0";
            else
            {
                text = text.Remove(text.Length - 1, 1);
                if(text[text.Length - 1] == '.' || text[text.Length - 1] == ',')
                    text = text.Remove(text.Length - 1, 1);
            }
            return text;
        }

        private void btn_plusminus_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                numbersFisrt *= -1;
                textBox.Text = numbersFisrt.ToString();
            }
            else
            {
                numbersSecond *= -1;
                textBox.Text = numbersSecond.ToString();
            }
        }

        private void btn_comma_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
                SetComma(numbersFisrt);
            else
                SetComma(numbersSecond);
        }

        private void SetComma(double num)
        {
            if (textBox.Text.Contains('.') || textBox.Text.Contains(','))
                return;
            else
                textBox.Text += ',';
        }
    }
}
