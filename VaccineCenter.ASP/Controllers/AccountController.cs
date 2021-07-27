using Microsoft.AspNetCore.Mvc;
using ServiceASP.template;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;
using Microsoft.AspNetCore;
using VaccineCenter.ASP.Controllers.Emcriptor;
using VaccineCenter.DAL.Model;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace VaccineCenter.ASP.Controllers
{
    public class AccountController : Controller
    {
        IIntService<Account, AccountModel, AccountForm> AccountServices;

        public AccountController(IIntService<Account, AccountModel, AccountForm> accountServices)
        {
            AccountServices = accountServices;
        }

        public IActionResult Index()
        {
            return View(AccountServices.Get());
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
