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

        static MessageSendResults ParseSendMessageResults(string responseBody)
        {
            var results = new MessageSendResults();
            using (var jsonDocument = JsonDocument.Parse(responseBody))
            {
                var rootElement = jsonDocument.RootElement;
                ThrowException_IfRequestFailed(rootElement);
                ThrowException_IfRequestError(rootElement);
                AppendResponse_SendMessage(results, rootElement);
            }
            return results;
        }

        static void AppendResponse_SendMessage(MessageSendResults results, JsonElement rootElement)
        {
            var dataElement = rootElement.GetProperty("data");
            AppendData_SendMessage(results, dataElement);
        }

        static void AppendData_SendMessage(MessageSendResults results, JsonElement dataElement)
        {
            results.TotalCount = dataElement.GetProperty("total_count").GetInt32();
            results.SuccessCount = dataElement.GetProperty("success_count").GetInt32();
            results.FailedCount = dataElement.GetProperty("failed_count").GetInt32();

            var messagesElement = dataElement.GetProperty("messages");
            var messages = new List<MessageSendResult>(messagesElement.GetArrayLength());
            var messagesArray = messagesElement.EnumerateArray();
            foreach (var message in messagesArray)
                messages.Add(ParseMessageSendResult(message));
            results.Results = messages.ToArray();
        }

        static MessageSendResult ParseMessageSendResult(JsonElement messageElement)
        {
            var statusMessage = messageElement.GetProperty("status").GetString();
            var msgResult = new MessageSendResult();
            msgResult.Message = ParseMessage(messageElement);
            msgResult.StatusMessage = statusMessage;
            msgResult.Status = (statusMessage.ToUpperInvariant() == "SUCCESS") ? DeliveryStatus.Success : DeliveryStatus.Failed;
            return msgResult;
        }
    }
}
