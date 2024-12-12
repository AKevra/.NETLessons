namespace Hometask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your full name:");
            var userName = Console.ReadLine();
            Console.WriteLine("Enter your birthday in format (dd.mm.yyyy):");
            var birthDay = Console.ReadLine();
            Console.WriteLine($"Your name: {userName}, your birthday: {birthDay}");
        }
    }
}
