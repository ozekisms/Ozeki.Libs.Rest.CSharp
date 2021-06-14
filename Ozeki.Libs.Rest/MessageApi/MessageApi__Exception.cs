using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Ozeki.Libs.Rest
{
    partial class MessageApi
    {
        //**********************************************
        // RequestFailedException
        //**********************************************

        static void ThrowException_IfRequestFailed(JsonElement rootElement)
        {
            if (!rootElement.TryGetProperty("response", out var responseElement))
                return;

            var dataElement = responseElement.GetProperty("data");
            var errorCode = dataElement.GetProperty("errorcode").GetInt32();
            var errorMessage = dataElement.GetProperty("errormessage").GetString();
            throw new RequestFailedException(errorCode, errorMessage);
        }

        //**********************************************
        // RequestErrorException
        //**********************************************

        static void ThrowException_IfRequestError(JsonElement rootElement)
        {
            var httpCode = rootElement.GetProperty("http_code").GetInt32();
            if (httpCode == 200)
                return;

            var responseCode = rootElement.GetProperty("response_code").GetString();
            var responseMessage = rootElement.GetProperty("response_msg").GetString();
            throw new RequestErrorException(httpCode, responseCode, responseMessage);
        }
    }
}
