namespace Hometask1._3_Quest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вы находитесь в лесу. Перед вами два пути: налево и направо.");
            Console.Write("Введите ваш выбор (налево/направо): ");
            string choice = Console.ReadLine().ToLower();

            if (choice == "налево")
            {
                GoLeft();
            }
            else if (choice == "направо")
            {
                GoRight();
            }
            else
            {
                Console.WriteLine("Неправильный выбор. Игра окончена.");
            }
        }

        static void GoLeft()
        {
            Console.WriteLine("Вы пошли налево и встретили озеро.");
            Console.WriteLine("Вы можете: 1) поплавать в озере 2) вернуться обратно.");
            Console.Write("Введите ваш выбор (1/2): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Вы поплыли в озере и нашли сокровище! Поздравляем, вы выиграли!");
            }
            else if (choice == "2")
            {
                Console.WriteLine("Вы вернулись обратно и теперь у вас нет приключений. Конец игры.");
            }
            else
            {
                Console.WriteLine("Неправильный выбор. Игра окончена.");
            }
        }

        static void GoRight()
        {
            Console.WriteLine("Вы пошли направо и встретили медведя!");
            Console.WriteLine("Вы можете: 1) попробовать успокоить медведя 2) убежать.");
            Console.Write("Введите ваш выбор (1/2): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Медведь оказался дружелюбным и вы стали хорошими друзьями! Поздравляем, вы выиграли!");
            }
            else if (choice == "2")
            {
                Console.WriteLine("Вы убежали от медведя и спаслись! Конец игры.");
            }
            else
            {
                Console.WriteLine("Неправильный выбор. Игра окончена.");
            }
        }
    }
}
