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
    public class Tipo_pagoController : Controller
    {
        private Model1 db = new Model1();

        // GET: Tipo_pago
        public ActionResult Index()
        {
            return View(db.Tipo_pago.ToList());
        }

        // GET: Tipo_pago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_pago tipo_pago = db.Tipo_pago.Find(id);
            if (tipo_pago == null)
            {
                return HttpNotFound();
            }
            return View(tipo_pago);
        }

        // GET: Tipo_pago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_pago/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_pago,tipo")] Tipo_pago tipo_pago)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_pago.Add(tipo_pago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_pago);
        }

        // GET: Tipo_pago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_pago tipo_pago = db.Tipo_pago.Find(id);
            if (tipo_pago == null)
            {
                return HttpNotFound();
            }
            return View(tipo_pago);
        }

        // POST: Tipo_pago/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_pago,tipo")] Tipo_pago tipo_pago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_pago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_pago);
        }

        // GET: Tipo_pago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_pago tipo_pago = db.Tipo_pago.Find(id);
            if (tipo_pago == null)
            {
                return HttpNotFound();
            }
            return View(tipo_pago);
        }

        // POST: Tipo_pago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_pago tipo_pago = db.Tipo_pago.Find(id);
            db.Tipo_pago.Remove(tipo_pago);
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
