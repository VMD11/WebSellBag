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
            if (Account() == null)
            {
                return RedirectToAction("Login", "Account");
            }
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
            if (ModelState.IsValid) { 
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
            }
            return View(loginVM);
        }

        public ActionResult Logout()
        {
            Session[Sessions.USER_SESSION] = null;
            Session[Sessions.CART] = null;
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
        [HttpGet]
        public ActionResult Info()
        {
            if(Account() == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Success = "";
            ViewBag.Error = "";
            AccountVM accountVM = new AccountVM();
            var ID_Account = Account().ID_Account;
            accountVM.Account = AccountContext.GetAccountByID(ID_Account);
            accountVM.Customer = AccountContext.GetCustomerByID(ID_Account);
            return View(accountVM);
        }

        [HttpPost]
        public ActionResult Info(AccountVM accountVM)
        {
            if (Account() == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Success = "";
            ViewBag.Error = "";
            var newCustomer = new Customer
            {
                ID_Customer = accountVM.ID_Customer,
                LastName = accountVM.LastName,
                FirstName = accountVM.FirstName,
                PhoneNumber = accountVM.PhoneNumber,
                City = accountVM.City,
                District = accountVM.District,
                Ward = accountVM.Ward,
                BirthDay = accountVM.BirthDay,
                Address = accountVM.Address,
                Gender = accountVM.Gender,
                ID_Account = Account().ID_Account,
            };
            if (AccountContext.UpdateInfo(newCustomer))
            {
                ViewBag.Success = "Cập nhật thành công";
            }
            else
            {
                ViewBag.Error = "Cập nhật thất bại";
            }
            accountVM.Customer = AccountContext.GetCustomerByID(Account().ID_Account);
            return View(accountVM);
        }

        [HttpGet]
        public ActionResult AddressList()
        {
            if (Account() == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Success = "";
            ViewBag.Error = "";
            var accountVM = new AccountVM();
            accountVM.Addresses = AccountContext.GetAddressesByID(Account().ID_Account);
            return View(accountVM);
        }

        private WishListContext wishListContext = new WishListContext();
        public ActionResult WishList(WishListVM wishListVM)
        {
            if (Account() != null)
            {
                wishListVM.WishLists = wishListContext.GetWishLists(Account().ID_Account);
                return View(wishListVM);
            }
            else
            {
                return RedirectToAction("Login");
                
            }
        }

        public ActionResult AddToWishList(string ID_Product)
        {
            if(Account() != null)
            {
                wishListContext.AddToWishList(Account().ID_Account, ID_Product);
                return RedirectToAction("WishList");
            }
            return RedirectToAction("Login");
        }
        public ActionResult RemoveToWishList(string ID_Product)
        {
            if (Account() != null)
            {
                wishListContext.RemoveToWishList(Account().ID_Account, ID_Product);
                return RedirectToAction("WishList");
            }
            return RedirectToAction("Login");

        }
        private LoginAccount Account()
        {
            return Session[Sessions.USER_SESSION] as LoginAccount;
             
        }

    }
}