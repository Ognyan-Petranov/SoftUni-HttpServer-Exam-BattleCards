using Microsoft.CodeAnalysis.CSharp.Syntax;
using SIS.HTTP;
using SIS.MvcFramework;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        [HttpGet]
        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(string name, string url, string keyword, int attack, int health, string description)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(name) || name.Length < 5 || name.Length > 15)
            {
                return this.Error("Invalid card name. Length must be between 5 and 20 characters.");
            }

            if (string.IsNullOrEmpty(url))
            {
                return this.Error("Image url is required.");
            }

            if (string.IsNullOrEmpty(keyword))
            {
                return this.Error("Card keyword is required.");
            }

            if (attack < 0)
            {
                return this.Error("Attack can not be negative number.");
            }

            if (health < 0)
            {
                return this.Error("Health can not be negative number.");
            }

            if (description.Length > 200 || string.IsNullOrEmpty(description))
            {
                return this.Error("Description is required and can not be longer than 200 characters.");
            }

            return this.View();
        }

        [HttpGet]
        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpGet]
        public HttpResponse Collection()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }
    }
}
