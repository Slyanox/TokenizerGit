using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tokenizer.Models;

namespace Tokenizer.Controllers
{
    public class PROJETSController : Controller
    {
        private BDDIntégrationEntities db = new BDDIntégrationEntities();

        // GET: PROJETS
        public ActionResult Index()
        {
            return View(db.PROJETS.ToList());
        }

        // GET: PROJETS/Details/5
        public ActionResult Details(decimal id)
        {

            PROJETS pROJETS = db.PROJETS.Find(id);
            if (pROJETS == null)
            {
                return HttpNotFound();
            }
            return View(pROJETS);
        }

        // GET: PROJETS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PROJETS/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nom,nbrTokens")] PROJETS pROJETS)
        {
            if (ModelState.IsValid)
            {
                db.PROJETS.Add(pROJETS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pROJETS);
        }

        // GET: PROJETS/Edit/5
        public ActionResult Edit(decimal id)
        {

            PROJETS pROJETS = db.PROJETS.Find(id);
            if (pROJETS == null)
            {
                return HttpNotFound();
            }
            return View(pROJETS);
        }

        // POST: PROJETS/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nom,nbrTokens")] PROJETS pROJETS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROJETS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pROJETS);
        }

        // GET: PROJETS/Delete/5
        public ActionResult Delete(decimal id)
        {

            PROJETS pROJETS = db.PROJETS.Find(id);
            if (pROJETS == null)
            {
                return HttpNotFound();
            }
            return View(pROJETS);
        }

        // POST: PROJETS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            PROJETS pROJETS = db.PROJETS.Find(id);
            db.PROJETS.Remove(pROJETS);
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
