using System.Text.Json.Serialization;

namespace eCommerce.DTOs
{
    public class CustomerDetailsDto
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("customerId")]
        public string CustomerId { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("houseNumber")]
        public string HouseNumber { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("town")]
        public string Town { get; set; }

        [JsonPropertyName("postcode")]
        public string Postcode { get; set; }

    }
}
