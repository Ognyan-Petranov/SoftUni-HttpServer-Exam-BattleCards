using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.MvcFramework.ViewEngine
{
    public interface IView
    {
        string ExecuteTemplate(object viewModel, string user);
    }
}
