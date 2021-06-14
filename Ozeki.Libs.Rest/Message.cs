using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Ozeki.Libs.Rest
{
    public class Message
    {
        //**********************************************
        // Id
        //**********************************************

        public string ID { get; set; }

        //**********************************************
        // From
        //**********************************************

        public string FromConnection { get; set; }
        public string FromAddress { get; set; }
        public string FromStation { get; set; }

        //**********************************************
        // To
        //**********************************************

        public string ToConnection { get; set; }
        public string ToAddress { get; set; }
        public string ToStation { get; set; }

        //**********************************************
        // Text
        //**********************************************

        public string Text { get; set; }

        //**********************************************
        // Dates
        //**********************************************

        public DateTime CreateDate { get; set; }
        public DateTime ValidUntil { get; set; }
        public DateTime TimeToSend { get; set; }

        //**********************************************
        // Reports
        //**********************************************

        public bool IsSubmitReportRequested { get; set; }
        public bool IsDeliveryReportRequested { get; set; }
        public bool IsViewReportRequested { get; set; }

        //**********************************************
        // Optional tags
        //**********************************************

        Dictionary<string, string> _tags;
        Dictionary<string, string> Tags
        {
            get { return _tags ?? (_tags = new Dictionary<string, string>()); }
        }

        public Dictionary<string, string> GetTags()
        {
            lock (Tags)
            {
                return Tags.ToDictionary(entry => entry.Key, entry => entry.Value);
            }
        }

        public void AddTag(string key, string value)
        {
            lock (Tags)
            {
                if (Tags.ContainsKey(key))
                    Tags[key] = value;
                else
                    Tags.Add(key, value);
            }
        }

        //**********************************************
        // Construction
        //**********************************************

        public Message()
        {
            ID = Guid.NewGuid().ToString();
            CreateDate = DateTime.Now;
            TimeToSend = DateTime.Now;
            ValidUntil = DateTime.Now.AddDays(7);
            IsSubmitReportRequested = true;
            IsDeliveryReportRequested = true;
            IsViewReportRequested = true;
        }

        //**********************************************
        // To string
        //**********************************************

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrEmpty(FromAddress))
                sb.Append(FromAddress.ToString());
            else
                sb.Append(FromConnection);

            sb.Append("->");

            if (!string.IsNullOrEmpty(ToAddress))
                sb.Append(ToAddress.ToString());
            else
                sb.Append(ToConnection);

            if (Text != null)
            {
                sb.Append(" '");
                sb.Append(Text);
                sb.Append("'");
            }
            return sb.ToString();
        }
    }
}
