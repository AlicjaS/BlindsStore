using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Blinds02.Models;
using System.Collections.Generic;

namespace Blinds02.Controllers
{
    public class CustomersController : SharedController<Customer>
    {
        // GET: Customers/Delete/5
        public override ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Order> orders = repository.GetOtherDbSet<Order>();
            if (orders.Where(o => o.CustomerID == id).Count() > 0)
            {
                return RedirectToAction("Warning", "Warning", new Warning()
                { WarningText = "You can't delete this Customer - there are orders connected to him." });
            }
            Customer customer = repository.Get(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public override ActionResult DeleteConfirmed(int id)
        {
            Customer customer = repository.Get(id);
            repository.Remove(customer);
            repository.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
