using System.Reflection;

namespace Domain.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Guid Category_id { get; set; }
        public decimal Value { get; set; }

        public Book(string title, string author, Guid category_id, decimal value)
        {
            Guid id = Guid.NewGuid();
            Title = title;
            Author = author;
            Category_id = category_id;
            Value = value;
        }
        public Book() { }
    }
}