using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ozeki.Libs.Rest
{
    partial class MessageApi
    {
        //**********************************************
        // Manipulate
        //**********************************************

        MessageManipulateResult manipulate(Folder folder, string[] messageIds, string action)
        {
            var authHeader = CreateAuthorizationHeader(_configuration.Username, _configuration.Password);
            var requestBody = CreateRequestBody_ManipulateMessage(GetFolderName(folder), messageIds);
            var jsonResponse = DoRequestPost(getUrl(action), authHeader, "application/json", requestBody);
            var result = ParseManipulateMessageResult(jsonResponse);
            return result;
        }

        //**********************************************
        // Evaluate result
        //**********************************************

        void evaluateManipulateResult(string[] messageIds, MessageManipulateResult manipulateResult, out string[] idsManipulateSucceeded, out string[] idsManipulateFailed)
        {
            var idsManipulatedLower = manipulateResult.MessageIds.Select(msgId => msgId.ToLowerInvariant()).ToArray();
            var idListManipulateSucceeded = new List<string>(idsManipulatedLower.Length);
            var idListManipulateFailed = new List<string>(messageIds.Length - idsManipulatedLower.Length);
            foreach (var messageId in messageIds)
            {
                var messageIdLower = messageId.ToLowerInvariant();
                if (idsManipulatedLower.Contains(messageIdLower))
                    idListManipulateSucceeded.Add(messageId);
                else
                    idListManipulateFailed.Add(messageId);
            }

            idsManipulateSucceeded = idListManipulateSucceeded.ToArray();
            idsManipulateFailed = idListManipulateFailed.ToArray();
        }

        //**********************************************
        // Support functions
        //**********************************************

        string getUrl(string action)
        {
            var apiUrl = _configuration.ApiUrl.TrimEnd('?');
            return apiUrl + "?action=" + action;
        }
    }
}
