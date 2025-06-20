namespace LibraryWeb.DTOs.Book
{
    public class PutBookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public int Value { get; set; }
    }
}
