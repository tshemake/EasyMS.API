using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyMS.API.Entities;

namespace EasyMS.API.Endpoints
{
    public interface IPayments
    {
        Task CreatePaymentAsync(Payment payment);
    }
}
