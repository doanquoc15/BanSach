using BanSachOnline.Areas.Admin.Models;
using ModelFE.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace BanSachOnline.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET:Tìm kiếm sản phẩm qua tên sản phẩm
        public ActionResult Index(string searchName)
        {
            var listProduct = new DoanNgocPhuQuocContext();
            //Sắp xếp :
            var result = from s in listProduct.Product
                         orderby s.Quantity ascending , s.UnitCost descending
                         select s;
            if (!string.IsNullOrEmpty(searchName))
            {
                result = result.Where(x => x.Name.Contains(searchName)).OrderByDescending(x => x.Name);
                if (result.Count() <= 0)
                {
                    SetAlert("Không tìm thấy", "error");
                }
            }

            return View(result.ToList());
        }
        //Tìm kiếm Sp
        public IEnumerable<Product> ListWhereAll(string keysearch)
        {
            var db = new DoanNgocPhuQuocContext();
            IQueryable<Product> model = db.Product;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Name.Contains(keysearch));
            }
            return model.OrderBy(x => x.Name);
         }
        public Product Find(string username)
        {
            var db = new DoanNgocPhuQuocContext();
            return db.Product.Find(username);
        }
        //Hiển thị chi tiết sản phẩm

        // GET: Admin/Products/Details/5
        public ActionResult Details(string ID)
        {
            var con = new DoanNgocPhuQuocContext();
            var pro = con.Product.Find(ID);

            var product = pro;
            
            return View(product);
        }

        //Tạo mới sản phẩm
        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            var context = new DoanNgocPhuQuocContext();
            var danhMucSelect = new SelectList(context.Category, "IDCate", "Name");
            ViewBag.IDCate = danhMucSelect;
            Product pro = new Product();
            return View(pro);
        }
        // POST: Admin/Products/Create
        [HttpPost]
        public ActionResult Create(Product model)
        {
            var post = new PostProduct();
            if(post.UploadImage != null)
            {
                string file = Path.GetFileNameWithoutExtension(post.UploadImage.FileName);
            }
            try
            {
                // TODO: Add insert logic here
              

                var context = new DoanNgocPhuQuocContext();

                context.Product.Add(model);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(string ID)
        {
            var db = new DoanNgocPhuQuocContext();
            var pro = db.Product.Find(ID);

            var CateSelect = new SelectList(db.Category, "IDcate", "Name", pro.IDCate);
            ViewBag.IDcate = CateSelect;

            return View(pro);
        }

        // POST: Admin/Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Product model)
        {
            try
            {
                // TODO: Add update logic here

                var db = new DoanNgocPhuQuocContext();
                var item = db.Product.Find(model.IDPro);
                item.IDPro = model.IDPro;
                item.IDCate = model.IDCate;
                item.Name = model.Name;
                item.UnitCost = model.UnitCost;
                item.Quantity = model.Quantity;
                item.Description = model.Description;
                item.Status = model.Status;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(string ID)
        {
            var context = new DoanNgocPhuQuocContext();
            var pro = context.Product.Find(ID);
            return View(pro);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost]
        public ActionResult Delete(string ID, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var context = new DoanNgocPhuQuocContext();
                var pro = context.Product.Find(ID);
                context.Product.Remove(pro);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}