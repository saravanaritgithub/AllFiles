using ConsoleToDB.Data;
using Contracts;
using Entites.Models;
using Entities.Models.Customers;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryServices
    {
        private readonly DataContext _dataContext;
        public CategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Category>> GetCategory()
        {
            return await _dataContext.Category.ToListAsync();
        }
        public Task<Category> GetCategoryById(int parcatgId)
        {
            return  _dataContext.Category.FirstOrDefaultAsync(e => e.CategoryId == parcatgId);
            throw new NotImplementedException();
        }
        public async Task<Category> AddCategory(Category category)
        {
            var result = await _dataContext.Category.AddAsync(category);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<IQueryable<Category>> GetCategoryByName(string name)
        {

            var query = from value in _dataContext.Category
                        where value.CategoryName == name || value.CreatedBy == name
                        select value;

            return query;
        }
        public async Task<Category> UpdateCategory(Category category)
        {
            var result = await _dataContext.Category
                .FirstOrDefaultAsync(e => e.CategoryId == category.CategoryId);

            if (result != null)
            {
                result.CategoryName = category.CategoryName;
                result.CategoryDescription = category.CategoryDescription;
                result.Parent_Catg = category.Parent_Catg;
                result.CreatedAt = category.CreatedAt;
                result.CreatedBy = category.CreatedBy;
                result.ModifiedAt = category.ModifiedAt;
                result.ModifiedBy = category.ModifiedBy;
                result.IsDeleted = category.IsDeleted;
               await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task DeleteCategory(int Id)
        {
            var result = await _dataContext.Category
                .FirstOrDefaultAsync(e => e.CategoryId == Id);
            if (result != null)
            {
                _dataContext.Category.Remove(result);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}