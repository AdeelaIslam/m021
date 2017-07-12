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
    public class CountingController : Controller
    {
        private KidsAcademyEntities db = new KidsAcademyEntities();

        // GET: /Counting/
        [Authorize(Roles = "adeela")]
        public ActionResult Index()
        {
            return View(db.countingTables.ToList());
        }

        // GET: /Counting/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            countingTable countingtable = db.countingTables.Find(id);
            if (countingtable == null)
            {
                return HttpNotFound();
            }
            return View(countingtable);
        }

        // GET: /Counting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Counting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(countingTable countingtable)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(countingtable.ImageFile.FileName);
                string extension = Path.GetExtension(countingtable.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                countingtable.counting_image = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                countingtable.ImageFile.SaveAs(fileName);




                string fileNameOne = Path.GetFileNameWithoutExtension(countingtable.ImageFileOne.FileName);
                string extensionOne = Path.GetExtension(countingtable.ImageFileOne.FileName);
                fileNameOne = fileNameOne + DateTime.Now.ToString("yymmssfff") + extension;
                countingtable.counting_imageLarge = "~/Images/" + fileNameOne;
                fileNameOne = Path.Combine(Server.MapPath("~/Images/"), fileNameOne);
                countingtable.ImageFile.SaveAs(fileNameOne);




                db.countingTables.Add(countingtable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(countingtable);
        }

        // GET: /Counting/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            countingTable countingtable = db.countingTables.Find(id);
            if (countingtable == null)
            {
                return HttpNotFound();
            }
            return View(countingtable);
        }

        // POST: /Counting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(countingTable countingtable)
        {
            if (ModelState.IsValid)
            {
                if (countingtable.ImageFile != null || countingtable.ImageFileOne != null)
                {
                    String fileName = Path.GetFileNameWithoutExtension(countingtable.ImageFile.FileName);
                    String extension = Path.GetExtension(countingtable.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    countingtable.counting_image = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    countingtable.ImageFile.SaveAs(fileName);




                    string fileNameOne = Path.GetFileNameWithoutExtension(countingtable.ImageFileOne.FileName);
                    string extensionOne = Path.GetExtension(countingtable.ImageFileOne.FileName);
                    fileNameOne = fileNameOne + DateTime.Now.ToString("yymmssfff") + extension;
                    countingtable.counting_imageLarge = "~/Images/" + fileNameOne;
                    fileNameOne = Path.Combine(Server.MapPath("~/Images/"), fileNameOne);
                    countingtable.ImageFile.SaveAs(fileNameOne);


                }
                db.Entry(countingtable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(countingtable);
        }

        // GET: /Counting/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            countingTable countingtable = db.countingTables.Find(id);
            if (countingtable == null)
            {
                return HttpNotFound();
            }
            return View(countingtable);
        }

        // POST: /Counting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            countingTable countingtable = db.countingTables.Find(id);
            db.countingTables.Remove(countingtable);
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
