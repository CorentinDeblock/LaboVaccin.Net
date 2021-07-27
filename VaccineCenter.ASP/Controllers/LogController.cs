using Microsoft.AspNetCore.Mvc;
using ServiceASP.template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;
using VaccineCenter.Services.Mapper;

namespace VaccineCenter.ASP.Controllers
{
    public class LogController : Controller
    {
        IIntService<Log, LogModel, LogForm> LogService;
        IIntService<Lot, LotModel, LotForm> LotService;
        IIntService<VaccinInfo, VaccinInfoModel, VaccinInfoForm> VaccinInfoService;
        IIntService<Center, CenterModel, CenterForm> CenterServices;

        public LogController(IIntService<Log, LogModel, LogForm> logService, IIntService<Lot, LotModel, LotForm> lotService, IIntService<VaccinInfo, VaccinInfoModel, VaccinInfoForm> vaccinInfoService, IIntService<Center, CenterModel, CenterForm> centerServices)
        {
            LogService = logService;
            LotService = lotService;
            VaccinInfoService = vaccinInfoService;
            CenterServices = centerServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int centerId)
        {
            LogForm logform = new LogForm();
            logform.CenterId = centerId;
            logform.vaccinModels = CenterServices.Get(centerId).Vaccin;
            return View(logform);
        }

        [HttpPost]
        public IActionResult Create(LogForm form)
        {
            if(ModelState.IsValid)
            {
                int LotId = -1;

                if(form.ReferenceVaccin)
                {
                    VaccinInfoModel vaccinInfoModel = VaccinInfoService.Get(form.VaccinInfoId);
                    VaccinInfoService.Action(form.VaccinInfoId,e =>
                    {
                        if (form.LogType == DAL.Enum.LogType.In)
                            e.QuantityAvailable += form.Quantity;
                        else
                            e.QuantityAvailable -= form.Quantity;
                    });
                    LotId = LotService.Insert(new LotForm
                    {
                        LotId = form.LotID,
                        VaccinId = vaccinInfoModel.VaccinId
                    }).Id;
                }else
                {
                    LotId = LotService.Insert(new LotForm
                    {
                        LotId = 0,
                        VaccinId = 1
                    }).Id;
                }

                form.Date = DateTime.Now;
                form.LotId = LotId;

                LogService.Insert(form);
                return RedirectToAction("MyAccount", "Staff");
            }
            return View(form);
        }
    }
}
