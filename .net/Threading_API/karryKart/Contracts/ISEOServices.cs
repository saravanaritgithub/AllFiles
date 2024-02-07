using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISEOServices
    {
        Task<IEnumerable<SEO>> GetSEO();
        Task<SEO> AddSEO(SEO seo);
        Task<SEO> UpdateSEO(SEO seo);
        Task DeleteSEO(int seoId);
        Task<SEO> GetSEOById(int seoId);
    }
}
