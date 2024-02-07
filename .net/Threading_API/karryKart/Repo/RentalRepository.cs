using ConsoleToDB.Data;
using Contracts;
using Entites.Models;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RentalRepository : IRentalServices
    {
        private readonly DataContext appDbContext;

        public RentalRepository(DataContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Rental>> GetRental()
        {
            return await appDbContext.Rental.ToListAsync();
        }
        public async Task<Rental> GetRentalById(int Id)
        {
            return await appDbContext.Rental
                .FirstOrDefaultAsync(r => r.Id == Id);
        }

        public async Task<Rental> AddRental(Rental rental)
        {
            var result = await appDbContext.Rental.AddAsync(rental);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Rental> UpdateRental(Rental rental)
        {
            var result = await appDbContext.Rental
                .FirstOrDefaultAsync(r => r.Id == rental.Id);

            if (result != null)
            {
                result.RentalPeriodLength = rental.RentalPeriodLength;
                result.RentalPeriod = rental.RentalPeriod;
                result.IsRental = rental.IsRental;
                result.CreatedAt = rental.CreatedAt;
                result.CreatedBy = rental.CreatedBy;
                result.ModifiedBy = rental.ModifiedBy;
                result.ModifiedAt = rental.ModifiedAt;
                result.IsDeleted = rental.IsDeleted;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task DeleteRental(int Id)
        {
            var result = await appDbContext.Rental
                .FirstOrDefaultAsync(r => r.Id == Id);
            if (result != null)
            {
                appDbContext.Rental.Remove(result);
                await appDbContext.SaveChangesAsync();

            }
        }
    }
}
