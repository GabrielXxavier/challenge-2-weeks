using System;

namespace LibraryApi.Models;

public class Author
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string DateOfBirth { get; set; }
    public string Nacionality { get; set; }

    public Author(string name, string dateOfBirth, string nacionality)
    {
        Id = Guid.NewGuid();
        Name = name;
        DateOfBirth = dateOfBirth;
        Nacionality = nacionality;
    }
}