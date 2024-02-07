using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites.Models;
using Entity.Models;

namespace Contracts
{
    public interface IparentCategoryServices
    {
        Task<IEnumerable<ParentCategory>> GetParentCategory();
        Task<ParentCategory> GetParentCategoryById(int parcatgId);
        Task<ParentCategory> AddParentCategory(ParentCategory parent_category);
        Task<ParentCategory> updateParentCategory(ParentCategory parent_category);
        Task DeleteParentCategory(int id);
        Task<IQueryable<ParentCategory>> GetParentCategoryByName(string name);
    }
}
