using System;
using System.Collections.Generic;
using System.Text;

namespace Ozeki.Libs.Rest
{
    class RequestFailedException : Exception
    {
        public readonly int ErrorCode;
        public readonly string ErrorMessage;

        public RequestFailedException(int errorCode, string errorMessage) : base(errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}
