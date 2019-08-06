using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using EasyMS.API.Exceptions;
using EasyMS.API.Extensions;
using EasyMS.API.Utils;

[assembly: InternalsVisibleTo("EasyMS.API.Test")]
namespace EasyMS.API.QueryBuilders
{
    public class OrderQueryBuilder : EasyMSQueryBuilder
    {
        public OrderQueryBuilder(string organizationId)
            : this()
        {
            OrganizationId = organizationId;
        }

        public OrderQueryBuilder()
        {
            ArrivalFrom = null;
            ArrivalTo = null;
            DepartureFrom = null;
            DepartureTo = null;
            StartTime = null;
            EndTime = null;
        }

        public string OrganizationId { get; set; }

        public DateTime? ArrivalFrom { get; set; }

        public DateTime? ArrivalTo { get; set; }

        public DateTime? DepartureFrom { get; set; }

        public DateTime? DepartureTo { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        protected override void AddArguments(IDictionary<string, string> queryArguments)
        {
            base.AddArguments(queryArguments);

            ApplyPrimitiveType(queryArguments, "organizationId", OrganizationId);
            
            ApplyNullableDateTimeType(queryArguments, "arrivalFrom", ArrivalFrom, s => s.ToUnixEpoch().ToString());
            ApplyNullableDateTimeType(queryArguments, "arrivalTo", ArrivalTo, s => s.ToUnixEpoch().ToString());
            ApplyNullableDateTimeType(queryArguments, "departureFrom", DepartureFrom, s => s.ToUnixEpoch().ToString());
            ApplyNullableDateTimeType(queryArguments, "departureTo", DepartureTo, s => s.ToUnixEpoch().ToString());
            ApplyNullableDateTimeType(queryArguments, "startTime", StartTime, s => s.ToUnixEpoch().ToString());
            ApplyNullableDateTimeType(queryArguments, "endTime", EndTime, s => s.ToUnixEpoch().ToString());
        }

        public void ValidateGet()
        {
            var messages = new ValidationMessages();

            if (string.IsNullOrEmpty(OrganizationId))
            {
                messages.Add("OrganizationId пропущен. Используйте OrganizationId свойство чтобы установить organizationId.");
            }

            if (messages.HasErrors)
            {
                throw new EasyMSValidationException(messages);
            }
        }
    }
}
