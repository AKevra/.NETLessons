namespace Himetask1._2_Poem
{
    internal class Program
    {
        static void Main()
        {
            string[] words = {
            "осень", "пришла", "ветер", "летает",
            "листья", "кружат", "сердце", "мечтает",
            "вдали", "костёр", "вечер", "зовёт",
            "и", "звёздный", "свет", "нам", "шепчет", "что-то"
            };

            string poem = GeneratePoem(words, 4);

            Console.WriteLine("Your poem:");
            Console.WriteLine(poem);
        }

        static string GeneratePoem(string[] words, int lines)
        {
            Random rand = new Random();
            HashSet<int> usedIndices = new HashSet<int>();
            string result = "";

            for (int i = 0; i < lines; i++)
            {
                List<string> lineWords = new List<string>();

                while (lineWords.Count < 4)
                {
                    int index = rand.Next(words.Length);
                    if (!usedIndices.Contains(index))
                    {
                        usedIndices.Add(index);
                        lineWords.Add(words[index]);
                    }
                }

                result += string.Join(" ", lineWords) + ",\n";
            }

            return result.TrimEnd(',', '\n');
        }
    }
}
