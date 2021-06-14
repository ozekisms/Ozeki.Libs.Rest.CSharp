using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ozeki.Libs.Rest
{
    public partial class MessageApi
    {
        readonly Configuration _configuration;

        //**********************************************
        // Construction
        //**********************************************

        public MessageApi(Configuration configuration)
        {
            _configuration = configuration;
        }
    }
}
