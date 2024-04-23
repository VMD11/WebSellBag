using SellingBags.Areas.Admin.Models.DataContext;
using SellingBags.Areas.Admin.Models.ViewModel;
using SellingBags.Common;
using SellingBags.Converter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace SellingBags.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Login()
        {
            LoginVM loginVM = new LoginVM();
            ViewBag.Error_Text = "";
            return View(loginVM);
        }

        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            ViewBag.Error_Text = "";
            if (ModelState.IsValid)
            {
                LoginContext loginContext = new LoginContext();
                var result = loginContext.Login(loginVM.UserName, Encryptor.MD5Hash(loginVM.Password));
                
                if (result == 1)
                {
                    var account = loginContext.GetByName(loginVM.UserName);
                    var user_session = new LoginAccount();
                    user_session.ID_Account = account.ID_Account;
                    user_session.UserName = account.UserName;
                    Session.Add(Sessions.ADMIN_SESSION, user_session);
                    return RedirectToAction("Index", "Dashboard");
                }
                else if(result == 0)
                {
                    ViewBag.Error_Text += "Thông tin đăng nhập không chính xác, vui lòng thử lại";

                }
                else if(result == -1)
                {
                    ViewBag.Error_Text += "Tài khoản này không đủ quyền truy cập";
                }
                else
                {
                    ViewBag.Error_Text += "Thông tin đăng nhập không chính xác, vui lòng thử lại";
                }
                Debug.WriteLine(result);
            }
            return View(loginVM);
        }
    }
}