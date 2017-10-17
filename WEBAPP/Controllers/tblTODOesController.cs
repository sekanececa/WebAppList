using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WEBAPP.Models;

namespace WEBAPP.Controllers
{
    public class tblTODOesController : Controller
    {
        private TODOEntities db = new TODOEntities();

        // GET: tblTODOes
        public ActionResult Index()
        {
            return View(db.tblTODOes.ToList());
        }

        // GET: tblTODOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTODO tblTODO = db.tblTODOes.Find(id);
            if (tblTODO == null)
            {
                return HttpNotFound();
            }
            return View(tblTODO);
        }
        // primer
        public ActionResult SpecialSelection(string param)
        {
            List<tblTODO> test = db.tblTODOes.Where(x => x.ID > 2).Select(x => x).OrderBy(x => x.Name).ToList();

            return View();
        }
        // GET: tblTODOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblTODOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,IsCompliete")] tblTODO tblTODO)
        {
            if (ModelState.IsValid)
            {
                db.tblTODOes.Add(tblTODO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblTODO);
        }

        // GET: tblTODOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTODO tblTODO = db.tblTODOes.Find(id);
            if (tblTODO == null)
            {
                return HttpNotFound();
            }
            return View(tblTODO);
        }

        // POST: tblTODOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,IsCompliete")] tblTODO tblTODO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTODO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblTODO);
        }

        // GET: tblTODOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTODO tblTODO = db.tblTODOes.Find(id);
            if (tblTODO == null)
            {
                return HttpNotFound();
            }
            return View(tblTODO);
        }

        // POST: tblTODOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTODO tblTODO = db.tblTODOes.Find(id);
            db.tblTODOes.Remove(tblTODO);
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
