using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarTraderWebClient.Controllers
{
    /// <summary>
    /// Responsible for serving up the single page for the application
    /// </summary>
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return this.View("Index");
        }

    }
}
