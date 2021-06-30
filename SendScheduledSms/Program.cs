using Ozeki.Libs.Rest;
using System;

namespace SendScheduledSms
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

            var msg = new Message()
            {
                ToAddress = "+36201111111",
                Text = "Hello, World!",
                TimeToSend = DateTime.Parse("2021-06-11 13:25:00")
            };

            var api = new MessageApi(configuration);

            var result = api.Send(msg);

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
