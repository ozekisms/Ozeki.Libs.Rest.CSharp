using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ozeki.Libs.Rest
{
    partial class MessageApi
    {
        //**********************************************
        // Download
        //**********************************************

        public Message[] DownloadIncoming()
        {
            var authHeader = CreateAuthorizationHeader(_configuration.Username, _configuration.Password);
            var jsonResponse = DoRequestGet(getUrl_ReceiveMessage(Folder.Inbox), authHeader);
            var result = ParseMessageReceiveResult(jsonResponse);
            Delete(Folder.Inbox, result.Messages);
            return result.Messages;
        }

        string getUrl_ReceiveMessage(Folder folder)
        {
            var apiUrl = _configuration.ApiUrl.TrimEnd('?');
            return apiUrl + "?action=receivemsg&folder=" + GetFolderName(folder);
        }
    }
}
