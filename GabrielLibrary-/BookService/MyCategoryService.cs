using BookService.Data;
using Domain.Interfaces;
using Domain.Models;
using LibraryModel;
using Microsoft.EntityFrameworkCore;

namespace BookService
{
    public class MyCategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public MyCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<Category>> Add(Category category)
        {

            ResponseModel<Category> response = new ResponseModel<Category>();
            if (category == null)
            {
                response.Message = "Category cannot be null";
                response.Status = false;
                return response;
            }


            try
            {
                await _context.Category.AddAsync(category);
                await _context.SaveChangesAsync();

                response.Message = "Livro Adicionado";
                response.Status = true;
                response.Data = category;
                return response;

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;
                return response;
            }


        }

        public async Task<ResponseModel<Category>> Delete(Guid id)
        {
            ResponseModel<Category> response = new ResponseModel<Category>();

            var category = _context.Category.FirstOrDefault(c => c.Id == id);

            if (category != null)
            {
                try
                {
                    _context.Category.Remove(category);
                    await _context.SaveChangesAsync();

                    response.Message = "Categoria deletada";
                    response.Status = false;
                    response.Data = category;
                    return response;

                }

                catch (Exception ex)
                {
                    response.Message = ex.Message;
                    response.Status = false;
                    return response;

                }
            }

            response.Message = "Categoria não encontrada";
            response.Status = false;
            response.Data = category;
            return response;

        }

        public async Task<List<Category>> List()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<ResponseModel<Category>> Update(Category category)
        {
            ResponseModel<Category> response = new ResponseModel<Category>();

            if (await _context.Category.AnyAsync(c => c.Id == category.Id))
            {
                try
                {
                    _context.Category.Update(category);
                    await _context.SaveChangesAsync();
                    response.Message = "Categoria Atualizado";
                    response.Status = true;
                    response.Data = category;
                    return response;

                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                    response.Status = true;
                    return response;
                }
            }
            else
            {
                response.Message = "Não encontrado";
                response.Status = false;
                response.Data = category;
                return response;
            }
        }
        public async Task<Category> GetById(Guid id)
        {
            var category = await _context.Category.FirstOrDefaultAsync(c => c.Id == id);

            return category;
        }
    }
    

}
