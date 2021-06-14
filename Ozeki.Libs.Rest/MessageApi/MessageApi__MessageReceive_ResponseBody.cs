using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Ozeki.Libs.Rest
{
    partial class MessageApi
    {
        //**********************************************
        // Response body
        //**********************************************

        static MessageReceiveResult ParseMessageReceiveResult(string responseBody)
        {
            var result = new MessageReceiveResult();
            using (var jsonDocument = JsonDocument.Parse(responseBody))
            {
                var rootElement = jsonDocument.RootElement;
                ThrowException_IfRequestFailed(rootElement);
                ThrowException_IfRequestError(rootElement);
                AppendResponse_ReceiveMessage(result, rootElement);
            }
            return result;
        }

        static void AppendResponse_ReceiveMessage(MessageReceiveResult result, JsonElement rootElement)
        {
            var dataElement = rootElement.GetProperty("data");
            AppendData_ReceiveMessage(result, dataElement);
        }

        static void AppendData_ReceiveMessage(MessageReceiveResult result, JsonElement dataElement)
        {
            var folderName = dataElement.GetProperty("folder").GetString();
            result.Folder = GetFolder(folderName);
            result.Limit = dataElement.GetProperty("limit").GetString();
            var dataDataElement = dataElement.GetProperty("data");
            var messages = new List<Message>(dataDataElement.GetArrayLength());
            var messagesArray = dataDataElement.EnumerateArray();
            foreach (var messageElement in messagesArray)
                messages.Add(ParseMessage(messageElement));
            result.Messages = messages.ToArray();
        }
    }
}
