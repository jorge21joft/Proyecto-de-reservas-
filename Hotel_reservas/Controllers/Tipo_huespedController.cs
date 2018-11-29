using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel_reservas.Models;

namespace Hotel_reservas.Controllers
{
    public class Tipo_huespedController : Controller
    {
        private Model1 db = new Model1();

        // GET: Tipo_huesped
        public ActionResult Index()
        {
            return View(db.Tipo_huesped.ToList());
        }

        // GET: Tipo_huesped/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_huesped tipo_huesped = db.Tipo_huesped.Find(id);
            if (tipo_huesped == null)
            {
                return HttpNotFound();
            }
            return View(tipo_huesped);
        }

        // GET: Tipo_huesped/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_huesped/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_huesped,tipo")] Tipo_huesped tipo_huesped)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_huesped.Add(tipo_huesped);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_huesped);
        }

        // GET: Tipo_huesped/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_huesped tipo_huesped = db.Tipo_huesped.Find(id);
            if (tipo_huesped == null)
            {
                return HttpNotFound();
            }
            return View(tipo_huesped);
        }

        // POST: Tipo_huesped/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_huesped,tipo")] Tipo_huesped tipo_huesped)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_huesped).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_huesped);
        }

        // GET: Tipo_huesped/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_huesped tipo_huesped = db.Tipo_huesped.Find(id);
            if (tipo_huesped == null)
            {
                return HttpNotFound();
            }
            return View(tipo_huesped);
        }

        // POST: Tipo_huesped/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_huesped tipo_huesped = db.Tipo_huesped.Find(id);
            db.Tipo_huesped.Remove(tipo_huesped);
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
