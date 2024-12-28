namespace HT3_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continueCalculating = true;

            while (continueCalculating)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в калькулятор!");
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1. Сложение");
                Console.WriteLine("2. Вычитание");
                Console.WriteLine("3. Умножение");
                Console.WriteLine("4. Деление");
                Console.WriteLine("5. Процент от числа");
                Console.WriteLine("6. Квадратный корень числа");
                Console.WriteLine("0. Выход");

                string choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        PerformOperation("+");
                        break;
                    case "2":
                        PerformOperation("-");
                        break;
                    case "3":
                        PerformOperation("*");
                        break;
                    case "4":
                        PerformOperation("/");
                        break;
                    case "5":
                        CalculatePercentage();
                        break;
                    case "6":
                        CalculateSquareRoot();
                        break;
                    case "0":
                        continueCalculating = false;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Пожалуйста, попробуйте снова.");
                        break;
                }

                if (continueCalculating)
                {
                    string continueChoice;
                    do
                    {
                        Console.WriteLine("Хотите продолжить? (y/n)");
                        continueChoice = Console.ReadLine();
                    } while (string.IsNullOrEmpty(continueChoice) ||
                             (continueChoice.ToLower() != "y" && continueChoice.ToLower() != "n"));

                    continueCalculating = continueChoice.ToLower() == "y";
                }
            }

            Console.WriteLine("Спасибо за использование калькулятора! До свидания.");

            void PerformOperation(string operation)
            {
                double num1 = GetNumber("Введите первое число: ");
                double num2 = GetNumber("Введите второе число: ");

                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Деление на ноль.");
                            return;
                        }
                        break;
                }

                Console.WriteLine($"Результат: {result}");
            }

            void CalculatePercentage()
            {
                double number = GetNumber("Введите число: ");
                double percentage = GetNumber("Введите процент: ");
                double result = (number * percentage) / 100;
                Console.WriteLine($"Результат: {result}");
            }

            void CalculateSquareRoot()
            {
                double number = GetNumber("Введите число: ");
                if (number < 0)
                {
                    Console.WriteLine("Ошибка: Невозможно извлечь квадратный корень из отрицательного числа.");
                }
                else
                {
                    double result = Math.Sqrt(number);
                    Console.WriteLine($"Квадратный корень из {number} равен {result}");
                }
            }

            double GetNumber(string prompt)
            {
                double number;
                while (true)
                {
                    Console.Write(prompt);
                    if (double.TryParse(Console.ReadLine(), out number))
                    {
                        return number;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: Введите корректное число.");
                    }
                }
            }
        }
    }
}
