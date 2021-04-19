using eCommerce.DTOs;
using eCommerce.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class CustomerTest
    {
        private readonly IConfiguration _configuration;
        private readonly CustomerService _customerService;
        public CustomerTest()
        {
            var myConfiguration = new Dictionary<string, string>
            {
                { "Customer:ApiUrl", "https://customer-details.azurewebsites.net/api/GetUserDetails"},
                { "Customer:ApiCode" , "uu2ToG/dcsg3DI8CGlpLro1PyLhZNUWHpdPv8VmWFLBaxM0fvUZvkA=="}
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();


            _configuration = configuration;
            _customerService = new CustomerService(_configuration);
        }

        [Fact]
        public void GetCustomer()
        {
            var email = "cat.owner@mmtdigital.co.uk";
            var customerDetailsDto = _customerService.GetCustomerDetails(email).Result;
            Assert.Equal("C34454", customerDetailsDto.CustomerId);
            Assert.Equal("Charlie", customerDetailsDto.FirstName);
            Assert.Equal("Cat", customerDetailsDto.LastName);
        }
    }
}
