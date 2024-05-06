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
        public ActionResult Index()
        {
            if(Account() == null)
                return RedirectToAction("Index","Login");
            AccountVM accountVM = new AccountVM();
            accountVM.Accounts = AccountContext.GetAccounts();
            accountVM.Customers = AccountContext.GetCustomers();
            return View(accountVM);
        }

        public ActionResult Lock(string ID_Account) 
        {
            if (AccountContext.LockAccount(ID_Account))
                return Json(new {result = true});
            return Json(new {result = false});
        }
        public ActionResult UnLock(string ID_Account) 
        {
            if (AccountContext.UnLockAccount(ID_Account))
                return RedirectToAction("Index","AccountManage");
            return RedirectToAction("Index","AccountManage");
        }

        private LoginAccount Account()
        {
            return Session[Sessions.ADMIN_SESSION] as LoginAccount;
        }
    }
}