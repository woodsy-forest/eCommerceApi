using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace eCommerce.DTOs
{
    public class OrderDto
    {
        public OrderDto()
        {
            OrderItems = new List<ProductDto>();
        }

        [JsonPropertyName("orderNumber")]
        public int OrderNumber { get; set; }

        [JsonPropertyName("orderDate")]
        public DateTime OrderDate { get; set; }

        [JsonPropertyName("deliveryExpected")]
        public DateTime DeliveryExpected { get; set; }

        [JsonPropertyName("deliveryAddress")]
        public string DeliveryAddress { get; set; }

        [JsonPropertyName("orderItems")]
        public List<ProductDto> OrderItems { get; set; }
    }
}
