namespace Domain.Models
{
    public class Category
    {
        public Guid Id { get; init; }
        public string Name { get; set; }

        public Category(string name)
        {
            Guid id = Guid.NewGuid();
            Name = name;
        }
    }
}
