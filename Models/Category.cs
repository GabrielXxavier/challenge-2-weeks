using System;

namespace LibraryApi.Models;

public class Category
{
    public Guid Id { get; init; }
    public string Name { get; set; }

    public Category(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}
