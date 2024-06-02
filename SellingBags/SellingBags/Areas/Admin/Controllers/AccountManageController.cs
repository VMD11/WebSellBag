using SellingBags.Areas.Admin.Models.DataContext;
using SellingBags.Areas.Admin.Models.ViewModel;
using SellingBags.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellingBags.Areas.Admin.Controllers
{
    public class AccountManageController : Controller
    {
        // GET: Admin/AccountManage
        private readonly AccountContext accountContext;
        public AccountManageController()
        {
            accountContext = new AccountContext();
        }
        public ActionResult Index()
        {
            if(Account() == null)
                return RedirectToAction("Index","Login");
            AccountVM accountVM = new AccountVM();
            accountVM.Accounts = accountContext.GetAccounts();
            accountVM.Customers = accountContext.GetCustomers();
            return View(accountVM);
        }

        public ActionResult Lock(string ID_Account) 
        {
            if (accountContext.LockAccount(ID_Account))
                return Json(new { result = true, message = "Khóa thành công", redirectUrl = Url.Action("Index", "AccountManage"), JsonRequestBehavior.AllowGet });
            return Json(new {result = false, message = "Khóa không thành công", JsonRequestBehavior.AllowGet });
        }
        public ActionResult UnLock(string ID_Account) 
        {
            if (accountContext.UnLockAccount(ID_Account))
                return RedirectToAction("Index","AccountManage");
            return RedirectToAction("Index","AccountManage");
        }

        private LoginAccount Account()
        {
            return Session[Sessions.ADMIN_SESSION] as LoginAccount;
        }
    }
}