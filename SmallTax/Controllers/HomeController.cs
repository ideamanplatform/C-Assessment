using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace SmallTax.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index ()
		{
			var lehlohonolo = new Person ();

			return View ();
		}
	}
}

