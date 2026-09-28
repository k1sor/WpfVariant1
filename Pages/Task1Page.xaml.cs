using System.Windows;
using System.Windows.Controls;

namespace WpfVariant1.Pages
{
    /// Задача 1. Проверка делимости двоичного числа на 15.
    public partial class Task1Page : Page
    {
        public Task1Page()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string input = TxtInput.Text.Trim();

            // Проверка корректности введённых данных
            if (string.IsNullOrEmpty(input))
            {
                TxtResult.Text = "Ошибка: введите двоичное число.";
                return;
            }

            if (input.Length > 10000)
            {
                TxtResult.Text = "Ошибка: длина числа не должна превышать 10000 двоичных разрядов.";
                return;
            }

            foreach (char c in input)
            {
                if (c != '0' && c != '1')
                {
                    TxtResult.Text = "Ошибка: строка должна содержать только символы 0 и 1.";
                    return;
                }
            }

            // Определение остатка от деления на 15 без перевода
            // всей (потенциально очень длинной) двоичной строки в число:
            // на каждом шаге remainder = (remainder * 2 + очередной_бит) % 15
            int remainder = 0;
            foreach (char c in input)
            {
                int bit = c - '0';
                remainder = (remainder * 2 + bit) % 15;
            }

            TxtResult.Text = remainder == 0
                ? "Число делится на 15 без остатка."
                : $"Число НЕ делится на 15. Остаток от деления: {remainder}.";
        }
    }
}
