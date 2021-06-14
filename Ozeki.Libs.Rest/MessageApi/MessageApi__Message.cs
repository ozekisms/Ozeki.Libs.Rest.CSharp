using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Ozeki.Libs.Rest
{
    partial class MessageApi
    {
        //**********************************************
        // Parse message
        //**********************************************

        static Message ParseMessage(JsonElement messageElement)
        {
            var msg = new Message();
            //Id
            msg.ID = messageElement.GetProperty(PROP_NAME_MESSAGE_ID).GetString();
            //From
            msg.FromConnection = GetString(messageElement, PROP_NAME_FROM_CONNECTION, null);
            msg.FromAddress = GetString(messageElement, PROP_NAME_FROM_ADDRESS, null);
            msg.FromStation = GetString(messageElement, PROP_NAME_FROM_STATION, null);
            //To
            msg.ToConnection = GetString(messageElement, PROP_NAME_TO_CONNECTION, null);
            msg.ToAddress = GetString(messageElement, PROP_NAME_TO_ADDRESS, null);
            msg.ToStation = GetString(messageElement, PROP_NAME_TO_STATION, null);
            //Text
            msg.Text = GetString(messageElement, PROP_NAME_TEXT, null);
            //Dates
            msg.CreateDate = GetDate(messageElement, PROP_NAME_CREATE_DATE, DateTime.MinValue);
            msg.ValidUntil = GetDate(messageElement, PROP_NAME_VALID_UNTIL, DateTime.MinValue);
            msg.TimeToSend = GetDate(messageElement, PROP_NAME_TIME_TO_SEND, DateTime.MinValue);
            //Reports
            msg.IsSubmitReportRequested = GetBool(messageElement, PROP_NAME_SUBMIT_REPORT_REQUESTED, false);
            msg.IsDeliveryReportRequested = GetBool(messageElement, PROP_NAME_DELIVERY_REPORT_REQUESTED, false);
            msg.IsViewReportRequested = GetBool(messageElement, PROP_NAME_VIEW_REPORT_REQUESTED, false);
            //Tags
            AppendTags(msg, messageElement);
            return msg;
        }

        static void AppendTags(Message message, JsonElement messageElement)
        {
            var tagsElement = messageElement.GetProperty("tags");
            var tagsArray = tagsElement.EnumerateArray();
            foreach (var tag in tagsArray)
            {
                var name = tag.GetProperty("name").GetString();
                var value = tag.GetProperty("value").GetString();
                message.AddTag(name, value);
            }
        }

        //**********************************************
        // Support functions
        //**********************************************

        static string GetString(JsonElement element, string propertyName, string nullValue)
        {
            if (element.TryGetProperty(propertyName, out var value))
                return value.GetString();
            return nullValue;
        }

        static bool GetBool(JsonElement element, string propertyName, bool nullValue)
        {
            if (element.TryGetProperty(propertyName, out var value))
                return value.GetBoolean();
            return nullValue;
        }

        static DateTime GetDate(JsonElement element, string propertyName, DateTime nullValue)
        {
            if (element.TryGetProperty(propertyName, out var value))
                return DateTime.Parse(value.GetString());
            return nullValue;
        }
    }
}
