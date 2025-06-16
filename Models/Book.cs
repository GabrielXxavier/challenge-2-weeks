using System;
using LibraryApi.Records;

namespace LibraryApi.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public int Value { get; set; }
    public string Author { get; set; }

    public Book(string title, string category, int value, string author)
    {
        Id = Guid.NewGuid();
        Title = title;
        Category = category;
        Value = value;
        Author = author;
    }

    public void PutBook(string title, string category, int value, string author)
    {
        Title = title;
        Category = category;
        Value = value;
        Author = author;
    }
    
    public void DeleteBook(Guid id)
    {
        Id = id;
    }
}