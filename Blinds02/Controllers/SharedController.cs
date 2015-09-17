using Blinds02.Models;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace Blinds02.Controllers
{
    public class SharedController<T> : Controller where T : class
    {
        protected Repository<T> repository = new Repository<T>();

        // GET: T/Index
        public virtual ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // GET: T/Details
        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T item = repository.Get(id.Value);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: T/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: T/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(T entity)
        {
            if (ModelState.IsValid)
            {
                repository.Add(entity);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        // GET: T/Edit
        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T item = repository.Get(id.Value);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: T/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(T entity)
        {
            if (ModelState.IsValid)
            {
                repository.Modify(entity);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        // GET: T/Delete
        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T item = repository.Get(id.Value);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: T/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            T item = repository.Get(id);
            repository.Remove(item);
            repository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}