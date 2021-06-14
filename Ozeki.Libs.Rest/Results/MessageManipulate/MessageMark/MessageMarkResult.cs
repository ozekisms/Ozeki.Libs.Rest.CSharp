using System;
using System.Collections.Generic;
using System.Text;

namespace Ozeki.Libs.Rest
{
    public class MessageMarkResult
    {
        public Folder Folder;
        public string[] MessageIdsMarkSucceeded;
        public string[] MessageIdsMarkFailed;

        public int TotalCount { get => SuccessCount + FailedCount; }
        public int SuccessCount { get => MessageIdsMarkSucceeded?.Length ?? 0; }
        public int FailedCount { get => MessageIdsMarkFailed?.Length ?? 0; }

        public override string ToString()
        {
            return "Total: " + TotalCount + ". Success: " + SuccessCount + ". Failed: " + FailedCount + ".";
        }
    }
}
