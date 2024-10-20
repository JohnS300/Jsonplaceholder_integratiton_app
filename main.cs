using System;
/*using Systems.Collections.Generic;
using Systems.Linq;
using Systems.Web;
using Systems.Web.UI;
using Systems.Web.UI.WebControls;*/

namespace CoreConsole{
    class JsonGet{
        static void Main(string[] args){
            using(var client = new HttpClient()){
                var endpoint = new Uri ("https://jsonplaceholder.typicode.com/posts");
                //one line command to get the result back in json format
                //var results = client.GetAsync(endpoint).Result.Content.ReadAsStringAsync().Result;
                //but spliting it make it clearer to understand
                var results = client.GetAsync(endpoint).Result;
                var json = results.Content.ReadAsStringAsync().Result;
                Console.WriteLine(json);
            };
        }

    }
}