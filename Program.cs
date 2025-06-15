using System;
using System.Collections.Generic;
using System.Threading;
using library.book;
using library.author;
using library.category;

namespace library.chat
{
    public class Chat
    {
        static List<Book> books = new List <Book>();
        static List<Author> authors = new List<Author>();
        static List<Category> categories = new List<Category>();
        
      
        public void InitialChat()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
                    Escolha a função que deseja realizar:

                    Ações Livro:
                        1 - Ver livros
                        2 - Cadastrar novo Livro
                
                    Ações Autor:
                        3 - Ver Autores
                        4 - Cadastrar Novo Autor

                    Ações Categoria:
                        5 - Ver Categorias
                        6 - Cadastrar Nova Categoria
                ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        GetBook();
                        break;
                    case "2":
                        SetBook();

                        break;
                    

                    case "3":
                        GetAuthor();
                        
                        break;

                    case "4":
                        SetAuthor();
                        break;

                    case "5":
                        GetCategory();
                        break;

                    case "6":
                        SetCategory();
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        static bool IsValueInList<T>(string value, string comparedProprietValue, List<T> list)
        {
          
            bool inList = false;
            foreach (var item in list)
            {
                var type = item.GetType();
                var property = type.GetProperty(comparedProprietValue);
                var propValue = property.GetValue(item)?.ToString();
                
                if (propValue == value)
                {
                    inList = true;
                    break;
                }
            }
    
            if (!inList)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static void SetBook()
        {
            Book book = new Book();
            
            Console.WriteLine("Digite o titulo: ");
            string title = Console.ReadLine();
            
            book.Title = title;
            
            Console.WriteLine("Digite o autor: ");
            string author = Console.ReadLine();
            bool isExistentAuthor = IsValueInList(author, "Fullname", authors);
            
    
            if (!isExistentAuthor)
            {
                Console.WriteLine("autor ainda não cadastrado, favor cadastrar");
                Thread.Sleep(2000);
                return;
            }
            else
            {
                book.Author = author;
            }
            
            Console.WriteLine("Digite o valor: ");
            string value = Console.ReadLine();
            book.Value = int.Parse(value);
            
            Console.WriteLine("Digite a categoria: ");
            string category = Console.ReadLine();
            bool isExistentCategory = IsValueInList(category, "Name", categories);
            
            if (!isExistentCategory)
            {
                Console.WriteLine("Categoria ainda não cadastrado, favor cadastrar");
                Thread.Sleep(2000);
                return;
            }
            else
            {
                book.Category = category;
            }

            books.Add(book);
            
        }

        static void GetBook()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Não ah livros");
                Thread.Sleep(2000);
            }
            else
            {
                foreach (var book in books)
                {
                    Console.WriteLine($@"
                    titulo: {book.Title}
                    autor {book.Author}
                    valor: {book.Value}
                    categoria: {book.Category}");
                }
                Thread.Sleep(2000);
            }
        }

        static void SetAuthor()
        {
            Author author = new Author();
            
            Console.WriteLine("Digite o nome completo: ");
            string fullName = Console.ReadLine();
            author.Fullname = fullName;
            
            Console.WriteLine("Digite o data de nascimento: ");
            string dateOfBirth  = Console.ReadLine();
            author.DataOfBirth = dateOfBirth;
            
            Console.WriteLine("Digite a Nacionalidade: ");
            string nacionality = Console.ReadLine();
            author.Nacionality = nacionality;
            
            authors.Add(author);
        }

        static void GetAuthor()
        {
            if (authors.Count == 0)
            {
                Console.WriteLine("Não ah autores");
                Thread.Sleep(2000);
            }
            else
            {
                foreach (var author in authors)
                {
                    Console.WriteLine($@"
                    Nome completo: {author.Fullname}
                    Data de nascimento: {author.DataOfBirth}
                    Nacionalidade: {author.Nacionality}
                    ");
                    Thread.Sleep(2000);
                }
            }
        }

        static void SetCategory()
        {
            Category category = new Category();
            
            Console.WriteLine("Digite o nome da categoria: ");
            string name = Console.ReadLine();
            category.Name = name;
            
            categories.Add(category);
        }

        static void GetCategory()
        {
            if (categories.Count == 0)
            {
                Console.WriteLine("Não ah categorias");
                Thread.Sleep(2000);
            }
            else
            {
                foreach (var category in categories)
                {
                    Console.WriteLine($@"
                    Nome da Categoria: {category.Name}
                    ");
                    Thread.Sleep(2000);
                }
            }
        }

    }
    

    public class Program
    {
        // 👉 O ponto de entrada DO PROGRAMA TEM QUE SER static
        public static void Main(string[] args)
        {
            var chat = new Chat();
            chat.InitialChat();
        }
    }
}