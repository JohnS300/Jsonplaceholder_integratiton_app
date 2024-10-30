using System;
using System.Threading.Tasks;

namespace CoreConsole
{
    public class GetHandler
    {
        private readonly ApiClient apiClient = new ApiClient();
        private const string Url = "https://jsonplaceholder.typicode.com/posts";

        public async Task ExecuteAsync()
        {
            Console.WriteLine("Executing GET request...");
            string response = await apiClient.GetAsync(Url);
            Console.WriteLine(response);
        }
    }
}
