# C# sms library to send sms with http/rest/json

This C# sms library enables you to **send sms** from C# with http requests. 
You may also use it to **receive sms** from C# with http downloads. The library
uses HTTP Post requests and JSON encoded content to send the text
messages to the mobile network1. It connects to the HTTP SMS API of 
[Ozeki SMS gateway](https://ozeki-sms-gateway.com). This repository is better
for implementing SMS solutions then other alternatives, because it allows
you to use the same code to send SMS through an Android mobile, through
a high performance IP SMS connection or a GSM modem or modem pool. This
library gives you SMS service provider independence.

## What is Ozeki SMS Gateway 

Ozeki SMS Gateway is a powerful SMS Gateway software you can download and install 
on your Windows or Linux computer or to your Android mobile phone. It provides
an HTTP SMS API, that allows you to connect to it from local or remote
programs. The reason why companies use Ozeki SMS Gateway as their first point
of access to the mobile network, is because it provides service provider independence.
When you use Ozeki, the SMS contact lists and sms data is safe, because Ozeki is installed in
their own computer (physical or virutal), and Ozeki provides direct access
to the mobile network through wireless connections.

Download: [Ozeki SMS Gateway download page](https://ozeki-sms-gateway.com/p_727-download-sms-gateway.html)

Tutorial: [C# send sms sample and tutorial](https://ozeki-sms-gateway.com/p_831-c-sharp-send-sms-with-the-http-rest-api-code-sample.html)

## How to send sms from C#: 

**To send sms from C#**
1. [Download Ozeki SMS Gateway](https://ozeki-sms-gateway.com/p_727-download-sms-gateway.html)
2. [Connect Ozeki SMS Gateway to the mobile network](https://ozeki-sms-gateway.com/p_70-mobile-network-connections.html)
3. [Create an HTTP SMS API user](https://ozeki-sms-gateway.com/p_2102-create-an-http-sms-api-user-account.html)
4. Checkout the Github send SMS from C# repository
5. Open the Github SMS send example in Visual Studio
6. Compile the Send SMS console project
7. Check the logs in Ozeki SMS Gateway

## How to use the code

To use the code you need to import the Ozeki.Libs.Rest sms library. This
sms library is also included in this repositry with it's full source code.
After the library is imported with the using statiment, you need to define
the username, password and the api url. You can create the username and 
password when you install an HTTP API user in your Ozeki SMS Gateway system.

The URL is the default http api URL to connect to your SMS gateway. If you
run the SMS gateway on the same computer where your C# code is runing, you
can use 127.0.0.1 as the ip address. You need to change this if you install
the sms gateway on a different computer (or mobile phone).


```
using Ozeki.Libs.Rest;
using System;

namespace SendSms
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
                Text = "Hello, World!"
            };

            var api = new MessageApi(configuration);

            var result = api.Send(msg);

            Console.WriteLine(result.ToString());
            Console.ReadKey();
        }
    }
}
```

## Manual / API reference

To get a better understanding of the above **SMS code sample**, it is a good
idea to visit the webpage that explains this code in a more detailed way.
You can find videos, explanations and downloadable content on this URL.

Link: [How to send sms from C#](https://ozeki-sms-gateway.com/p_831-c-sharp-send-sms-with-the-http-rest-api-code-sample.html)


## How to send sms through your Android mobile phone

If you wish to [send SMS through your Android mobile phone from C#](https://android-sms-gateway.com/), 
you need to [install Ozeki SMS Gateway on your Android](https://ozeki-sms-gateway.com/p_2847-how-to-install-ozeki-sms-gateway-on-android.html) 
mobile phone. It is recommended to use an Android mobile phone with a minimum of 
4GB RAM and a quad core CPU. Most devices today meet these specs. The advantage
of using your mobile, is that it is quick to setup and it often allows you
to [send sms free of charge](https://android-sms-gateway.com/p_246-how-to-send-sms-free-of-charge.html).

[Android SMS Gateway](https://android-sms-gateway.com)

## Get started now

Don't waste any time, download the repository now, and send your first SMS!
