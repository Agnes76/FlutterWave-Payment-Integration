using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FlutterIntegration.Logic
{
    public class APIClient
    {
        private readonly HttpClient _httpClient;
        public APIClient(HttpClient client)
        {
            _httpClient = client;
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpResponseMessage> PostAsync(string baseUrl, string relativeUrl, object values, string token = null)
        {
            _httpClient.BaseAddress = new Uri(baseUrl);
            // _httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            }

            var json = JsonConvert.SerializeObject(values);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post,  relativeUrl);
            request.Content = content;

            var response = await _httpClient.SendAsync(request);
            return response;
        }

        //public async Task<HttpResponseMessage> GetAsync(string baseUrl, string relativeUrl)
        //{
        //    _httpClient.BaseAddress = new Uri(baseUrl);

        //    var request = new HttpRequestMessage(HttpMethod.Get, relativeUrl);

        //    var response = await _httpClient.SendAsync(request);
        //    return response;
        //}

        public async Task<HttpResponseMessage> GetAsync(string baseUrl, string relativeUrl, string token = null)
        {
            _httpClient.BaseAddress = new Uri(baseUrl);

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            }

            var request = new HttpRequestMessage(HttpMethod.Get, relativeUrl);

            var response = await _httpClient.SendAsync(request);
            return response;
        }

    }
}
