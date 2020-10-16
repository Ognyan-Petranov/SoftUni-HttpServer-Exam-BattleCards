using SIS.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.MvcFramework
{
    public class HttpGetAttribute : BaseHttpAttribute
    {
        public HttpGetAttribute()
        {
        }

        public HttpGetAttribute(string url)
        {
            this.Url = url;
        }

        public override HttpMethod Method => HttpMethod.Get;
    }
}
