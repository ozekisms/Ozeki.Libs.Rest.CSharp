using Ozeki.Libs.Rest;
using System;

namespace SendMultipleSms
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

            var msg1 = new Message()
            {
                ToAddress = "+36201111111",
                Text = "Hello, World 1"
            };

            var msg2 = new Message()
            {
                ToAddress = "+362222222",
                Text = "Hello, World 2"
            };

            var msg3 = new Message()
            {
                ToAddress = "+363333333",
                Text = "Hello, World 3"
            };

            var messages = new Message[] { msg1, msg2, msg3 };

            var api = new MessageApi(configuration);

            var results = api.Send(messages);

            Console.WriteLine(results.ToString());
            Console.ReadKey();
        }
    }
}
