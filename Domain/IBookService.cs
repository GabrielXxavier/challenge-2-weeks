using LibraryWeb.Models;
using Microsoft.EntityFrameworkCore;
using LibraryModel;
namespace Domain
{
    public interface IBookService
    {
        Task<List<Book>> List();
        Task<ResponseModel<Book>> Add(Book book);
        Task<ResponseModel<Book>> Update(Book book);
        Task<ResponseModel<Book>> Delete(Guid id);
    }
}
