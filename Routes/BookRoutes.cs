using System;
using System.Linq;
using LibraryApi.Data;
using LibraryApi.Models;
using LibraryApi.Records;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace LibraryApi.Routes;

public static class BookRoutes
{
    public static void MapBookRoutes(this WebApplication app)
    {
        var booksRoutes = app.MapGroup("book");
        
        booksRoutes.MapGet("", async(AppDbContext context) =>
        {
            var book = await context.Book.ToListAsync();
            return Results.Ok(book);
        });
        booksRoutes.MapPost("", async(AddBookRequest request, AppDbContext context) =>
            {
                var isExist = await context.Book.AnyAsync(book => book.Title == request.Title);
                if (isExist)
                {
                    return Results.Conflict("Livro ja cadastrado");
                }
                
                var newBook = new Book(request.Title, request.Category, request.Value, request.Author);
                
                await context.Book.AddAsync(newBook);
                await context.SaveChangesAsync();
                return Results.Ok(newBook);
            }
            );
        
        booksRoutes.MapPut("{title}", async(string title ,PutBookRequest request, AppDbContext context) =>
            {

                var putBook = await context.Book
                    .Where(book => book.Title == title)
                    .FirstOrDefaultAsync();

                if (putBook == null)
                {
                    return Results.NotFound("Livro não encontrado");
                }
                putBook.PutBook(request.Title, request.Category, request.Value, request.Author);
                await context.SaveChangesAsync();
                return Results.Ok("Livro editado com sucesso");
            }
            );
        
        booksRoutes.MapDelete("{title}", async(string title, AppDbContext context) =>
        {
            var book = await context.Book
                .Where(book => book.Title == title)
                .FirstOrDefaultAsync();
            if (book == null)
            {
                return Results.NotFound("Livro não encontrado");
            }
            context.Book.Remove(book);
            await context.SaveChangesAsync();
            return Results.Ok("Livro removido com sucesso");
        });
        
       
    }
}