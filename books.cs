using System;
using System.Collections;
using System.Collections.Generic;

namespace challenge_2_weeks
{
    public class Books
    {
        List<Dictionary<string, string>> books = new List<Dictionary<string, string>>();
        
        public void setBook()
        {
            Dictionary<string, string> book = new Dictionary<string, string>();

            Console.WriteLine("Digite o titulo: ");
            string title = Console.ReadLine();
            book.Add("titulo", title);

            Console.WriteLine("Digite a categoria: ");
            string category = Console.ReadLine();
            book.Add("categoria", category);

            Console.WriteLine("Digite o valor: ");
            string value= Console.ReadLine();
            book.Add("valor", value);

            Console.WriteLine("Digite o autor: ");
            string author = Console.ReadLine();
            book.Add("autor", author);

            books.Add(book);
            
        }

        public void getBooks()
        {

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}


  