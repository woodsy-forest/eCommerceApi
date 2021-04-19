using System.Text.Json.Serialization;

namespace eCommerce.DTOs
{
    public class CustomerDto
    {
        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("customerId")]
        public string CustomerId { get; set; }
    }
}
