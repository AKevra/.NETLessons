using System.Text.RegularExpressions;

namespace Hometask5_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "input.txt"; // Путь к файлу
            string text;

            try
            {
                // Чтение строки текста из файла. Я просто указала путь.
                // Можно было сделать как введите путь к файлу, прочитать и открыть. Но я не посчитала это необходимым
                text = File.ReadAllText(filePath);
                if (string.IsNullOrEmpty(text))
                {
                    Console.WriteLine($"Файл не содержит текста: {filePath}. Отредактируйте файл и нажмите Enter");
                    var key = Console.ReadKey();
                    text = (key.Key == ConsoleKey.Enter) ? File.ReadAllText(filePath) : "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                return;
            }

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Найти слова, содержащие максимальное количество цифр.");
                Console.WriteLine("2. Найти самое длинное слово и определить, сколько раз оно встретилось в тексте.");
                Console.WriteLine("3. Заменить цифры от 0 до 9 на слова «ноль», «один», ..., «девять».");
                Console.WriteLine("4. Вывести на экран сначала вопросительные, а затем восклицательные предложения.");
                Console.WriteLine("5. Вывести на экран только предложения, не содержащие запятых.");
                Console.WriteLine("6. Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву.");
                Console.WriteLine("0. Выход");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        FindWordsWithMaxDigits(text);
                        break;
                    case "2":
                        FindLongestWord(text);
                        break;
                    case "3":
                        ReplaceDigitsWithWords(text);
                        break;
                    case "4":
                        PrintQuestionsAndExclamations(text);
                        break;
                    case "5":
                        PrintSentencesWithoutCommas(text);
                        break;
                    case "6":
                        FindWordsStartingAndEndingWithSameLetter(text);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        static void FindWordsWithMaxDigits(string text)
        {
            var words = text.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            int maxDigitCount = 0;
            List<string> result = new List<string>();

            foreach (var word in words)
            {
                int digitCount = word.Count(char.IsDigit);
                if (digitCount > maxDigitCount)
                {
                    maxDigitCount = digitCount;
                    result.Clear();
                    result.Add(word);
                }
                else if (digitCount == maxDigitCount && digitCount > 0)
                {
                    result.Add(word);
                }
            }

            Console.WriteLine("Слова с максимальным количеством цифр:");
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
        }

        static void FindLongestWord(string text)
        {
            var words = text.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            var longestWord = words.OrderByDescending(w => w.Length).FirstOrDefault();

            int count = words.Count(w => w == longestWord);

            Console.WriteLine($"Самое длинное слово: {longestWord}, встречается {count} раз(а).");
        }

        static void ReplaceDigitsWithWords(string text)
        {
            string[] digitWords = { "ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };

            for (int i = 0; i <= 9; i++)
            {
                text = text.Replace(i.ToString(), digitWords[i]);
            }
            Console.WriteLine("Текст после замены цифр на слова:");
            Console.WriteLine(text);
        }

        static void PrintQuestionsAndExclamations(string text)
        {
            var sentences = Regex.Split(text.TrimEnd(), @"(?<=[!?])[""]?\s*|(?<=[.])\s*");

            Console.WriteLine("\nВопросительные предложения:");
            foreach (var sentence in sentences.Where(s => s.Trim().EndsWith("?") || s.Trim().EndsWith("?\"")))
            {
                Console.WriteLine(sentence);
            }

            Console.WriteLine("\nВосклицательные предложения:");
            foreach (var sentence in sentences.Where(s => s.Trim().EndsWith("!") || s.Trim().EndsWith("!\"")))
            {
                Console.WriteLine(sentence);
            }
        }

        static void PrintSentencesWithoutCommas(string text)
        {
            var sentences = Regex.Split(text.TrimEnd(), @"(?<=[!?])[""]?\s*|(?<=[.])\s*");

            Console.WriteLine("Предложения без запятых:");
            foreach (var sentence in sentences.Where(s => !s.Contains(",")))
            {
                Console.WriteLine(sentence);
            }
        }

        static void FindWordsStartingAndEndingWithSameLetter(string text)
        {
            var words = text.Split(new char[] { ' ', ',', '.', '!', '?','-' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> result = new List<string>();

            foreach (var word in words)
            {
                //если слово состоит из 1 буквы я решила скипать
                if (word.Length == 1) continue;

                if (char.ToLower(word[0]) == char.ToLower(word[word.Length - 1]))
                {
                    result.Add(word);
                }
            }

            Console.WriteLine("Слова, начинающиеся и заканчивающиеся на одну и ту же букву:");
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
        }
    }
}