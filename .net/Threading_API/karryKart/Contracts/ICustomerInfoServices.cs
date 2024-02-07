using Entities.Models.Customers;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICustomerInfo
    {
        Task<IEnumerable<CustomerInfo>> GetCustomerInfo();
        Task<CustomerInfo> GetCustomerInfoId(int customerInfoId);
        Task<CustomerInfo> AddCustomerInfo(CustomerInfo customerInfo);
        Task<CustomerInfo> UpdateCustomerInfo(CustomerInfo customerInfo);
        Task DeleteCustomerInfo(int customerInfoId);
    }
}
