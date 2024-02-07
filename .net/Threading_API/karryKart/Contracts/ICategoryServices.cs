using Entites.Models;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetCategory();
        Task<Category> GetCategoryById(int parcatgId);
        Task<Category> AddCategory(Category parcatg);
        Task<Category> UpdateCategory(Category parcatg);
        Task DeleteCategory(int parcatgId);
    }
}