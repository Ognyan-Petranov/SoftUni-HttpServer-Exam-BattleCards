using SIS.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.MvcFramework
{
    public class HttpPostAttribute : BaseHttpAttribute
    {
        public HttpPostAttribute()
        {
        }

        public HttpPostAttribute(string url)
        {
            this.Url = url;
        }

        public override HttpMethod Method => HttpMethod.Post;
    }
}
