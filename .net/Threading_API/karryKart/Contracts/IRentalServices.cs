using Entites.Models;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRentalServices
    {
        Task<IEnumerable<Rental>> GetRental();
        Task<Rental> GetRentalById(int inventoryId);
        Task<Rental> AddRental(Rental rental);
        Task DeleteRental(int id);
        Task<Rental> UpdateRental(Rental rental);
    }
}
