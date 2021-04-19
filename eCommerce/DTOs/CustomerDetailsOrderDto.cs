using System.Text.Json.Serialization;

namespace eCommerce.DTOs
{
    public class CustomerDetailsOrderDto
    {

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

    }
}
