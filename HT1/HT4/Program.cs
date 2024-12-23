namespace HT4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк матрицы:");
            int rows = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество столбцов матрицы:");
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, cols];

            // Ввод элементов матрицы поэлементно
            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        Console.WriteLine($"Введите элемент [{i},{j}]:");
            //        matrix[i, j] = int.Parse(Console.ReadLine());
            //    }
            //}

            // Ввод элементов матрицы построчно
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Введите элементы {i + 1}-й строки через запятую:");
                string[] input = Console.ReadLine().Split(',');

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(input[j]);
                }
            }

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Вывести матрицу");
                Console.WriteLine("2. Найти количество положительных/отрицательных чисел");
                Console.WriteLine("3. Сортировать строки матрицы");
                Console.WriteLine("4. Инвертировать строки матрицы");
                Console.WriteLine("5. Выйти");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        PrintMatrix(matrix);
                        break;
                    case 2:
                        CountPosNeg(matrix);
                        break;
                    case 3:
                        SortRows(matrix);
                        break;
                    case 4:
                        InvertRows(matrix);
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Неверный выбор. Попробуйте снова.");
                        break;
                }
                //var l = choice switch
                //{
                //    1 => PrintMatrix(matrix),
                //    2 => CountPosNeg(matrix),
                //    3 => SortRows(matrix),
                //    4 => InvertRows(matrix),
                //    5 => exit = true,
                //    _ => throw new ArgumentOutOfRangeException("Неверный выбор. Попробуйте снова."),
                //};
            }
        }
        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            Console.WriteLine("Матрица:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
        }

        static void CountPosNeg(int[,] matrix)
        {
            int positiveCount = 0;
            int negativeCount = 0;

            foreach (var item in matrix)
            {
                if (item > 0) positiveCount++;
                if (item < 0) negativeCount++;
            }

            Console.WriteLine($"Количество положительных чисел: {positiveCount}");
            Console.WriteLine($"Количество отрицательных чисел: {negativeCount}");
        }

        static void SortRows(int[,] matrix)
        {
            Console.WriteLine("Выберите направление сортировки:");
            Console.WriteLine("1. По возрастанию");
            Console.WriteLine("2. По убыванию");
            int sortChoice = int.Parse(Console.ReadLine());
            bool ascending = sortChoice == 1;
            int cols = matrix.GetLength(1);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    for (int k = 0; k < cols - j - 1; k++)
                    {
                        if ((ascending && matrix[i, k] > matrix[i, k + 1]) ||
                            (!ascending && matrix[i, k] < matrix[i, k + 1]))
                        {
                            int temp = matrix[i, k];
                            matrix[i, k] = matrix[i, k + 1];
                            matrix[i, k + 1] = temp;
                        }
                    }
                }
            }
            PrintMatrix(matrix);
        }

        static void InvertRows(int[,] matrix)
        {
            int cols = matrix.GetLength(1);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < cols / 2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, cols - j - 1];
                    matrix[i, cols - j - 1] = temp;
                }
            }
            PrintMatrix(matrix);
        }
    }
}