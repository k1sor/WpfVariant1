using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfVariant1.Pages
{

    /// Задача 3. Поиск в одномерном массиве чисел, составленных
    /// из одних и тех же цифр (например 7, 55, 333, 9999).

    public partial class Task3Page : Page
    {
        public Task3Page()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string input = TxtInput.Text.Trim();

            // Проверка корректности введённых данных
            if (string.IsNullOrEmpty(input))
            {
                TxtResult.Text = "Ошибка: введите элементы массива через пробел.";
                return;
            }

            string[] tokens = input.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> numbers = new List<int>();

            foreach (string token in tokens)
            {
                if (!int.TryParse(token, out int value))
                {
                    TxtResult.Text = $"Ошибка: \"{token}\" не является целым числом.";
                    return;
                }
                numbers.Add(value);
            }

            // Поиск чисел, все цифры которых совпадают
            List<string> found = new List<string>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (IsSameDigitNumber(numbers[i]))
                {
                    found.Add($"{numbers[i]} (позиция {i + 1})");
                }
            }

            TxtResult.Text = found.Count > 0
                ? "Найдены числа: " + string.Join(", ", found)
                : "Чисел, составленных из одних и тех же цифр, в массиве не найдено.";
        }


        /// Проверяет, что все десятичные цифры числа совпадают.

        private bool IsSameDigitNumber(int number)
        {
            string digits = Math.Abs(number).ToString();
            char first = digits[0];

            foreach (char c in digits)
            {
                if (c != first)
                    return false;
            }

            return true;
        }
    }
}
