using Microsoft.AspNetCore.Mvc;
using ServiceASP.template;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;
using Microsoft.AspNetCore;
using VaccineCenter.ASP.Controllers.Emcriptor;

namespace VaccineCenter.ASP.Controllers
{
    public class AccountController : Controller
    {
        IIntService<AccountModel, AccountForm> AccountServices;
        IIntService<AccountTypeModel, AccountTypeForm> AccountTypeServices;
        IIntService<StaffModel, StaffForm> StaffServices;
        public AccountController(
            IIntService<AccountModel, AccountForm> accountServices,
            IIntService<AccountTypeModel, AccountTypeForm> accountTypeServices,
            IIntService<StaffModel, StaffForm> staffServices
        )
        {
            AccountServices = accountServices;
            AccountTypeServices = accountTypeServices;
            StaffServices = staffServices;
        }
        public IActionResult Index()
        {
            return View(AccountServices.Get());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] AccountForm accountForm)
        {
            if(ModelState.IsValid)
            {
                AccountModel acc;

                if(AccountServices.Has(accountForm))
                {
                    acc = AccountServices.Get(accountForm);
                    acc.AccountType.IsStaff = true;
                    AccountServices.Save();
                }else
                {
                    AccountTypeModel model = AccountTypeServices.Insert(new AccountTypeForm
                    {
                        isStaff = true,
                        isPatient = false
                    });

                    accountForm.AccountTypeId = model.Id;
                    acc = AccountServices.Insert(accountForm);
                }

                accountForm.AccountId = acc.Id;
                acc.Staff = StaffServices.Insert(accountForm);
                HttpContext.Session.EncryptAccount(acc);

                return RedirectToAction("Index");
            }
            ViewData["Error"] = "Error on the server. Please contact us on tikiwinki@gmail.com";
            return View();
        }

        public IActionResult Update([FromRoute] int id)
        {
            return View(AccountServices.GetToForm(id));
        }

        [HttpPost]
        public IActionResult Update([FromRoute] int id,[FromForm] AccountForm form)
        {
            if(ModelState.IsValid)
            {
                AccountServices.Update(id, form);
                return RedirectToAction("Index");
            }
            return View(form);
        }

        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {
            return View(AccountServices.Get(id));
        }

        public IActionResult Delete(AccountModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            AccountServices.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
