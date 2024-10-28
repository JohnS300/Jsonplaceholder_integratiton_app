using System;
using System.Threading.Tasks;

namespace CoreConsole
{
    public class DeleteHandler
    {
        private readonly ApiClient apiClient = new ApiClient();
        private const string Url = "https://jsonplaceholder.typicode.com/posts/1";

        public async Task ExecuteAsync()
        {
            Console.WriteLine("Executing DELETE request...");
            string response = await apiClient.DeleteAsync(Url);
            Console.WriteLine(response);
        }
    }
}
