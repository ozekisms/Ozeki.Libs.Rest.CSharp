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

        static MessageManipulateResult ParseManipulateMessageResult(string responseBody)
        {
            var result = new MessageManipulateResult();
            using (var jsonDocument = JsonDocument.Parse(responseBody))
            {
                var rootElement = jsonDocument.RootElement;
                ThrowException_IfRequestFailed(rootElement);
                ThrowException_IfRequestError(rootElement);
                AppendResponse_ManipulateMessage(result, rootElement);
            }
            return result;
        }

        static void AppendResponse_ManipulateMessage(MessageManipulateResult result, JsonElement rootElement)
        {
            var dataElement = rootElement.GetProperty("data");
            AppendData_ManipulateMessage(result, dataElement);
        }

        static void AppendData_ManipulateMessage(MessageManipulateResult result, JsonElement dataElement)
        {
            result.Folder = dataElement.GetProperty("folder").GetString();
            var messageIdsElement = dataElement.GetProperty("message_ids");
            AppendData_MessageIds(result, messageIdsElement);
        }

        static void AppendData_MessageIds(MessageManipulateResult result, JsonElement messageIdsElement)
        {
            var messageIds = new List<string>(messageIdsElement.GetArrayLength());
            var messageIdArray = messageIdsElement.EnumerateArray();
            foreach (var messageIdElement in messageIdArray)
                messageIds.Add(messageIdElement.GetString());
            result.MessageIds = messageIds.ToArray();
        }
    }
}
