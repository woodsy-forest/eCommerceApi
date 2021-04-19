using eCommerce.DTOs;
using eCommerce.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class OrderTest
    {
        private readonly IConfiguration _configuration;
        private readonly OrderService _orderService;
        public OrderTest()
        {
            var myConfiguration = new Dictionary<string, string>
            {
                { "ConnectionStrings:eCommerce", "Server=tcp:mmt-sse-test.database.windows.net,1433;Initial Catalog=SSE_Test;Persist Security Info=False;User ID=mmt-sse-test;Password=database-user-01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"}            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();


            _configuration = configuration;
            _orderService = new OrderService(_configuration);
        }

        [Fact]
        public void GetOrder()
        {
            var customerId = "C34454";
            var orderDto = _orderService.GetOrder(customerId).Result;
            Assert.Equal(4, orderDto.OrderNumber);
            Assert.Equal(2, orderDto.OrderItems.Count);            
        }

    }
}
