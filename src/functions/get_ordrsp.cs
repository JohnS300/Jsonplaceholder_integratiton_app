using System;
using System.Threading.Tasks;

namespace CoreConsole
{
    public class PostHandler
    {
        private readonly ApiClient apiClient = new ApiClient();
        private const string Url = "https://jsonplaceholder.typicode.com/posts";

        public async Task ExecuteAsync()
        {
            Console.WriteLine("Executing POST request...");
            var newPost = new Post { Title = "Test Post", Body = "Hello World", UserId = 1 };
            string response = await apiClient.PostAsync(Url, newPost);
            Console.WriteLine(response);
        }
    }
}
