using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace CoreConsole
{
    class Program
    {
        static void Main(string[] args){
            using(var client = new HttpClient()){
                var endpoint = new Uri("https://jsonplaceholder.typicode.com/posts");
                var result = client.GetAsync(endpoint).Result;
                var jsonresult = result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(jsonresult);
            }
        }
    }
}