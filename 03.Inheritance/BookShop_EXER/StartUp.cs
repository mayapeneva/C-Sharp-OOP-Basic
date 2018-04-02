using System;

namespace BookShop_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var author = Console.ReadLine();
                var title = Console.ReadLine();
                var price = decimal.Parse(Console.ReadLine());

                var book = new Book(author, title, price);
                var goldeEditionBook = new GoldenEditionBook(author, title, price);

                Console.WriteLine(book.ToString());
                Console.WriteLine(goldeEditionBook.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}