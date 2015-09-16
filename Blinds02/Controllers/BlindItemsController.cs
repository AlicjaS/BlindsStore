﻿using System;
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
    public class BlindItemsController : Controller
    {
        private Blinds02Context db = new Blinds02Context();

        // GET: BlindItems
        public ActionResult Index()
        {
            var blindItems = db.BlindItems.Include(b => b.Textile);
            var last20BlindItems = (from item in blindItems
                                   where item.BlindItemID > (blindItems.Count() - 20)
                                   orderby item.BlindItemID descending
                                   select item);
            return View(last20BlindItems.ToList());
        }

        // GET: BlindItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BlindItem blindItem = db.BlindItems.Include(b => b.Textile).Where(o => o.BlindItemID == id).First();
            if (blindItem == null)
            {
                return HttpNotFound();
            }
            return View(blindItem);
        }

        // GET: BlindItems/Create
        public ActionResult Create()
        {
            ViewBag.TextileID = new SelectList(db.Textiles, "TextileID", "TextileName");
            return View();
        }

        // POST: BlindItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlindItemID,Width,Height,TextileID")] BlindItem blindItem)
        {
            Textile textile = db.Textiles.Where(o => o.TextileID == blindItem.TextileID).First();

            blindItem.UpdateItem(textile);

            if (ModelState.IsValid)
            {
                db.BlindItems.Add(blindItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TextileID = new SelectList(db.Textiles, "TextileID", "TextileName", blindItem.TextileID);
            return View(blindItem);
        }

        // GET: BlindItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlindItem blindItem = db.BlindItems.Find(id);
            if (blindItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.TextileID = new SelectList(db.Textiles, "TextileID", "TextileName", blindItem.TextileID);
            return View(blindItem);
        }

        // POST: BlindItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlindItemID,Width,Height,TextileID")] BlindItem blindItem)
        {

            Textile textile = db.Textiles.Where(o => o.TextileID == blindItem.TextileID).First();

            blindItem.UpdateItem(textile);
            if (ModelState.IsValid)
            {
                db.Entry(blindItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TextileID = new SelectList(db.Textiles, "TextileID", "TextileName", blindItem.TextileID);
            return View(blindItem);
        }

        // GET: BlindItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlindItem blindItem = db.BlindItems.Find(id);
            if (blindItem == null)
            {
                return HttpNotFound();
            }
            return View(blindItem);
        }

        // POST: BlindItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlindItem blindItem = db.BlindItems.Find(id);
            db.BlindItems.Remove(blindItem);
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