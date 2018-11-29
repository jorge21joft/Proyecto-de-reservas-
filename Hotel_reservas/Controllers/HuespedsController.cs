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
    public class HuespedsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Huespeds
        public ActionResult Index()
        {
            var huesped = db.Huesped.Include(h => h.Tipo_huesped);
            return View(huesped.ToList());
        }

        /*el controlador que nos administra la busqueda asincrona, se llama igual que la vista parcial y se hace una consulta a la 
      la base de datos de huesped*/
        [HttpPost]
        public ActionResult buscar(string valor, string filtro)
        {

            if (filtro == "Nombre")
            {
                var consulta = from c in db.Huesped where c.nombre.Contains(valor) select c;
                return PartialView("buscar", consulta);
            }
            else
            {
                if (filtro == "Tipo de huesped")
                {
                    var consulta = from c in db.Huesped where c.Tipo_huesped.tipo.Contains(valor) select c;
                    return PartialView("buscar", consulta);
                }

            }

            return View();
        }

        // GET: Huespeds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Huesped huesped = db.Huesped.Find(id);
            if (huesped == null)
            {
                return HttpNotFound();
            }
            return View(huesped);
        }

        // GET: Huespeds/Create
        public ActionResult Create()
        {
            ViewBag.id_tipo_huesped = new SelectList(db.Tipo_huesped, "id_tipo_huesped", "tipo");
            return View();
        }

        // POST: Huespeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_huesped,nombre,direccion,dui,telefono,correo,id_tipo_huesped")] Huesped huesped)
        {
            if (ModelState.IsValid)
            {
                db.Huesped.Add(huesped);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tipo_huesped = new SelectList(db.Tipo_huesped, "id_tipo_huesped", "tipo", huesped.id_tipo_huesped);
            return View(huesped);
        }

        // GET: Huespeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Huesped huesped = db.Huesped.Find(id);
            if (huesped == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_tipo_huesped = new SelectList(db.Tipo_huesped, "id_tipo_huesped", "tipo", huesped.id_tipo_huesped);
            return View(huesped);
        }

        // POST: Huespeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_huesped,nombre,direccion,dui,telefono,correo,id_tipo_huesped")] Huesped huesped)
        {
            if (ModelState.IsValid)
            {
                db.Entry(huesped).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tipo_huesped = new SelectList(db.Tipo_huesped, "id_tipo_huesped", "tipo", huesped.id_tipo_huesped);
            return View(huesped);
        }

        // GET: Huespeds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Huesped huesped = db.Huesped.Find(id);
            if (huesped == null)
            {
                return HttpNotFound();
            }
            return View(huesped);
        }

        // POST: Huespeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Huesped huesped = db.Huesped.Find(id);
            db.Huesped.Remove(huesped);
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
