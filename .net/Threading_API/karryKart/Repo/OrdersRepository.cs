using ConsoleToDB.Data;
using Contracts;
using Entities.Models;
using Entities.Models.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrders
    {
        private readonly DataContext appDbContext;

        public OrderRepository(DataContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task<IEnumerable<Orders>> GetOrders()
        {
            return await appDbContext.Orders.ToListAsync();
        }

        public async Task<Orders> GetOrdersbyId(int Id)
        {
            return await appDbContext.Orders
                .FirstOrDefaultAsync(o => o.Id == Id);
        }

        public async Task<IQueryable<Orders>> GetOrdersByName(string name)
        {

            var query = from value in appDbContext.Orders
                        where value.OrderStatus == name || value.CreatedBy == name || value.PaymentStatus == name
                        select value;

            return query;
        }

        public async Task<Orders> AddOrders(Orders orders)
        {
            var result = await appDbContext.Orders.AddAsync(orders);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Orders> UpdateOrders(Orders orders)
        {
            var result = await appDbContext.Orders
                .FirstOrDefaultAsync(o => o.Id == orders.Id);

            if (result != null)
            {

                result.OrderTotal = orders.OrderTotal;
                result.OrderStatus = orders.OrderStatus;
                result.PaymentStatus = orders.PaymentStatus;
                result.ShippingStatus = orders.ShippingStatus;
                result.CreatedBy = orders.CreatedBy;
                result.ModifiedBy = orders.ModifiedBy;
                result.CreatedAt = orders.CreatedAt;
                result.ModifiedAt = orders.ModifiedAt;


                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<Orders> DeleteOrders(int Id)
        {
            var result = await appDbContext.Orders
                .FirstOrDefaultAsync(o => o.Id == Id);
            if (result != null)
            {
                appDbContext.Orders.Remove(result);
                await appDbContext.SaveChangesAsync();

            }
            return result;

        }


    }
}