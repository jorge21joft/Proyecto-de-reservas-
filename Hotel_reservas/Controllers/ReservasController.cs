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
    public class ReservasController : Controller
    {
        private Model1 db = new Model1();

        // GET: Reservas
        public ActionResult Index()
        {
            var reservas = db.Reservas.Include(r => r.Empleado).Include(r => r.Habitaciones).Include(r => r.Huesped).Include(r => r.Tipo_pago).Include(r => r.Usuario);
            return View(reservas.ToList());
        }

        [HttpPost]
        public ActionResult BusquedaReserva(string va, string filtro)
        {
            if (filtro == "nombre del huesped")
            {
                var consulta3 = from c in db.Reservas where c.Huesped.nombre.Contains(va) select c;            
                return PartialView("BusquedaReserva", consulta3);
            }
            else
            {
                if (filtro == "tipo de habitacion")
                {
                    var consulta = from c in db.Reservas where c.Habitaciones.tipo.Contains(va) select c;
                    return PartialView("BusquedaReserva", consulta);
                }
            }
            return View();
        }


        // GET: Reservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = db.Reservas.Find(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }
            return View(reservas);
        }

        // GET: Reservas/Create
        public ActionResult Create()
        {
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "nombre");
            ViewBag.id_habitacion = new SelectList(db.Habitaciones, "id_habitaciones", "tipo");
            ViewBag.id_huesped = new SelectList(db.Huesped, "id_huesped", "nombre");
            ViewBag.id_pago = new SelectList(db.Tipo_pago, "id_tipo_pago", "tipo");
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre");
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_reservas,numero_habitaciones,fecha_entrada,fecha_salida,dias,total,id_huesped,id_usuario,id_empleado,id_habitacion,id_pago")] Reservas reservas)
        {

            // estas son las consultas para la tabla de habitaciones y para promociones
            Habitaciones p = (from prod in db.Habitaciones where prod.id_habitaciones == reservas.id_habitacion select prod).First();
            Promociones pro = (from promo in db.Promociones from habi in db.Habitaciones where promo.id_promocion == habi.id_promociones select promo).First();

            //aqui trabajamos en sacar el total aplicando el descuento
            decimal? resultado = reservas.numero_habitaciones * p.precio * reservas.dias;
            decimal? des = pro.descuento / 100;
            decimal? resultado2 = resultado * des;

            //aqui guardamos el total
            reservas.total = resultado - resultado2;


            /*aqui hacemos las condiciones para que al registrar una reserva se le descuente el numero de habitaciones a la cantidad 
            de habitaciones disponibles */
            if (p.tipo == "habitacion doble")
            {
                p.cantidad = p.cantidad - reservas.numero_habitaciones;
            }

            if (p.tipo == "habitacion sencilla")
            {
                p.cantidad = p.cantidad - reservas.numero_habitaciones;
            }
            if (p.tipo == "V.I.P")
            {
                p.cantidad = p.cantidad - reservas.numero_habitaciones;
            }

            if (ModelState.IsValid)
            {
                db.Reservas.Add(reservas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "nombre", reservas.id_empleado);
            ViewBag.id_habitacion = new SelectList(db.Habitaciones, "id_habitaciones", "tipo", reservas.id_habitacion);
            ViewBag.id_huesped = new SelectList(db.Huesped, "id_huesped", "nombre", reservas.id_huesped);
            ViewBag.id_pago = new SelectList(db.Tipo_pago, "id_tipo_pago", "tipo", reservas.id_pago);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", reservas.id_usuario);
            return View(reservas);
        }

        // GET: Reservas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = db.Reservas.Find(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "nombre", reservas.id_empleado);
            ViewBag.id_habitacion = new SelectList(db.Habitaciones, "id_habitaciones", "tipo", reservas.id_habitacion);
            ViewBag.id_huesped = new SelectList(db.Huesped, "id_huesped", "nombre", reservas.id_huesped);
            ViewBag.id_pago = new SelectList(db.Tipo_pago, "id_tipo_pago", "tipo", reservas.id_pago);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", reservas.id_usuario);
            return View(reservas);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_reservas,numero_habitaciones,fecha_entrada,fecha_salida,dias,total,id_huesped,id_usuario,id_empleado,id_habitacion,id_pago")] Reservas reservas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "nombre", reservas.id_empleado);
            ViewBag.id_habitacion = new SelectList(db.Habitaciones, "id_habitaciones", "tipo", reservas.id_habitacion);
            ViewBag.id_huesped = new SelectList(db.Huesped, "id_huesped", "nombre", reservas.id_huesped);
            ViewBag.id_pago = new SelectList(db.Tipo_pago, "id_tipo_pago", "tipo", reservas.id_pago);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", reservas.id_usuario);
            return View(reservas);
        }

        // GET: Reservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = db.Reservas.Find(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }
            return View(reservas);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservas reservas = db.Reservas.Find(id);
            db.Reservas.Remove(reservas);
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
