using ConsoleToDB.Data;
using Contracts;
using Entites.Models;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SEORepository : ISEOServices
    {
        private readonly DataContext appDbContext;

        public SEORepository(DataContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<SEO>> GetSEO()
        {
            return await appDbContext.SEO.ToListAsync();
        }
        public async Task<SEO> GetSEOById(int Id)
        {
            return await appDbContext.SEO.FirstOrDefaultAsync(p => p.Id == Id);
        }
        public async Task<SEO> AddSEO(SEO seo)
        {
            var result = await appDbContext.SEO.AddAsync(seo);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
        
        public async Task<SEO> UpdateSEO(SEO seo)
        {
            var result = await appDbContext.SEO
                .FirstOrDefaultAsync(p => p.Id == seo.Id);

            if (result != null)
            {
                result.searchenginefriendlypagename = seo.searchenginefriendlypagename;
                result.MetaTitle = seo.MetaTitle;
                result.MetaKeywords = seo.MetaKeywords;
                result.MetaDescription = seo.MetaDescription;
                result.CreatedBy = seo.CreatedBy;
                result.CreatedAt = seo.CreatedAt;
                result.ModifiedAt = seo.ModifiedAt;
                result.ModifiedBy = seo.ModifiedBy;
                result.IsDeleted = seo.IsDeleted;


                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
        public async Task DeleteSEO(int Id)
        {
            var result = await appDbContext.SEO
                .FirstOrDefaultAsync(p => p.Id == Id);
            if (result != null)
            {
                appDbContext.SEO.Remove(result);
                await appDbContext.SaveChangesAsync();

            }
        }
    }
}
