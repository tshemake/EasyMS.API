using System;
using System.Collections.Generic;
using System.Text;
using EasyMS.API.Utils;
using Xunit;

namespace EasyMS.API.Test.Utils
{
    public class ValidationMessagesTest
    {
        [Fact]
        public void Test_Add_String()
        {
            var errors = new ValidationMessages();
            errors.Add("error!");

            Assert.Equal("error!", errors.ToString());
        }

        [Fact]
        public void Test_Add_StringBuilder()
        {
            var errors = new ValidationMessages();
            errors.Add(new StringBuilder("error!"));

            Assert.Equal("error!", errors.ToString());
        }

        [Fact]
        public void Test_HasErrors()
        {
            var errors = new ValidationMessages();
            errors.Add("error!");

            Assert.True(errors.HasErrors);
        }
    }
}
