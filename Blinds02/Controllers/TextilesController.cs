using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blinds02.Models;

namespace Blinds02.Controllers
{
    public class TextilesController : Controller
    {
        private Blinds02Context db = new Blinds02Context();

        // GET: Textiles
        public ActionResult Index()
        {
            return View(db.Textiles.ToList());
        }

        // GET: Textiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Textile textile = db.Textiles.Find(id);
            if (textile == null)
            {
                return HttpNotFound();
            }
            return View(textile);
        }

        // GET: Textiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Textiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TextileID,TextileName,TextilePrice")] Textile textile)
        {
            if (ModelState.IsValid)
            {
                db.Textiles.Add(textile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(textile);
        }

        // GET: Textiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Textile textile = db.Textiles.Find(id);
            if (textile == null)
            {
                return HttpNotFound();
            }
            return View(textile);
        }

        // POST: Textiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TextileID,TextileName,TextilePrice")] Textile textile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(textile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(textile);
        }

        // GET: Textiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Textile textile = db.Textiles.Find(id);
            if (textile == null)
            {
                return HttpNotFound();
            }
            return View(textile);
        }

        // POST: Textiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Textile textile = db.Textiles.Find(id);
            db.Textiles.Remove(textile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
