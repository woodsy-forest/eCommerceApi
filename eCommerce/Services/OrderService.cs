using eCommerce.DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Services
{
    public class OrderService
    {
        private readonly IConfiguration _configuration;
        public readonly string _connectionString;
        public OrderService(IConfiguration configuration)
        {
            _configuration = configuration;

            _connectionString = _configuration["ConnectionStrings:eCommerce"];

        }

        public async Task<OrderDto> GetOrder(string customerId)
        {
             
            var orderDto = new OrderDto();

            string sql = $@"

                SELECT 
	                o.ORDERID As ORDERID, 
	                ORDERDATE,
                    DELIVERYEXPECTED,
                    CONTAINSGIFT,
	                PRODUCTNAME,
	                QUANTITY,
	                PRICE
                FROM 
	                (SELECT TOP 1 * 
	                FROM ORDERS 
	                WHERE CUSTOMERID = @CustomerId 
	                ORDER BY ORDERDATE DESC) o
                INNER JOIN ORDERITEMS  oi
	                ON o.ORDERID = oi.ORDERID
                INNER JOIN PRODUCTS p
	                ON oi.PRODUCTID = p.PRODUCTID

            ";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@CustomerId", SqlDbType.NVarChar);
                    cmd.Parameters["@CustomerId"].Value = customerId;

                    conn.Open();
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            orderDto.OrderDate = Convert.ToDateTime(dr["ORDERDATE"]);
                            orderDto.DeliveryExpected = Convert.ToDateTime(dr["DELIVERYEXPECTED"]);
                            orderDto.OrderNumber = Convert.ToInt32(dr["ORDERID"]);
                            var productDto = new ProductDto();
                            if (!Convert.ToBoolean(dr["CONTAINSGIFT"]))
                                productDto.Product = dr["PRODUCTNAME"].ToString();
                            else
                                productDto.Product = "Gift";
                            productDto.Quantity = Convert.ToInt32(dr["QUANTITY"]);
                            productDto.PriceEach = Convert.ToDecimal(dr["PRICE"]);
                            orderDto.OrderItems.Add(productDto);
                        }
                    }

                }
            }

            if (orderDto.OrderItems.Count == 0)
                orderDto = null;

            return await Task.Run(() => orderDto);
        }
    }
}
