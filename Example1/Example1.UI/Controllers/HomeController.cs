using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Example1.Contracts;
using Example1.Contracts.Sales;
using NServiceBus;

namespace Example1.UI.Controllers
{
    public class HomeController : Controller
    {
        private IEndpointInstance endpoint;

        public HomeController(IEndpointInstance endpoint)
        {
            this.endpoint = endpoint;
        }
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<ActionResult> SendMessagePlaceOrderCommand(PlaceOrderCommand command)
        {
            await endpoint.Send("Example1.Sales", command).ConfigureAwait(false);
            return RedirectToAction("Index");
        }
    }
}
