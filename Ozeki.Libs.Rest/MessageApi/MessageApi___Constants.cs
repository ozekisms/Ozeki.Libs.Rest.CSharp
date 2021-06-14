using System;
using System.Collections.Generic;
using System.Text;

namespace Ozeki.Libs.Rest
{
    partial class MessageApi
    {
        //**********************************************
        // Message properties
        //**********************************************

        //Id
        const string PROP_NAME_MESSAGE_ID = "message_id";
        //From
        const string PROP_NAME_FROM_CONNECTION = "from_connection";
        const string PROP_NAME_FROM_ADDRESS = "from_address";
        const string PROP_NAME_FROM_STATION = "from_station";
        //To
        const string PROP_NAME_TO_CONNECTION = "to_connection";
        const string PROP_NAME_TO_ADDRESS = "to_address";
        const string PROP_NAME_TO_STATION = "to_station";
        //Text
        const string PROP_NAME_TEXT = "text";
        //Dates
        const string PROP_NAME_CREATE_DATE = "create_date";
        const string PROP_NAME_VALID_UNTIL = "valid_until";
        const string PROP_NAME_TIME_TO_SEND = "time_to_send";
        //Reports
        const string PROP_NAME_SUBMIT_REPORT_REQUESTED = "submit_report_requested";
        const string PROP_NAME_DELIVERY_REPORT_REQUESTED = "delivery_report_requested";
        const string PROP_NAME_VIEW_REPORT_REQUESTED = "view_report_requested";
        //Tags
        const string PROP_NAME_TAGS = "tags";

        //**********************************************
        // Folder
        //**********************************************

        const string FOLDER_INBOX = "inbox";
        const string FOLDER_OUTBOX = "outbox";
        const string FOLDER_SENT = "sent";
        const string FOLDER_NOT_SENT = "notsent";
        const string FOLDER_DELETED = "deleted";

        //**********************************************
        // Support functions / Folder
        //**********************************************

        static Folder GetFolder(string folderName)
        {
            var folderNameLower = folderName.ToLowerInvariant();
            switch (folderNameLower)
            {
                case FOLDER_INBOX:
                    return Folder.Inbox;
                case FOLDER_OUTBOX:
                    return Folder.Outbox;
                case FOLDER_SENT:
                    return Folder.Sent;
                case FOLDER_NOT_SENT:
                    return Folder.NotSent;
                case FOLDER_DELETED:
                    return Folder.Deleted;
                default:
                    throw new Exception("Folder is unknown: " + folderName);
            }
        }

        static string GetFolderName(Folder folder)
        {
            switch (folder)
            {
                case Folder.Inbox:
                    return FOLDER_INBOX;
                case Folder.Outbox:
                    return FOLDER_OUTBOX;
                case Folder.Sent:
                    return FOLDER_SENT;
                case Folder.NotSent:
                    return FOLDER_NOT_SENT;
                case Folder.Deleted:
                    return FOLDER_DELETED;
                default:
                    throw new Exception("Folder is unknown: " + folder.ToString());
            }
        }
    }
}
