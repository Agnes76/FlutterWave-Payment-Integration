using FlutterIntegration.Models;
using FlutterIntegration.Models.FlutterModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlutterIntegration.Logic
{
    public class FlutterClient
    {
        private readonly APIClient _apiClient;
        private readonly IConfiguration _configuration;
        private readonly IOptions<FlutterVerify> _options;
        public FlutterClient(APIClient client, IConfiguration configuration, IOptions<FlutterVerify> options)
        {
            _configuration = configuration;
            _apiClient = client;
            _options = options;
            //_verify = verify;
        }

        public async Task<string> InitiatePaymentAsync(FlutterRequest request)
        {

            var FOBaseUrl = _configuration.GetSection("FlutterOptions:BaseUrl").Value;
            var FOPaymentLink = _configuration.GetSection("FlutterOptions:PaymentLink").Value;
            var FOBaseToken = _configuration.GetSection("FlutterOptions:Token").Value;
            var response = await _apiClient.PostAsync(FOBaseUrl, FOPaymentLink, request, FOBaseToken);


          //  response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var flutterResJson = await response.Content.ReadAsStringAsync();
                
                var flutterRes = JsonConvert.DeserializeObject<FlutterwaveResponseDTO<FlutterwaveResponseDataDTO>>(flutterResJson);

                return flutterRes.Data.link;

            }
            return null;

          
        }

        public async Task<FlutterwaveResponseDTO<FlutterwaveVerifyResponseDataDTO>> VerifyPaymentAsync(string transactionRef)
        {
            var response = await _apiClient.GetAsync(_options.Value.BaseUrl, _options.Value.TransLink + $"?tx_ref={transactionRef}", _options.Value.Token);

            var flutterResJson = await response.Content.ReadAsStringAsync();
            var flutterRes = JsonConvert.DeserializeObject<FlutterwaveVerifyResponseDataDTO>(flutterResJson);

            return new FlutterwaveResponseDTO<FlutterwaveVerifyResponseDataDTO>() 
            { 
                Data = flutterRes
            }; 
        }
    }
}
