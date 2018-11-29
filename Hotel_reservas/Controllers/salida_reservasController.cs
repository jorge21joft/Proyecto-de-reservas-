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
    public class salida_reservasController : Controller
    {
        private Model1 db = new Model1();
        static List<Reservas> ListaReserva = new List<Reservas>();
        static List<Huesped> huesped = new List<Huesped>();

        // GET: salida_reservas
        public ActionResult Index()
        {
            return View(db.salida_reservas.ToList());
        }

        // GET: salida_reservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salida_reservas salida_reservas = db.salida_reservas.Find(id);
            if (salida_reservas == null)
            {
                return HttpNotFound();
            }
            return View(salida_reservas);
        }

        // GET: salida_reservas/Create
        public ActionResult Create()
        {
            ViewBag.Reservas = db.Reservas.ToList();
            return View();
        }

        public ActionResult DetallesCrear(int? id_reservas, string nombre, int numero_habitaciones, string fecha_entrada, string fecha_salida, string huesped, int id_habitacion, int total)
        {
            if ((id_reservas > 0 && id_reservas != null))
            {

                Reservas item = new Reservas();
                Huesped ite = new Huesped();

                item = db.Reservas.Find(id_reservas);



                ListaReserva.Add(item);
                return PartialView(ListaReserva);
            }
            else
            {
                return PartialView();
            }

        }

        public ActionResult DetallesVer(int id_salida_reservas)
        {
            return PartialView("DetallesCrear", db.salida_reservas.Find(id_salida_reservas).Reservas);
        }

        // POST: salida_reservas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_salida_reservas,observaciones,ud_usuario,id_reserva")] salida_reservas salida_reservas)
        {

            foreach (var item in ListaReserva)
            {
                Reservas reser = new Reservas();
                reser.numero_habitaciones = item.numero_habitaciones;
                reser.fecha_entrada = item.fecha_entrada;
                reser.fecha_salida = item.fecha_salida;
                reser.dias = item.dias;
                reser.total = item.total;
                reser.id_huesped = item.id_huesped;
                reser.id_usuario = item.id_usuario;
                reser.id_empleado = item.id_empleado;
                reser.id_habitacion = item.id_habitacion;
                reser.id_pago = item.id_pago;
            }


            //consultas a las tablas
            Reservas rer = (from reser in db.Reservas select reser).First();
            Habitaciones habi = (from habita in db.Habitaciones where habita.id_habitaciones == rer.id_habitacion select habita).First();

            //condiciones
            if (habi.tipo == "habitacion doble")
            {
                habi.cantidad = habi.cantidad + rer.numero_habitaciones;
            }

            if (habi.tipo == "habitacion sencilla")
            {
                habi.cantidad = habi.cantidad + rer.numero_habitaciones;
            }

            else if (habi.tipo == "V.I.P")
            {
                habi.cantidad = habi.cantidad + rer.numero_habitaciones;
            }


            if (ModelState.IsValid)
            {
                db.salida_reservas.Add(salida_reservas);
                db.SaveChanges();
                //reseteando la lista
                ListaReserva = new List<Reservas>();
                huesped = new List<Huesped>();
                return RedirectToAction("Index");
            }

            return View(salida_reservas);
        }

        // GET: salida_reservas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salida_reservas salida_reservas = db.salida_reservas.Find(id);
            if (salida_reservas == null)
            {
                return HttpNotFound();
            }
            return View(salida_reservas);
        }

        // POST: salida_reservas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_salida_reservas,observaciones,ud_usuario,id_reserva")] salida_reservas salida_reservas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salida_reservas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salida_reservas);
        }

        // GET: salida_reservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salida_reservas salida_reservas = db.salida_reservas.Find(id);
            if (salida_reservas == null)
            {
                return HttpNotFound();
            }
            return View(salida_reservas);
        }

        // POST: salida_reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            salida_reservas salida_reservas = db.salida_reservas.Find(id);
            db.salida_reservas.Remove(salida_reservas);
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
