using System;
using System.Collections.Generic;
using System.Text;

namespace Ozeki.Libs.Rest
{
    class MessageManipulateResult
    {
        public string Folder;
        public string[] MessageIds;

        public override string ToString()
        {
            return "Updated count: " + (MessageIds?.Length ?? 0) + ". Folder: " + (Folder ?? "<<empty>>" + ".");
        }
    }
}