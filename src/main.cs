using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace CoreConsole
{
    class Program
    {
        static void Main(string[] args){
            using(var client = new HttpClient()){
                var endpoint = new Uri("https://jsonplaceholder.typicode.com/posts");
                var newPost = new Post(){
                    Title = "Test Post",
                    Body = "Hello world!",
                    UserID = 44,
                };

                var newPostJson = JsonConvert.SerializeObject(newPost);
                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");

                var postresult = client.PostAsync(endpoint, payload).Result;
                var postresultjson= postresult.Content.ReadAsStringAsync().Result;

                Console.WriteLine(postresultjson);
            }
        }
    }
}