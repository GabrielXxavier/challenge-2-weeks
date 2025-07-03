using LibraryModel;
using Domain.Models;
using Domain.DTOs.Book;

namespace Domain.Interfaces
{
    public interface IBookService
    {
        Task<List<ListBookDto>> List();
        Task<ResponseModel<Book>> Add(AddBookDto book);
        Task<ResponseModel<PutBookDto>> Update(PutBookDto book);
        Task<ResponseModel<Book>> Delete(Guid id);
    }
}
