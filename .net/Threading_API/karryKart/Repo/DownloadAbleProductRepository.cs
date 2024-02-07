using ConsoleToDB.Data;
using Contracts;
using Entites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DownloadRepository : IDownloadableProductServices
    {
        private readonly DataContext appDbContext;

        public DownloadRepository(DataContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<DownloadableProduct>> GetDownloadableProduct()
        {
            return await appDbContext.DownloadableProduct.ToListAsync();
        }

        public async Task<DownloadableProduct> GetDownloadableProductById(int Id)
        {
            return await appDbContext.DownloadableProduct .FirstOrDefaultAsync(p => p.Id == Id);
        }
        public async Task<DownloadableProduct> AddDownloadableProduct(DownloadableProduct downloadableProduct)
        {
            var result = await appDbContext.DownloadableProduct.AddAsync(downloadableProduct);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<IQueryable<DownloadableProduct>> GetDownloadableProductName(string name)
        {

            var query = from value in appDbContext.DownloadableProduct
                        where value.DownloadURL == name || value.CreatedBy == name
                        select value;

            return query;
        }
        public async Task<DownloadableProduct> UpdateDownloadableProduct(DownloadableProduct downloadableProduct)
        {
            var result = await appDbContext.DownloadableProduct
                .FirstOrDefaultAsync(p => p.Id == downloadableProduct.Id);

            if (result != null)
            {
                result.DownloadURL = downloadableProduct.DownloadURL;
                result.NoofDays = downloadableProduct.NoofDays;
                result.UsedownloadURL = downloadableProduct.UsedownloadURL;
                result.CreatedAt = downloadableProduct.CreatedAt;
                result.CreatedBy = downloadableProduct.CreatedBy;
                result.ModifiedAt = downloadableProduct.ModifiedAt;
                result.ModifiedBy = downloadableProduct.ModifiedBy;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task DeleteDownloadableProduct(int Id)
        {
            var result = await appDbContext.DownloadableProduct
                .FirstOrDefaultAsync(p => p.Id == Id);
            if (result != null)
            {
                appDbContext.DownloadableProduct.Remove(result);
                await appDbContext.SaveChangesAsync();

            }
        }
    }
}
