using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites.Models;
using Entity.Models;

namespace Contracts
{
    public interface IManufacturerServices
    {
        Task<IEnumerable<Manufacturer>> GetManufacturer();
        Task<Manufacturer> GetManufacturerById(int manufacturerId);
        Task<Manufacturer> AddManufacturer(Manufacturer manufacturer);
        Task<Manufacturer> UpdateManufacturer(Manufacturer manufacturer);
        Task DeleteManufacturer(int id);
    }
}
