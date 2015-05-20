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
    public class TrabajoesController : Controller
    {
        private PamelaFundacionEntities db = new PamelaFundacionEntities();

        // GET: Trabajoes
        public ActionResult Index()
        {
            return View(db.Trabajo.ToList());
        }

        // GET: Trabajoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajo trabajo = db.Trabajo.Find(id);
            if (trabajo == null)
            {
                return HttpNotFound();
            }
            return View(trabajo);
        }

        // GET: Trabajoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trabajoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,Direccion,Telefono")] Trabajo trabajo)
        {
            if (ModelState.IsValid)
            {
                db.Trabajo.Add(trabajo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trabajo);
        }

        // GET: Trabajoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajo trabajo = db.Trabajo.Find(id);
            if (trabajo == null)
            {
                return HttpNotFound();
            }
            return View(trabajo);
        }

        // POST: Trabajoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nombre,Direccion,Telefono")] Trabajo trabajo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trabajo);
        }

        // GET: Trabajoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajo trabajo = db.Trabajo.Find(id);
            if (trabajo == null)
            {
                return HttpNotFound();
            }
            return View(trabajo);
        }

        // POST: Trabajoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Trabajo trabajo = db.Trabajo.Find(id);
            db.Trabajo.Remove(trabajo);
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
