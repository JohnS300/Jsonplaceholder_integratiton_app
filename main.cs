using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace CoreConsole{
    public class Get{
        using(var client = new HttpClient()){
            var endpoint = new Uri ("https://jsonplaceholder.typicode.com/posts");
            var newPost = new Post(){
                Title = "Test Post",
                Body = "Hello World",
                UserId = 44,
            };
            var newPostJson=JsonConvert.SerializeObject(newPost);
            Console.WriteLine("newPost");
            Console.WriteLine(newPost);
            Console.WriteLine("newPostJson");
            Console.WriteLine(newPostJson);

        };


    }
}