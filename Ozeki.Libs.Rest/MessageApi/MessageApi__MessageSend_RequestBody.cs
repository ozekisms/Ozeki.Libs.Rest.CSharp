using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Ozeki.Libs.Rest
{
    partial class MessageApi
    {
        const string MySQLFormat = "yyyy-MM-dd HH:mm:ss";

        //**********************************************
        // Request body
        //**********************************************

        static string CreateRequestBody_SendMessage(Message[] messages)
        {
            using (var ms = new MemoryStream())
            {
                using (var jsonWriter = new Utf8JsonWriter(ms))
                    WriteMessages(jsonWriter, messages);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        static void WriteMessages(Utf8JsonWriter jw, Message[] messages)
        {
            jw.WriteStartObject();
            jw.WriteStartArray("messages");
            foreach (var message in messages)
                WriteMessage(jw, message);
            jw.WriteEndArray();
            jw.WriteEndObject();
        }

        static void WriteMessage(Utf8JsonWriter jw, Message message)
        {
            jw.WriteStartObject();
            //Id
            Write_IfNotNull(jw, PROP_NAME_MESSAGE_ID, message.ID);
            //From
            Write_IfNotNull(jw, PROP_NAME_FROM_CONNECTION, message.FromConnection);
            Write_IfNotNull(jw, PROP_NAME_FROM_ADDRESS, message.FromAddress);
            Write_IfNotNull(jw, PROP_NAME_FROM_STATION, message.FromStation);
            //To
            Write_IfNotNull(jw, PROP_NAME_TO_CONNECTION, message.ToConnection);
            Write_IfNotNull(jw, PROP_NAME_TO_ADDRESS, message.ToAddress);
            Write_IfNotNull(jw, PROP_NAME_TO_STATION, message.ToStation);
            //Text
            Write_IfNotNull(jw, PROP_NAME_TEXT, message.Text);
            //Dates
            Write(jw, PROP_NAME_CREATE_DATE, message.CreateDate);
            Write(jw, PROP_NAME_VALID_UNTIL, message.ValidUntil);
            Write(jw, PROP_NAME_TIME_TO_SEND, message.TimeToSend);
            //Reports
            Write(jw, PROP_NAME_SUBMIT_REPORT_REQUESTED, message.IsSubmitReportRequested);
            Write(jw, PROP_NAME_DELIVERY_REPORT_REQUESTED, message.IsDeliveryReportRequested);
            Write(jw, PROP_NAME_VIEW_REPORT_REQUESTED, message.IsViewReportRequested);
            //Tags
            WriteTags(jw, message);
            jw.WriteEndObject();
        }

        static void WriteTags(Utf8JsonWriter jw, Message message)
        {
            jw.WriteStartArray(PROP_NAME_TAGS);
            var tags = message.GetTags();
            foreach (var tag in tags)
                WriteTag(jw, tag);
            jw.WriteEndArray();
        }

        static void WriteTag(Utf8JsonWriter jw, KeyValuePair<string, string> tag)
        {
            jw.WriteStartObject();
            Write(jw, "name", tag.Key);
            Write(jw, "value", tag.Value);
            jw.WriteEndObject();
        }

        //**********************************************
        // Support functions
        //**********************************************

        static void Write(Utf8JsonWriter jw, string propertyName, bool propertyValue)
        {
            jw.WritePropertyName(propertyName);
            jw.WriteBooleanValue(propertyValue);
        }

        static void Write(Utf8JsonWriter jw, string propertyName, DateTime propertyValue)
        {
            Write(jw, propertyName, propertyValue.ToString(MySQLFormat));
        }

        static void Write_IfNotNull(Utf8JsonWriter jw, string propertyName, string propertyValue)
        {
            if (propertyValue == null)
                return;
            Write(jw, propertyName, propertyValue);
        }

        static void Write(Utf8JsonWriter jw, string propertyName, string propertyValue)
        {
            jw.WritePropertyName(propertyName);
            jw.WriteStringValue(propertyValue);
        }
    }
}
