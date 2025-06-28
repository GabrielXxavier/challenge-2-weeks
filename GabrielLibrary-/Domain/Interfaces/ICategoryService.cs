using Domain.Models;
using LibraryModel;

namespace Domain.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> List();
        Task<ResponseModel<Category>> Add(Category book);
        Task<ResponseModel<Category>> Update(Category book);
        Task<ResponseModel<Category>> Delete(Category id);
    }
}
