using Blinds02.Models;
using System.Web.Mvc;

namespace Blinds02.Controllers
{
    public class WarningController : Controller
    {
        // Show Warning
        public ActionResult Warning(Warning warning)
        {
            return View(warning);
        }
    }
}
