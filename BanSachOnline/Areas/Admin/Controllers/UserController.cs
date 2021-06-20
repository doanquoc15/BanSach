using ModelFE.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ModelFE.EF;
using BanSachOnline.Common;
using System.IO;

namespace BanSachOnline.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var user = new UserDao();
            var model = user.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var user = new UserDao();
            var model = user.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpGet]
        public ActionResult Create(string user)
        {
            var dao = new UserDao();
            var result = dao.Find(user);
            if (result != null)
                return View(result);
            return View();
        }


        public ActionResult Create(UserAccount model)
        {
            if (ModelState.IsValid)
            {
                //Phải đặt phía trước
                if (!string.IsNullOrEmpty(model.Password))
                {
                    SetAlert("Không được để mật khẩu trống", "warning");
                }
                var dao = new UserDao();
                //max hoá pass trước khi truyền vào
                var pass = Encryptor.EncryptMD5(model.Password);
                model.Password = pass;
                string result = "";
                //Tìm tên đăng nhập có trùng không
                //Nếu trùng thì trả về trang Create

                result = dao.Insert(model);

                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Cập nhật người dùng thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    SetAlert("Cập nhật người dùng không thành công", "error");
                }
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(string name)
        {
            var dao = new UserDao();
            var userenti = dao.Find(name);
            if (userenti == null)
            {
                return RedirectToAction("Index");
            }
            else if (userenti.Status.Equals("Blocked"))
            {
                dao.Delete(userenti.UserName);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}