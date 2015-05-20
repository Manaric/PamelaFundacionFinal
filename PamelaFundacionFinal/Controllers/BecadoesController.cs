using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PamelaFundacionFinal.Models;

namespace PamelaFundacionFinal.Controllers
{
    public class BecadoesController : Controller
    {
        private PamelaFundacionEntities db = new PamelaFundacionEntities();

        // GET: Becadoes1
        public ActionResult Index()
        {
            var becado = db.Becado.Include(b => b.Escuela).Include(b => b.Mensualidades).Include(b => b.Organizacion).Include(b => b.Tutor).Include(b => b.Pagos);
            return View(becado.ToList());
        }

        // GET: Becadoes1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Becado becado = db.Becado.Find(id);
            if (becado == null)
            {
                return HttpNotFound();
            }
            return View(becado);
        }

        // GET: Becadoes1/Create
        public ActionResult Create()
        {
            ViewBag.Escuela_ID = new SelectList(db.Escuela, "Escuela_ID", "Nombre");
            ViewBag.Categoria = new SelectList(db.Mensualidades, "Categoria", "Categoria");
            ViewBag.Organizacion_ID = new SelectList(db.Organizacion, "Organizacion_ID", "Nombre");
            ViewBag.Tutor_ID = new SelectList(db.Tutor, "Tutor_ID", "Nombre");
            ViewBag.Becado_ID = new SelectList(db.Pagos, "Becado_ID", "Becado_ID");
            return View();
        }

        // POST: Becadoes1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Becado_ID,Tutor_ID,Escuela_ID,Organizacion_ID,FechaNacimiento,Edad,Nombre,ApellidoPaterno,ApellidoMaterno,Categoria,Promedio,Horas,Actividad")] Becado becado)
        {
            if (ModelState.IsValid)
            {
                db.Becado.Add(becado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Escuela_ID = new SelectList(db.Escuela, "Escuela_ID", "Nombre", becado.Escuela_ID);
            ViewBag.Categoria = new SelectList(db.Mensualidades, "Categoria", "Categoria", becado.Categoria);
            ViewBag.Organizacion_ID = new SelectList(db.Organizacion, "Organizacion_ID", "Nombre", becado.Organizacion_ID);
            ViewBag.Tutor_ID = new SelectList(db.Tutor, "Tutor_ID", "Nombre", becado.Tutor_ID);
            ViewBag.Becado_ID = new SelectList(db.Pagos, "Becado_ID", "Becado_ID", becado.Becado_ID);
            return View(becado);
        }

        // GET: Becadoes1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Becado becado = db.Becado.Find(id);
            if (becado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Escuela_ID = new SelectList(db.Escuela, "Escuela_ID", "Nombre", becado.Escuela_ID);
            ViewBag.Categoria = new SelectList(db.Mensualidades, "Categoria", "Categoria", becado.Categoria);
            ViewBag.Organizacion_ID = new SelectList(db.Organizacion, "Organizacion_ID", "Nombre", becado.Organizacion_ID);
            ViewBag.Tutor_ID = new SelectList(db.Tutor, "Tutor_ID", "Nombre", becado.Tutor_ID);
            ViewBag.Becado_ID = new SelectList(db.Pagos, "Becado_ID", "Becado_ID", becado.Becado_ID);
            return View(becado);
        }

        // POST: Becadoes1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Becado_ID,Tutor_ID,Escuela_ID,Organizacion_ID,FechaNacimiento,Edad,Nombre,ApellidoPaterno,ApellidoMaterno,Categoria,Promedio,Horas,Actividad")] Becado becado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(becado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Escuela_ID = new SelectList(db.Escuela, "Escuela_ID", "Nombre", becado.Escuela_ID);
            ViewBag.Categoria = new SelectList(db.Mensualidades, "Categoria", "Categoria", becado.Categoria);
            ViewBag.Organizacion_ID = new SelectList(db.Organizacion, "Organizacion_ID", "Nombre", becado.Organizacion_ID);
            ViewBag.Tutor_ID = new SelectList(db.Tutor, "Tutor_ID", "Nombre", becado.Tutor_ID);
            ViewBag.Becado_ID = new SelectList(db.Pagos, "Becado_ID", "Becado_ID", becado.Becado_ID);
            return View(becado);
        }

        // GET: Becadoes1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Becado becado = db.Becado.Find(id);
            if (becado == null)
            {
                return HttpNotFound();
            }
            return View(becado);
        }

        // POST: Becadoes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Becado becado = db.Becado.Find(id);
            db.Becado.Remove(becado);
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

