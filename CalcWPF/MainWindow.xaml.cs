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
        int num1 = 0;
        int num2 = 0;
        string operation = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_num_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            String str = button.Content.ToString();
            int num = Int32.Parse(str);

            if(operation == "")
            {
                num1 = num1 * 10 + num;
                textBox.Text = num1.ToString();
            }
            else
            {
                num2 = num2 * 10 + num;
                textBox.Text = num2.ToString();
            }
        }
        private void btn_eq_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;
            switch (operation)
            {
                case "/":
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
            }
            textBox.Text = result.ToString();
            operation = "";
            num1 = result;
        }

        private void btn_div_Click(object sender, RoutedEventArgs e)
        {
            operation = "/";
        }
        private void btn_mult_Click(object sender, RoutedEventArgs e)
        {
            operation = "*";
        }
        private void btn_minus_Click(object sender, RoutedEventArgs e)
        {
            operation = "-";
        }
        private void btn_plus_Click(object sender, RoutedEventArgs e)
        {
            operation = "+";
        }
    }
}
