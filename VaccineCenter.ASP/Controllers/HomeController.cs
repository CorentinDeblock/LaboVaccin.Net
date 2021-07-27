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
    public class HomeController : Controller
    {
        IIntService<Center, CenterModel, CenterForm> CenterServices;

        public HomeController(IIntService<Center, CenterModel, CenterForm> centerServices)
        {
            CenterServices = centerServices;
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.HasAccount())
            {
                StaffModel staff = HttpContext.Session.DecryptStaff();
                staff.Workspace.Center = CenterServices.Get(staff.Workspace.CenterId);
                return View(staff);
            }
            return View();
        }
    }
}
