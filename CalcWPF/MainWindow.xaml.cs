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
        double num1 = 0;
        double num2 = 0;
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
            {
                num1 = double.Parse(textBox.Text);
            }
            else
            {
                num2 = double.Parse(textBox.Text);
            }
        }
        private void btn_op_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Content.ToString();
        }
        private void btn_eq_Click(object sender, RoutedEventArgs e)
        {
            double result = 0;
            switch (operation)
            {
                case "x^y":
                    result = Math.Pow(num1,num2);
                    break;
                case "/":
                    if(num2 > 0)
                        result = num1 / num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "+":
                    result = num1 + num2;
                    break;
                case "min":
                    result = Math.Min(num1, num2);
                    break;
                case "max":
                    result = Math.Max(num1, num2);
                    break;
                case "avg":
                    result = (num1 + num2) / 2;
                    break;
            }
            textBox.Text = result.ToString();
            operation = "";
            num1 = result;
            num2 = 0;
        }

        private void btn_c_Click(object sender, RoutedEventArgs e)
        {
            num1 = 0;
            num2 = 0;
            operation = "";
            textBox.Text = "0";
        }

        private void btn_ce_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
                num1 = 0;
            else
                num2 = 0;
            textBox.Text = "0";
        }
        private void btn_backspace_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = DropLastChar(textBox.Text);
            if (operation == "")
                num1 = double.Parse(textBox.Text);
            else
                num2 = double.Parse(textBox.Text);
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
                num1 *= -1;
                textBox.Text = num1.ToString();
            }
            else
            {
                num2 *= -1;
                textBox.Text = num2.ToString();
            }
        }

        private void btn_comma_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
                SetComma(num1);
            else
                SetComma(num2);
        }

        private void SetComma(double num)
        {
            if (textBox.Text.Contains('.') || textBox.Text.Contains(','))
                return;
            else
                textBox.Text += ',';
        }

        private void btn_7_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
