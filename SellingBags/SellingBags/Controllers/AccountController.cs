using SellingBags.Common;
using SellingBags.Converter;
using SellingBags.Models;
using SellingBags.Models.DataContext;
using SellingBags.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SellingBags.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

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
            bool isPhoneOrEmail = Regex.IsMatch(loginVM.UserName, RegexAccount.phoneRegex) || Regex.IsMatch(loginVM.UserName, RegexAccount.emailRegex);
            if (isPhoneOrEmail)
            {
                LoginContext loginContext = new LoginContext();
                var result = loginContext.Login(loginVM.UserName, Encryptor.MD5Hash(loginVM.Password));
                if(result == 1)
                {
                    var account = loginContext.GetByName(loginVM.UserName);
                    var user_session = new LoginAccount();
                    user_session.ID_Account = account.ID_Account;
                    user_session.UserName = account.UserName;
                    Session.Add(Sessions.USER_SESSION, user_session);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.Error_Text += "Thông tin đăng nhập không chính xác, vui lòng thử lại";
                    
                }
            }
            else
            {
                ViewBag.Error_Text += "Số điện thoại không đúng định dạng, vui lòng nhập lại";
            }
            return View(loginVM);
        }

        public ActionResult Logout()
        {
            Session[Sessions.USER_SESSION] = null;
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            RegisterVM registerVM = new RegisterVM();
            ViewBag.Error_Text = "";
            return View(registerVM);
        }

        [HttpPost]
        public ActionResult Register(RegisterVM registerVM) 
        {
            ViewBag.Error_Text = "";
            RegisterContext context = new RegisterContext();
            if(ModelState.IsValid)
            {
                if(Regex.IsMatch(registerVM.UserName,RegexAccount.phoneRegex) || Regex.IsMatch(registerVM.UserName,RegexAccount.emailRegex))
                {
                    if(Regex.IsMatch(registerVM.Password, RegexAccount.passwordRegex))
                    {
                        if (context.IsRegistered(registerVM.UserName))
                        {
                            ViewBag.Error_Text += "Số điện thoại đã đăng ký tài khoản";
                        }
                        else
                        {
                            context.Register(registerVM);
                            ViewBag.Success_Text = "Đăng ký thành công";
                        }
                    }
                    else
                    {
                        ViewBag.Error_Text += "Mật khẩu ít nhất 8 kí tự bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt";
                    }
                }
                else
                {
                    ViewBag.Error_Text += "Số điện thoại không đúng định dạng, vui lòng nhập lại";
                }
            }
            return View(registerVM);
        }
    }
}