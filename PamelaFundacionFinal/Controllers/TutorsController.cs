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
    public class TutorsController : Controller
    {
        private PamelaFundacionEntities db = new PamelaFundacionEntities();

        // GET: Tutors
        public ActionResult Index()
        {
            var tutor = db.Tutor.Include(t => t.Trabajo1);
            return View(tutor.ToList());
        }

        // GET: Tutors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutor tutor = db.Tutor.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View(tutor);
        }

        // GET: Tutors/Create
        public ActionResult Create()
        {
            ViewBag.Trabajo = new SelectList(db.Trabajo, "Nombre", "Direccion");
            return View();
        }

        // POST: Tutors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tutor_ID,Nombre,ApellidoPaterno,ApellidoMaterno,Trabajo,Puesto,Correo,Telefono,Celular,Direccion,TotalFamilia,HorasFamilia")] Tutor tutor)
        {
            if (ModelState.IsValid)
            {
                db.Tutor.Add(tutor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Trabajo = new SelectList(db.Trabajo, "Nombre", "Direccion", tutor.Trabajo);
            return View(tutor);
        }

        // GET: Tutors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutor tutor = db.Tutor.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Trabajo = new SelectList(db.Trabajo, "Nombre", "Direccion", tutor.Trabajo);
            return View(tutor);
        }

        // POST: Tutors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tutor_ID,Nombre,ApellidoPaterno,ApellidoMaterno,Trabajo,Puesto,Correo,Telefono,Celular,Direccion,TotalFamilia,HorasFamilia")] Tutor tutor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tutor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Trabajo = new SelectList(db.Trabajo, "Nombre", "Direccion", tutor.Trabajo);
            return View(tutor);
        }

        // GET: Tutors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutor tutor = db.Tutor.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View(tutor);
        }

        // POST: Tutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tutor tutor = db.Tutor.Find(id);
            db.Tutor.Remove(tutor);
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
