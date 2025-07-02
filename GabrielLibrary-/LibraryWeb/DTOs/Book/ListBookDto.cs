using Domain.Models;

namespace LibraryWeb.DTOs.Book

{
    public class ListBookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Category Category { get; set; }
        public int Value { get; set; }
        public ListBookDto(Guid id, string title, string author, Category category, int value)
        {
            Id = id;
            Title = title;
            Author = author;
            Category = category;
            Value = value;
        }
    }
}
