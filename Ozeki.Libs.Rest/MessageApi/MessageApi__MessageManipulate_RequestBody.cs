using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Ozeki.Libs.Rest
{
    partial class MessageApi
    {
        //**********************************************
        // Request body
        //**********************************************

        static string CreateRequestBody_ManipulateMessage(string folder, string[] messageIds)
        {
            using (var ms = new MemoryStream())
            {
                using (var jsonWriter = new Utf8JsonWriter(ms))
                    WriteMessageIds(jsonWriter, folder, messageIds);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        static void WriteMessageIds(Utf8JsonWriter jw, string folder, string[] messageIds)
        {
            jw.WriteStartObject();
            jw.WritePropertyName("folder");
            jw.WriteStringValue(folder);
            jw.WriteStartArray("message_ids");
            foreach (var messageId in messageIds)
                jw.WriteStringValue(messageId);
            jw.WriteEndArray();
            jw.WriteEndObject();
        }
    }
}
