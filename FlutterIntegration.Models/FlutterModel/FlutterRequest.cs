using FlutterIntegration.Models.Domain;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FlutterIntegration.Models.FlutterModel
{
    public class FlutterRequest
    {
        [JsonProperty("tx_ref")]
        public string tx_ref { get; set; }
        [JsonProperty("amount")]
        public decimal amount { get; set; }
        [JsonProperty("currency")]
        public string currency { get; set; }
        [JsonProperty("redirect_url")]
        public string redirect_url { get; set; }
        [JsonProperty("meta")]
        public string meta { get; set; }
        [JsonProperty("customizations")]
        public string customizations { get; set; }
        [JsonProperty("subaccounts")]
        public string subaccounts { get; set; }
        [JsonProperty("payment_options")]
        public string payment_options { get; set; }
        [JsonProperty("customer")]
        public FlutterwaveCustomerDTO customer { get; set; }
    }

    public class FlutterwaveCustomerDTO
    {
        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
