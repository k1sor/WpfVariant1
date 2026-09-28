using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WpfVariant1.Pages
{

    /// Задача 5. Генерация двумерного массива M x N со значениями от -10 до 10,
    /// сортировка по возрастанию/убыванию, поиск максимума и минимума.

    public partial class Task5Page : Page
    {
        private static readonly Random Rnd = new Random();

        public Task5Page()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            // Проверка корректности введённых данных
            if (!int.TryParse(TxtM.Text.Trim(), out int m) || m <= 0 || m > 20)
            {
                TxtResult.Text = "Ошибка: количество столбцов (M) должно быть целым числом от 1 до 20.";
                return;
            }

            if (!int.TryParse(TxtN.Text.Trim(), out int n) || n <= 0 || n > 20)
            {
                TxtResult.Text = "Ошибка: количество строк (N) должно быть целым числом от 1 до 20.";
                return;
            }

            // Генерация исходного массива значениями от -10 до 10
            int[,] array = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    array[i, j] = Rnd.Next(-10, 11);

            GridOriginal.ItemsSource = ToTable(array, n, m).DefaultView;

            // Сортировка по возрастанию
            int[] flatAsc = Flatten(array, n, m);
            Array.Sort(flatAsc);
            GridAsc.ItemsSource = ToTable(Reshape(flatAsc, n, m), n, m).DefaultView;

            // Сортировка по убыванию
            int[] flatDesc = (int[])flatAsc.Clone();
            Array.Reverse(flatDesc);
            GridDesc.ItemsSource = ToTable(Reshape(flatDesc, n, m), n, m).DefaultView;

            // Поиск максимального и минимального элементов
            int max = flatAsc[flatAsc.Length - 1];
            int min = flatAsc[0];
            TxtResult.Text = $"Максимальный элемент: {max}. Минимальный элемент: {min}.";
        }

        private int[] Flatten(int[,] array, int rows, int cols)
        {
            int[] result = new int[rows * cols];
            int k = 0;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    result[k++] = array[i, j];
            return result;
        }

        private int[,] Reshape(int[] flat, int rows, int cols)
        {
            int[,] result = new int[rows, cols];
            int k = 0;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    result[i, j] = flat[k++];
            return result;
        }


        /// Преобразует двумерный массив в DataTable для отображения в DataGrid.

        private DataTable ToTable(int[,] array, int rows, int cols)
        {
            DataTable table = new DataTable();
            for (int j = 0; j < cols; j++)
                table.Columns.Add($"Стб {j + 1}", typeof(int));

            for (int i = 0; i < rows; i++)
            {
                DataRow row = table.NewRow();
                for (int j = 0; j < cols; j++)
                    row[j] = array[i, j];
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
