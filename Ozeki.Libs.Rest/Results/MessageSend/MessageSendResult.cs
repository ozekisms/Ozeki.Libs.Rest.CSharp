using System;
using System.Collections.Generic;
using System.Text;

namespace Ozeki.Libs.Rest
{
    public class MessageSendResult
    {
        public Message Message;

        public DeliveryStatus Status;

        public string StatusMessage;

        public override string ToString()
        {
            return Status + ", " + (Message?.ToString() ?? "<<null>>");
        }
    }
}