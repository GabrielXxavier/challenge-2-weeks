using System;
using System.Collections.Generic;

namespace challenge_2_weeks
{
    public class Chat
    {
        Dictionary<string, string> books = new Dictionary<string, string>();
      
        public void InitialChat()
        {

            while (true)
            {
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
                        Console.WriteLine("Você escolheu ver livros!");
                        break;
                    case "2":
                        Console.WriteLine("Você escolheu cadastrar um novo livro!");

                        break;

                    case "3":
                        Console.WriteLine("Você escolheu ver livros!");
                        break;

                    case "4":
                        Console.WriteLine("Você escolheu ver livros!");
                        break;

                    case "5":
                        Console.WriteLine("Você escolheu ver livros!");
                        break;

                    case "6":
                        Console.WriteLine("Você escolheu ver livros!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
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