using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyMS.API.QueryBuilders
{
    public abstract class EasyMSQueryBuilder
    {
        private const string Host = "https://my.easyms.co/api/";

        protected EasyMSQueryBuilder()
        {
            Path = "?";
        }

        internal string Path { get; set; }

        protected virtual void AddArguments(IDictionary<string, string> queryArguments)
        {
        }

        protected static void ApplyList<T>(IDictionary<string, string> query, string key, IList<T> filters)
        {
            ApplyList(query, key, filters, t => t.ToString());
        }

        protected static void ApplyList<T>(IDictionary<string, string> query, string key, IList<T> filters, Func<T, string> selector)
        {
            if (!filters.Any())
            {
                return;
            }

            AddEscapedValue(query, key, string.Join(",", filters.Select(selector)));
        }

        protected static void ApplyNullableDateTimeType(IDictionary<string, string> query, string key, DateTime? filter, Func<DateTime, string> selector)
        {
            if (!filter.HasValue)
            {
                return;
            }

            AddEscapedValue(query, key, selector(filter.Value));
        }

        protected static void ApplyNullableEnumType(IDictionary<string, string> query, string key, Enum filter, Enum defaulValue, Func<Enum, string> selector)
        {
            if (filter.Equals(defaulValue))
            {
                return;
            }

            AddEscapedValue(query, key, selector(filter));
        }

        protected static void ApplyNullablePrimitiveType<T>(IDictionary<string, string> query, string key, T? filter, Func<T, string> selector) where T : struct
        {
            if (filter.HasValue)
            {
                AddEscapedValue(query, key, selector(filter.Value));
            }
        }

        protected static void ApplyPrimitiveType(IDictionary<string, string> query, string key, string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return;
            }

            AddEscapedValue(query, key, filter);
        }

        private string BuildQuery()
        {
            var queryArguments = new Dictionary<string, string>();
            AddArguments(queryArguments);

            return string.Join("&", queryArguments.Select(x => $"{x.Key}={x.Value}"));
        }

        internal Uri BuildUri()
        {
            var uriString = Host + Path + BuildQuery();


            return new Uri(uriString);
        }

        private static void AddEscapedValue(IDictionary<string, string> query, string key, string value)
        {
            query.Add(key, Uri.EscapeDataString(value));
        }
    }
}
