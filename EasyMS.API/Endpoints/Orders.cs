using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyMS.API.Entities;
using EasyMS.API.QueryBuilders;
using EasyMS.API.Web;

namespace EasyMS.API.Endpoints
{
    internal class Orders : Endpoint, IOrders
    {
        private const string OrderPath = "api/orders/{0}";
        private const string OrdersPath = "api/orders";

        public Orders(IEasyMSAPIGateway gateway) 
            : base(gateway)
        {
        }

        /// <summary>
        /// Получение заказов
        /// </summary>
        public async Task<EasyMSList<Order>> GetAllAsync(OrderQueryBuilder builder)
        {
            builder.Path = OrdersPath;
            builder.ValidateGet();

            return await Gateway.SendGetRequestAsync<EasyMSList<Order>>(builder.BuildUri());
        }

        /// <summary>
        /// Получение заказа по его идентификатору
        /// </summary>
        /// <param name="orderId">идентификатор заказа</param>
        /// <param name="organizationId">идентификатор организации</param>
        /// <returns><see cref="Order"/></returns>
        public async Task<Order> GetAsync(string orderId, string organizationId)
        {
            var builder = new OrderQueryBuilder { Path = string.Format(OrderPath, orderId), OrganizationId = organizationId };
            builder.ValidateGet();

            return await Gateway.SendGetRequestAsync<Order>(builder.BuildUri());
        }
    }
}
