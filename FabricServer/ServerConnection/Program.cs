using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace ServerConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestPost();
            Console.Out.WriteLine("I am here press any key to send data to server!");
            System.Console.ReadLine();
            TestPost();

            Console.ReadLine();
        }

        public static async void TestPost()
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                   { "msg", "hello hahahaha" }
                };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("http://localhost:25331/api/message", content);

                var responseString = await response.Content.ReadAsStringAsync();

                
            }
        }
    }
}
