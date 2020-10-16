using SIS.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.MvcFramework
{
    public interface IMvcApplication
    {
        void ConfigureServices(IServiceCollection serviceCollection);

        void Configure(List<Route> routeTable);
    }
}
