using Entites.Models;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDownloadableProductServices
    {
        Task<IEnumerable<DownloadableProduct>> GetDownloadableProduct();
        Task<DownloadableProduct> GetDownloadableProductById(int downloadableProductId);
        Task<DownloadableProduct> AddDownloadableProduct(DownloadableProduct downloadableProduct);
        Task<DownloadableProduct> UpdateDownloadableProduct(DownloadableProduct downloadableProduct);
        Task DeleteDownloadableProduct(int id);
    }
}
