using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WS.Accounts.Site.Controllers
{
    public class TransactionController : Controller
    {

        public TransactionController()
        {

        }
        //
        // GET: /Transaction/

        public ActionResult Index()
        {
            return View();
        }

    }
}
