using BookService.Data;
using Domain;
using LibraryModel;
using LibraryWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace BookService
{
    public class MyBookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public MyBookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<Book>> Add(Book book)
        {
            ResponseModel<Book> response = new ResponseModel<Book>();

            if (book == null)
            {
                response.Message = "Book cannot be null";
                response.Status = false;
                return response;
            }


            try
            {
                await _context.Book.AddAsync(book);
                await _context.SaveChangesAsync();
        
                response.Message = "Livro Adicionado";
                response.Status = true;
                response.Data = book;
                return response;
                
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;
                return response;
            }

        }

        public async Task<List<Book>> List()
        {
          
            return await _context.Book.ToListAsync();
        }

        public async Task<ResponseModel<Book>> Update(Book book)
        {
            ResponseModel<Book> response = new ResponseModel<Book>();
            if (await _context.Book.AnyAsync(b => b.Id == book.Id))
            {
                _context.Book.Update(book);
                await _context.SaveChangesAsync();
                response.Message = "Livro Atualizado";
                response.Status = true;
                return response;
            }
            else
            {
                throw new KeyNotFoundException("Book not found");
            }
        }

        public async Task<ResponseModel<Book>> Delete(Guid id)
        {

            ResponseModel<Book> response = new ResponseModel<Book>();

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException("Book not found");
            }
            try
            {

                _context.Book.Remove(book);
                await _context.SaveChangesAsync();
               
                response.Message = "Livro Excluido";
                response.Status = true;
                return response;

            }catch (Exception ex)
            {

                throw new InvalidOperationException("An error occurred while adding the book.", ex);
            }

            }
    }
}
