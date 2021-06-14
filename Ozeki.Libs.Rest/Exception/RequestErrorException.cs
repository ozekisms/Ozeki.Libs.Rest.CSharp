using System;
using System.Collections.Generic;
using System.Text;

namespace Ozeki.Libs.Rest
{
    class RequestErrorException : Exception
    {
        public readonly int HttpCode;
        public readonly string ResponseCode;
        public readonly string ResponseMessage;

        public RequestErrorException(int httpCode, string responseCode, string responseMessage) : base(responseMessage)
        {
            HttpCode = httpCode;
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;
        }
    }
}
