using eCommerce.DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace eCommerce.Services
{
    public class CustomerService
    {
        private readonly IConfiguration _configuration;
        static readonly HttpClient client = new HttpClient();

        public CustomerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<CustomerDetailsDto> GetCustomerDetails(string email)
        {
            var url = _configuration["Customer:ApiUrl"] + "?code=" + _configuration["Customer:ApiCode"] + "&email=" + email;
            var response = await client.GetAsync(url);
            var customerDetailsDto = new CustomerDetailsDto();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                customerDetailsDto = JsonConvert.DeserializeObject<CustomerDetailsDto>(responseBody);

            }

            return customerDetailsDto;
        }
    }
}
