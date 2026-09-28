using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfVariant1.Pages
{

    /// Задача 4. Перестановка начала и конца массива местами
    /// без использования дополнительного массива (алгоритм разворотов).

    public partial class Task4Page : Page
    {
        public Task4Page()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string arrayInput = TxtArray.Text.Trim();
            string mInput = TxtM.Text.Trim();

            // Проверка корректности введённых данных
            if (string.IsNullOrEmpty(arrayInput))
            {
                TxtResult.Text = "Ошибка: введите элементы массива.";
                return;
            }

            string[] tokens = arrayInput.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            int[] array = new int[tokens.Length];

            for (int i = 0; i < tokens.Length; i++)
            {
                if (!int.TryParse(tokens[i], out array[i]))
                {
                    TxtResult.Text = $"Ошибка: \"{tokens[i]}\" не является целым числом.";
                    return;
                }
            }

            if (array.Length < 2)
            {
                TxtResult.Text = "Ошибка: массив должен содержать не менее двух элементов.";
                return;
            }

            if (!int.TryParse(mInput, out int m) || m <= 0 || m >= array.Length)
            {
                TxtResult.Text = $"Ошибка: m должно быть целым числом от 1 до {array.Length - 1}.";
                return;
            }

            int total = array.Length;
            int n = total - m;

            // Алгоритм трёх разворотов - без использования дополнительного массива,
            // число действий порядка m + n:
            // 1) развернуть первый отрезок 
            // 2) развернуть второй отрезок 
            // 3) развернуть весь массив 
            Reverse(array, 0, m - 1);
            Reverse(array, m, total - 1);
            Reverse(array, 0, total - 1);

            TxtResult.Text = $"m = {m}, n = {n}. Результат перестановки: {string.Join(" ", array)}";
        }

        private void Reverse(int[] array, int left, int right)
        {
            while (left < right)
            {
                int temp = array[left];
                array[left] = array[right];
                array[right] = temp;
                left++;
                right--;
            }
        }
    }
}
