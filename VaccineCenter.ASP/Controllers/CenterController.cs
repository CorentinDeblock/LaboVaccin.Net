using Microsoft.AspNetCore.Mvc;
using ServiceASP.template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineCenter.ASP.Controllers.Emcriptor;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;

namespace VaccineCenter.ASP.Controllers
{
    public class CenterController : Controller
    {
        IIntService<InActivity, InActivityModel, InActivityForm> InActivityService;
        IIntService<Center, CenterModel, CenterForm> CenterService;

        public CenterController(IIntService<InActivity, InActivityModel, InActivityForm> inActivityService, IIntService<Center, CenterModel, CenterForm> centerService)
        {
            InActivityService = inActivityService;
            CenterService = centerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CenterForm form)
        {
            if(ModelState.IsValid)
            {
                form.InActivityId = InActivityService.Insert(form).Id;
                form.ResponsibleId = HttpContext.Session.DecryptStaff().Id;
                
                CenterService.Insert(form);
                return Redirect("/");
            }
            ViewData["Error"] = "Form is invalid";
            return View(form);
        }
    }
}
