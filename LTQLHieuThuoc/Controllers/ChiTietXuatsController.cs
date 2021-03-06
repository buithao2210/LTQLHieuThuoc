using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LTQLHieuThuoc.Models;

namespace LTQLHieuThuoc.Controllers
{
    public class ChiTietXuatsController : Controller
    {
        private LTQLDbContext db = new LTQLDbContext();

        // GET: ChiTietXuats
        public ActionResult Index()
        {
            return View(db.ChiTietXuats.ToList());
        }

        // GET: ChiTietXuats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietXuat chiTietXuat = db.ChiTietXuats.Find(id);
            if (chiTietXuat == null)
            {
                return HttpNotFound();
            }
            return View(chiTietXuat);
        }

        // GET: ChiTietXuats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChiTietXuats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STT,MaPhieuXuat,MaThuoc,SoLuong,NgayNhap,MaKhachHang")] ChiTietXuat chiTietXuat)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietXuats.Add(chiTietXuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chiTietXuat);
        }

        // GET: ChiTietXuats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietXuat chiTietXuat = db.ChiTietXuats.Find(id);
            if (chiTietXuat == null)
            {
                return HttpNotFound();
            }
            return View(chiTietXuat);
        }

        // POST: ChiTietXuats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STT,MaPhieuXuat,MaThuoc,SoLuong,NgayNhap,MaKhachHang")] ChiTietXuat chiTietXuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietXuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chiTietXuat);
        }

        // GET: ChiTietXuats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietXuat chiTietXuat = db.ChiTietXuats.Find(id);
            if (chiTietXuat == null)
            {
                return HttpNotFound();
            }
            return View(chiTietXuat);
        }

        // POST: ChiTietXuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietXuat chiTietXuat = db.ChiTietXuats.Find(id);
            db.ChiTietXuats.Remove(chiTietXuat);
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
