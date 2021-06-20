using BanSachOnline.Areas.Admin.Models;
using BanSachOnline.Common;
using ModelFE.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanSachOnline.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.login(user.UserName, Encryptor.EncryptMD5(user.Password));
                if (result == 1)
                {
                    ModelState.AddModelError("", "Đăng nhập thành công");
                    //Taọ sestion để ddieuf hướng sang trang home
                    Session.Add(Constants.USER_SESSION, user);
                    //Chuyen tu trang Index sang trang Home
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Đăng nhập thất bại");
            }
            return View("Index");
        }
    }
}