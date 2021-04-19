using System.Text.Json.Serialization;

namespace eCommerce.DTOs
{

    public class CustomerOrderDto
    {
        public CustomerOrderDto()
        {
            Customer = new CustomerDetailsOrderDto();
            Order = new OrderDto();
        }

        [JsonPropertyName("customer")]
        public CustomerDetailsOrderDto Customer { get; set; }

        [JsonPropertyName("order")]
        public OrderDto Order { get; set; }
    }
}
