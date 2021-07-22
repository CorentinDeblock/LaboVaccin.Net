using Microsoft.AspNetCore.Mvc;
using ServiceASP.Bases;
using System.Collections.Generic;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;

namespace VaccineCenter.ASP.Controllers
{
    public class AccountController : Controller
    {
        IServices<AccountModel, AccountForm, int> AccountServices;
        IServices<AccountTypeModel, AccountTypeForm, int> AccountTypeServices;
        public AccountController(
            IServices<AccountModel, AccountForm, int> accountServices,
            IServices<AccountTypeModel, AccountTypeForm, int> accountTypeServices
        )
        {
            AccountServices = accountServices;
            AccountTypeServices = accountTypeServices;
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
                AccountTypeModel model = AccountTypeServices.Insert(new AccountTypeForm
                {
                    isStaff = true,
                    isPatient = false
                });

                accountForm.AccountTypeId = model.Id;
                AccountServices.Insert(accountForm);

                return RedirectToAction("Index");
            }
            ViewData["Error"] = "Error on form";
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
