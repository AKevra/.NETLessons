using ClassLibrary1._4_Shop;

namespace Hometask1._4_Shop
{
    internal class Program
    {
        static void Main()
        {
            int userMoney = 500;

            List<Product> products = GenerateProducts();

            Console.WriteLine("Добро пожаловать в магазин! У вас на счету: " + userMoney + " монет.");

            while (true)
            {
                DisplayProducts(products);
                Console.Write("Введите номер товара для покупки или 0 для выхода: ");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    Console.WriteLine("Спасибо за покупки! Ваш остаток: " + userMoney + " монет.");
                    break;
                }

                if (int.TryParse(input, out int productIndex) && productIndex > 0 && productIndex <= products.Count)
                {
                    Product selectedProduct = products[productIndex - 1];

                    if (userMoney >= selectedProduct.Price)
                    {
                        userMoney -= selectedProduct.Price;
                        Console.WriteLine($"Вы купили {selectedProduct.Name} за {selectedProduct.Price} монет. Остаток: {userMoney} монет.");
                        products.RemoveAt(productIndex - 1);
                    }
                    else
                    {
                        Console.WriteLine("У вас недостаточно денег для покупки этого товара.");
                    }
                }
                else
                {
                    Console.WriteLine("Неправильный выбор. Пожалуйста, попробуйте снова.");
                }
            }
        }

        static List<Product> GenerateProducts()
        {
            Random rand = new Random();
            return new List<Product>
        {
            new Product("Яблоко", 50),
            new Product("Хлеб", 30),
            new Product("Сыр", 100),
        };
        }

        static void DisplayProducts(List<Product> products)
        {
            Console.WriteLine("Товары в наличии:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} - {products[i].Price} монет");
            }
        }
    }
}
