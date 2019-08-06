using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyMS.API.Entities;
using EasyMS.API.QueryBuilders;

namespace EasyMS.API.Endpoints
{
    public interface IOrders
    {
        Task<Order> GetAsync(string orderId, string organizationId);

        Task<EasyMSList<Order>> GetAllAsync(OrderQueryBuilder builder);
    }
}
