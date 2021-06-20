using ModelFE.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanSachOnline.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        DoanNgocPhuQuocContext db;

        public CategoryController()
        {
            db = new DoanNgocPhuQuocContext();
        }

        // GET: Admin/Category
        public ActionResult Index()
        {
            var result = db.Category.ToList();
            return View(result);
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        // tạo mới danh mục
        [HttpPost]
        public ActionResult Create(Category model)
        {
            try
            {
                // TODO: Add insert logic here
                db.Category.Add(model);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Edit/5
        // sửa danh mục
        public ActionResult Edit(string id)
        {

            var editing = db.Category.Find(id);

            return View(editing);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            try
            {
                // TODO: Add update logic here
                var item = db.Category.Find(model.IDCate);
                item.IDCate = model.IDCate;
                item.Name = model.Name;
                item.Description = model.Description;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(string id)
        {
            var delete = db.Category.Find(id);

            return View(delete);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var delete = db.Category.Find(id);
                db.Category.Remove(delete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}