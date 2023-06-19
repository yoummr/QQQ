using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QQQ.Model;
using QQQ.DAL.Data;

namespace QQQ.Mvc5WebUI.Controllers
{
    public class InterviewController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Interview/
        public ActionResult Index()
        {
            var interviews = db.InterViews.Include(i => i.Contract);
            return View(interviews.ToList());
        }

        // GET: /Interview/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interview interview = db.InterViews.Find(id);
            if (interview == null)
            {
                return HttpNotFound();
            }
            return View(interview);
        }

        // GET: /Interview/Create
        public ActionResult Create()
        {
            ViewBag.ContractId = new SelectList(db.Contracts, "Id", "Name");
            return View();
        }

        // POST: /Interview/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ClientName,InterViewerName,DateAndTime,phone,Description,Tropics,CreateDate,ContractId")] Interview interview)
        {
            if (ModelState.IsValid)
            {
                db.InterViews.Add(interview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContractId = new SelectList(db.Contracts, "Id", "Name", interview.ContractId);
            return View(interview);
        }

        // GET: /Interview/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interview interview = db.InterViews.Find(id);
            if (interview == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractId = new SelectList(db.Contracts, "Id", "Name", interview.ContractId);
            return View(interview);
        }

        // POST: /Interview/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ClientName,InterViewerName,DateAndTime,phone,Description,Tropics,CreateDate,ContractId")] Interview interview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContractId = new SelectList(db.Contracts, "Id", "Name", interview.ContractId);
            return View(interview);
        }

        // GET: /Interview/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interview interview = db.InterViews.Find(id);
            if (interview == null)
            {
                return HttpNotFound();
            }
            return View(interview);
        }

        // POST: /Interview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Interview interview = db.InterViews.Find(id);
            db.InterViews.Remove(interview);
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
