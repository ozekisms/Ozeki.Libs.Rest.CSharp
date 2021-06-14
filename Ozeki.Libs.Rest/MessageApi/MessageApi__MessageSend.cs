using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ozeki.Libs.Rest
{
    partial class MessageApi
    {
        //**********************************************
        // Send
        //**********************************************

        public MessageSendResult Send(Message message)
        {
            var results = Send(new Message[] { message });
            return results.Results[0];
        }

        public MessageSendResults Send(IEnumerable<Message> messages)
        {
            var authHeader = CreateAuthorizationHeader(_configuration.Username, _configuration.Password);
            var requestBody = CreateRequestBody_SendMessage(messages.ToArray());
            var jsonResponse = DoRequestPost(getUrl_SendMessage(), authHeader, "application/json", requestBody);
            var results = ParseSendMessageResults(jsonResponse);
            return results;
        }

        string getUrl_SendMessage()
        {
            var apiUrl = _configuration.ApiUrl.TrimEnd('?');
            return apiUrl + "?action=sendmsg";
        }
    }
}
