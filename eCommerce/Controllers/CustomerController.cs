using eCommerce.DTOs;
using eCommerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly CustomerService _customerService;
        private readonly OrderService _orderService;
        private readonly IConfiguration _configuration;

        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
            _customerService = new CustomerService(_configuration);
            _orderService = new OrderService(_configuration);
        }

        [HttpPost]
        public async Task<IActionResult> GetCustomerLastOrder([FromBody] CustomerDto customerDto)
        {
            try
            {
                //get customerDetails from API
                var customerDetailsDto = await _customerService.GetCustomerDetails(customerDto.User);


                //match customer email and id
                if (customerDetailsDto.CustomerId != customerDto.CustomerId)
                    return BadRequest("CustomerId does not match.");

                //get orders
                var orderDto = await _orderService.GetOrder(customerDetailsDto.CustomerId);

                //get customer details
                var customerOrderDto = new CustomerOrderDto();
                customerOrderDto.Customer.FirstName = customerDetailsDto.FirstName;
                customerOrderDto.Customer.LastName = customerDetailsDto.LastName;

                if (orderDto != null)
                    orderDto.DeliveryAddress = customerDetailsDto.HouseNumber + " " + customerDetailsDto.Street + ", " + customerDetailsDto.Town + ", " + customerDetailsDto.Postcode;


                customerOrderDto.Order = orderDto;

                //return dto
                return Ok(customerOrderDto);

            }
            catch(Exception ex)
            {
                //500 - Internal Server Error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
