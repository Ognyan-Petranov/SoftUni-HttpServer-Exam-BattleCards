using SIS.HTTP;
using SIS.MvcFramework;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        [HttpGet]
        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpGet]
        public HttpResponse All()
        {
            return this.View();
        }

        [HttpGet]
        public HttpResponse Collection()
        {
            return this.View();
        }
    }
}
