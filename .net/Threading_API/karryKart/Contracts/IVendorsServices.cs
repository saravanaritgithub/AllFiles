using Entites.Models;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IVendorsServices
    {
        Task<IEnumerable<Vendors>> GetVendors();
        Task<Vendors> GetVendorsById(int vendorsId);
        Task<Vendors> AddVendors(Vendors vendors);
        Task<Vendors> updateVendors(Vendors vendors);
        Task DeleteVendors(int id);
    }
}
