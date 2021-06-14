using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ozeki.Libs.Rest
{
    partial class MessageApi
    {
        //**********************************************
        // Manipulate / Delete
        //**********************************************

        public bool Delete(Folder folder, Message message)
        {
            return Delete(folder, message.ID);
        }

        public MessageDeleteResult Delete(Folder folder, IEnumerable<Message> messages)
        {
            var messageIds = messages.Select(msg => msg.ID);
            return Delete(folder, messageIds);
        }

        public bool Delete(Folder folder, string messageId)
        {
            var result = Delete(folder, new string[] { messageId });
            if (result.FailedCount > 0)
                return false;
            return true;
        }

        public MessageDeleteResult Delete(Folder folder, IEnumerable<string> messageIds)
        {
            var messageIdArray = messageIds.ToArray();
            var manipulateResult = manipulate(folder, messageIdArray, "deletemsg");
            evaluateManipulateResult(messageIdArray, manipulateResult, out var idsRemoveSucceeded, out var idsRemoveFailed);

            var result = new MessageDeleteResult();
            result.Folder = GetFolder(manipulateResult.Folder);
            result.MessageIdsRemoveSucceeded = idsRemoveSucceeded;
            result.MessageIdsRemoveFailed = idsRemoveFailed;
            return result;
        }
    }
}
