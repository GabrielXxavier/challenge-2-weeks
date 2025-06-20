using System.Reflection;

namespace LibraryWeb.Models
{
    public class Book
    {
        public Guid Id { get; init; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Value { get; set; }

        public Book(string title, string author, string category, int value)
        {
            Guid id = Guid.NewGuid();
            Title = title;
            Author = author;
            Category = category;
            Value = value;
        }
    }
}