using System;

namespace CoreConsole{
    class ApiClient{
        public HttpClient client = new HttpClient();

        public async Task<string> GetRequestAsync(string url){
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        
    }
}