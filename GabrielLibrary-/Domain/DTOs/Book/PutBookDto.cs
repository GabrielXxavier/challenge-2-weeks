using Domain.Models;

namespace Domain.DTOs.Book
{
    public class PutBookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public string Author { get; set; }
        public decimal Value { get; set; }
    }
}
