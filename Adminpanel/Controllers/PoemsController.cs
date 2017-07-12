using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Adminpanel.Models;
using System.IO;

namespace Adminpanel.Controllers
{
    public class PoemsController : Controller
    {
        private KidsAcademyEntities db = new KidsAcademyEntities();

        // GET: /Poems/
        [Authorize(Roles="adeela")]
        public ActionResult Index()
        {
            return View(db.poemTables.ToList());
        }

        // GET: /Poems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            poemTable poemtable = db.poemTables.Find(id);
            if (poemtable == null)
            {
                return HttpNotFound();
            }
            return View(poemtable);
        }

        // GET: /Poems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Poems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(poemTable poemtable)
        {
            if (ModelState.IsValid)
            {
                String fileName = Path.GetFileNameWithoutExtension(poemtable.ImageFile.FileName);
                String extension = Path.GetExtension(poemtable.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                poemtable.poem_image = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                poemtable.ImageFile.SaveAs(fileName);

                db.poemTables.Add(poemtable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(poemtable);
        }

        // GET: /Poems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            poemTable poemtable = db.poemTables.Find(id);
            if (poemtable == null)
            {
                return HttpNotFound();
            }
            return View(poemtable);
        }

        // POST: /Poems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(poemTable poemtable)
        {
            if (ModelState.IsValid)
            {
                String fileName = Path.GetFileNameWithoutExtension(poemtable.ImageFile.FileName);
                String extension = Path.GetExtension(poemtable.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                poemtable.poem_image = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                poemtable.ImageFile.SaveAs(fileName);


                db.Entry(poemtable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(poemtable);
        }

        // GET: /Poems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            poemTable poemtable = db.poemTables.Find(id);
            if (poemtable == null)
            {
                return HttpNotFound();
            }
            return View(poemtable);
        }

        // POST: /Poems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            poemTable poemtable = db.poemTables.Find(id);
            db.poemTables.Remove(poemtable);
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
