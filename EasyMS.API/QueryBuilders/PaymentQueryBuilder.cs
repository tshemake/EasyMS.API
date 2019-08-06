using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMS.API.QueryBuilders
{
    public class PaymentQueryBuilder : EasyMSQueryBuilder
    {
        public PaymentQueryBuilder()
        {
            OrganizationId = null;
        }

        public string OrganizationId { get; set; }

        protected override void AddArguments(IDictionary<string, string> queryArguments)
        {
            base.AddArguments(queryArguments);

            ApplyPrimitiveType(queryArguments, "organizationId", OrganizationId);
        }
    }
}
