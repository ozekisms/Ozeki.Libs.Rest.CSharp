using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Ozeki.Libs.Rest
{
    public class MessageSendResults
    {
        public int TotalCount;
        public int SuccessCount;
        public int FailedCount;
        public MessageSendResult[] Results;

        public override string ToString()
        {
            return "Total: " + TotalCount + ". Success: " + SuccessCount + ". Failed: " + FailedCount + ".";
        }
    }
}
