using Ozeki.Libs.Rest;
using System;

namespace DeleteSms
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
                // You have must replace the ID with the ID of the message what you want to delete
                ID = "a85d6e16-f888-4306-bd2a-8f8a119d8abf"
            };

            var api = new MessageApi(configuration);

            // If you want to delete a message from the Sent folder, you should replace the Inbox attribute with the Sent attribute
            var result = api.Delete(Folder.Inbox, msg);

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
