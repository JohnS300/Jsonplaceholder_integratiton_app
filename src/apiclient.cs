using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoreConsole
{
    public class ApiClient : IDisposable
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<string> GetRequestAsync(string url)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostRequestAsync(string url, Post postData)
        {
            var json = JsonConvert.SerializeObject(postData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
