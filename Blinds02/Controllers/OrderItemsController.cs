using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Blinds02.Models;

namespace Blinds02.Controllers
{
    public class OrderItemsController : Controller
    {
        private Blinds02Context db = new Blinds02Context();

        // GET: OrderItems
        public ActionResult Index(int? orderID)
        {
            if (orderID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var orderItems = db.OrderItems.Include(o => o.BlindItem).Include(o => o.Order).
                    Where(o => o.OrderID == orderID);
                if (orderItems.Count() > 0)
                {
                    return View(orderItems.ToList());
                }
                return RedirectToAction("Details", "Orders", new { id = orderID });
            }
        }

        // GET: OrderItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            return View(orderItem);
        }

        // GET: OrderItems/Create
        public ActionResult Create(int? blindItemID, int? orderID)
        {
            Order order = db.Orders.Find(orderID);
            BlindItem blindItem = db.BlindItems.Find(blindItemID);
            if (blindItem == null && order == null)
            {
                ViewBag.BlindItemID = new SelectList(db.BlindItems, "BlindItemID", "Name");
                ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID");
                return View();
            }
            else
            {
                OrderItem orderItem = new OrderItem();
                if (order != null)
                {
                    orderItem.OrderID = order.OrderID;
                }
                if (blindItem != null)
                {
                    orderItem.BlindItemID = blindItem.BlindItemID;
                }
                ViewBag.BlindItemID = new SelectList(db.BlindItems, "BlindItemID", "Name");
                ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID");
                return View(orderItem);
            }
        }

        // POST: OrderItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderItemID,OrderID,BlindItemID,Quantity")] OrderItem orderItem)
        {
            BlindItem blindItem = db.BlindItems.Find(orderItem.BlindItemID);
            orderItem.UpdatePrice(blindItem);
            if (ModelState.IsValid)
            {
                db.OrderItems.Add(orderItem);
                db.SaveChanges();
                return RedirectToAction("UpdateOrder", new { id = orderItem.OrderID });
            }

            ViewBag.BlindItemID = new SelectList(db.BlindItems, "BlindItemID", "Name", orderItem.BlindItemID);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", orderItem.OrderID);
            return View(orderItem);
        }

        // GET: OrderItems/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlindItemID = new SelectList(db.BlindItems, "BlindItemID", "Name", orderItem.BlindItemID);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", orderItem.OrderID);
            return View(orderItem);
        }

        // POST: OrderItems/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderItemID,OrderID,BlindItemID,Quantity")] OrderItem orderItem)
        {
            BlindItem blindItem = db.BlindItems.Find(orderItem.BlindItemID);
            orderItem.UpdatePrice(blindItem);
            if (ModelState.IsValid)
            {
                db.Entry(orderItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UpdateOrder", new { id = orderItem.OrderID });
            }
            ViewBag.BlindItemID = new SelectList(db.BlindItems, "BlindItemID", "Name", orderItem.BlindItemID);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", orderItem.OrderID);
            return View(orderItem);
        }

        // GET: OrderItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            return View(orderItem);
        }

        // POST: OrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderItem orderItem = db.OrderItems.Find(id);
            db.OrderItems.Remove(orderItem);
            db.SaveChanges();
            return RedirectToAction("Index", new { orderID = orderItem.OrderID });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult UpdateOrder(int id)
        {
            Order order = db.Orders.Find(id);
            order.UpdateOrderValue();

            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { orderID = order.OrderID });
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}
