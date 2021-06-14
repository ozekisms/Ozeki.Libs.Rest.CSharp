using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ozeki.Libs.Rest
{
    partial class MessageApi
    {
        //**********************************************
        // Manipulate / Mark
        //**********************************************

        public bool Mark(Folder folder, Message message)
        {
            return Mark(folder, message.ID);
        }

        public MessageMarkResult Mark(Folder folder, IEnumerable<Message> messages)
        {
            var messageIds = messages.Select(msg => msg.ID).ToArray();
            return Mark(folder, messageIds);
        }

        public bool Mark(Folder folder, string messageId)
        {
            var result = Mark(folder, new string[] { messageId });
            if (result.FailedCount > 0)
                return false;
            return true;
        }

        public MessageMarkResult Mark(Folder folder, IEnumerable<string> messageIds)
        {
            var messageIdArray = messageIds.ToArray();
            var manipulateResult = manipulate(folder, messageIdArray, "markmsg");
            evaluateManipulateResult(messageIdArray, manipulateResult, out var idsMarkSucceeded, out var idsMarkFailed);

            var result = new MessageMarkResult();
            result.Folder = GetFolder(manipulateResult.Folder);
            result.MessageIdsMarkSucceeded = idsMarkSucceeded;
            result.MessageIdsMarkFailed = idsMarkFailed;
            return result;
        }
    }
}
