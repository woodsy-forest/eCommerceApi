using System.Text.Json.Serialization;

namespace eCommerce.DTOs
{
    public class ProductDto
    {
        [JsonPropertyName("product")]
        public string Product { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("priceEach")]
        public decimal PriceEach { get; set; }
    }
}
