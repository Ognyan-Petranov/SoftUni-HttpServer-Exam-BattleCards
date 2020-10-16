using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpGet]
        public HttpResponse Register()
        {
            return this.View();
        }
    }
}
