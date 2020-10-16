using SIS.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.MvcFramework
{
    public abstract class BaseHttpAttribute : Attribute
    {
        public string Url { get; set; }

        public abstract HttpMethod Method { get; }
    }
}
