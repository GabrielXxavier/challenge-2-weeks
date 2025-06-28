using BookService.Data;
using Domain.Interfaces;
using Domain.Models;
using LibraryModel;

namespace BookService
{
    public class MyCategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public MyCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ResponseModel<Category>> Add(Category book)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Category>> Delete(Category id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> List()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Category>> Update(Category book)
        {
            throw new NotImplementedException();
        }
    }
}
