using System;
using System.Threading.Tasks;

namespace CoreConsole
{
    public class PutHandler
    {
        private readonly ApiClient apiClient = new ApiClient();
        private const string Url = "https://jsonplaceholder.typicode.com/posts/1";

        public async Task ExecuteAsync()
        {
            Console.WriteLine("Executing PUT request...");
            var updatedPost = new Post { Title = "Updated Post", Body = "Hello Universe", UserId = 1 };
            string response = await apiClient.PutAsync(Url, updatedPost);
            Console.WriteLine(response);
        }
    }
}
