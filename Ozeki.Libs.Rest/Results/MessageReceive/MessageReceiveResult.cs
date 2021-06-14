using System;
using System.Collections.Generic;
using System.Text;

namespace Ozeki.Libs.Rest
{
    class MessageReceiveResult
    {
        public Folder Folder;
        public string Limit;
        public Message[] Messages;

        public int MessageCount { get => Messages?.Length ?? 0; }

        public override string ToString()
        {
            return "Message count: " + MessageCount + ".";
        }
    }
}
