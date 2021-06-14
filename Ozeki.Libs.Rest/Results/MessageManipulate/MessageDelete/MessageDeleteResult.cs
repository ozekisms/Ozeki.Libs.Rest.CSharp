using System;
using System.Collections.Generic;
using System.Text;

namespace Ozeki.Libs.Rest
{
    public class MessageDeleteResult
    {
        public Folder Folder;
        public string[] MessageIdsRemoveSucceeded;
        public string[] MessageIdsRemoveFailed;

        public int TotalCount { get => SuccessCount + FailedCount; }
        public int SuccessCount { get => MessageIdsRemoveSucceeded?.Length ?? 0; }
        public int FailedCount { get => MessageIdsRemoveFailed?.Length ?? 0; }

        public override string ToString()
        {
            return "Total: " + TotalCount + ". Success: " + SuccessCount + ". Failed: " + FailedCount + ".";
        }
    }
}
