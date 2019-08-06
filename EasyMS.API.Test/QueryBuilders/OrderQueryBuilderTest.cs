using System;
using System.Collections.Generic;
using System.Text;
using EasyMS.API.QueryBuilders;
using Xunit;

namespace EasyMS.API.Test.QueryBuilders
{
    public class OrderQueryBuilderTest
    {
        [Fact]
        public void Test_No_Parameters()
        {
            var builder = new OrderQueryBuilder("1");

            var query = builder.BuildUri();

            Assert.Equal("https://my.easyms.co/api/?organizationId=1", query.ToString());
        }
    }
}
