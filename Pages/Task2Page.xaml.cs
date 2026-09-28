using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace WpfVariant1.Pages
{
    /// <summary>
    /// Задача 2. Определение типа записи числа в строке:
    /// 1 - целое число, 2 - вещественное число, 0 - не число.
    /// Разработал: Шереметов И.В., группа ПР-25.106
    /// </summary>
    public partial class Task2Page : Page
    {
        public Task2Page()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string input = TxtInput.Text;

            // Проверка корректности введённых данных
            if (string.IsNullOrWhiteSpace(input))
            {
                TxtResult.Text = "Ошибка: введите строку для проверки.";
                return;
            }

            input = input.Trim();

            int code;
            string description;

            if (long.TryParse(input, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out _))
            {
                // Строка целиком является записью целого числа
                code = 1;
                description = "строка является записью целого числа";
            }
            else if (input.Contains(".") &&
                     double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out _))
            {
                // Строка содержит десятичную точку и распознаётся как вещественное число
                code = 2;
                description = "строка является записью вещественного числа (с дробной частью)";
            }
            else
            {
                code = 0;
                description = "строку нельзя преобразовать в число";
            }

            TxtResult.Text = $"{code} — {description}";
        }
    }
}
