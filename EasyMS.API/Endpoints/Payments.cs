using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyMS.API.Entities;
using EasyMS.API.QueryBuilders;
using EasyMS.API.Web;

namespace EasyMS.API.Endpoints
{
    internal class Payments : Endpoint, IPayments
    {
        private const string CreatePaymentPath = "api/payments/createPayment/";
        private const string CreateGroupPaymentPath = "api/payments/createGroupPayment/";
        private const string GetPaymentsOfOrderPath = "api/payments/order/{0}";

        public Payments(IEasyMSAPIGateway gateway)
            : base(gateway)
        {
        }

        /// <summary>
        /// Провести оплату за комнату в заказе
        /// </summary>
        public async Task CreatePaymentAsync(Payment payment)
        {
            payment.ValidateCreate();

            var builder = new PaymentQueryBuilder { Path = CreatePaymentPath };
            await Gateway.SendPostRequestAsync(builder.BuildUri(), payment);
        }

        /// <summary>
        /// Провести оплату заказ целиком
        /// </summary>
        public async Task CreateGroupPaymentAsync(GroupPayment groupPayment)
        {
            groupPayment.ValidateCreate();

            var builder = new PaymentQueryBuilder { Path = CreateGroupPaymentPath };
            await Gateway.SendPostRequestAsync(builder.BuildUri(), groupPayment);
        }

        /// <summary>
        /// Получить все платежи по заказу
        /// </summary>
        /// <param name="orderId">идентификатор заказа</param>
        /// <param name="organizationId">идентификатор организации</param>
        public async Task<EasyMSList<Payment>> GetPaymentsOfOrderAsync(string orderId, string organizationId)
        {
            var builder = new PaymentQueryBuilder { Path = string.Format(GetPaymentsOfOrderPath, orderId), OrganizationId = organizationId };

            return await GetPage<Payment>(builder.BuildUri(), "paymentResponses");
        }
    }
}
