using Ozeki.Libs.Rest;
using System;

namespace ReceiveSms
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new Configuration()
            {
                Username = "http_user",
                Password = "qwe123",
                ApiUrl = "http://127.0.0.1:9509/api"
            };

            var api = new MessageApi(configuration);

            var messages = api.DownloadIncoming();

            Console.WriteLine(messages.Length + " messages downloaded from inbox.");

            foreach (var message in messages)
            {
                Console.WriteLine(message);
            };

            Console.ReadKey();
        }
    }
}
