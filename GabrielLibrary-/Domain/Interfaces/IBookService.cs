using LibraryModel;
using Domain.Models;
using Domain.DTOs.Book;

namespace Domain.Interfaces
{
    public interface IBookService
    {
        Task<List<ListBookDto>> List();
        Task<ResponseModel<Book>> Add(Book book);
        Task<ResponseModel<Book>> Update(Book book);
        Task<ResponseModel<Book>> Delete(Guid id);
    }
}
