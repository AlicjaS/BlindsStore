using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Blinds02.Models;
using System.Collections.Generic;

namespace Blinds02.Controllers
{
    public class TextilesController : SharedController<Textile>
    {
        // GET: Textiles/Delete
        public override ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<BlindItem> blindItems = repository.GetOtherDbSet<BlindItem>();
            if (blindItems.Where(o => o.TextileID == id).Count() > 0)
            {
                return RedirectToAction("Warning", "Warning", new Warning()
                { WarningText = "You can't delete this Textile - there are still Blinds using it." });
            }
            Textile textile = repository.Get(id);
            if (textile == null)
            {
                return HttpNotFound();
            }
            return View(textile);
        }

        // POST: Textiles/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public override ActionResult DeleteConfirmed(int id)
        {
            Textile textile = repository.Get(id);
            repository.Remove(textile);
            repository.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
