using Entites.Models;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITaxServices
    {
        Task<IEnumerable<Tax>> GetTax();
        Task<Tax> GetTaxById(int taxId);
        Task<Tax> AddTax(Tax tax);
        Task<Tax> updateTax(Tax tax);
        Task DeleteTax(int id);
    }
}
