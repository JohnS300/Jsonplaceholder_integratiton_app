using System;
using System.Threading.Tasks;

namespace CoreConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var apiClient = new ApiClient())
            {
                Console.WriteLine("Do you want a GET, POST, or BOTH request?");
                var choice = Console.ReadLine();

                if (string.IsNullOrEmpty(choice))
                {
                    choice = "BOTH"; // Default to BOTH if no input is provided
                }

                switch (choice.ToUpper())
                {
                    case "GET":
                        await PerformGetRequest(apiClient);
                        break;

                    case "POST":
                        await PerformPostRequest(apiClient);
                        break;

                    case "BOTH":
                        await PerformGetRequest(apiClient);
                        await PerformPostRequest(apiClient);
                        break;

                    default:
                        Console.WriteLine("Nice job");
                        break;
                }
            }
        }

        static async Task PerformGetRequest(ApiClient apiClient)
        {
            var endpointGet = "https://jsonplaceholder.typicode.com/posts";
            var getResponse = await apiClient.GetRequestAsync(endpointGet);
            Console.WriteLine("Get Response: ");
            Console.WriteLine(getResponse);
        }

        static async Task PerformPostRequest(ApiClient apiClient)
        {
            var endpointPost = "https://jsonplaceholder.typicode.com/posts";
            var newPost = new Post
            {
                Title = "Test Post",
                Body = "Hello world!",
                UserID = 44
            };
            var postResponse = await apiClient.PostRequestAsync(endpointPost, newPost);
            Console.WriteLine("Post Response: ");
            Console.WriteLine(postResponse);
        }
    }
}
