using Microsoft.AspNetCore.Mvc;
using ServiceASP.template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;

namespace VaccineCenter.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CenterController : Controller
    {
        IIntService<Center, CenterModel, CenterForm> CenterServices;

        public CenterController(IIntService<Center, CenterModel, CenterForm> centerServices)
        {
            CenterServices = centerServices;
        }

        [HttpGet]
        public IEnumerable<CenterModel> Get()
        {
            return CenterServices.Get();
        }

        [HttpGet("{id}")]
        public CenterModel GetCenter(int id)
        {
            return CenterServices.Get(id);
        }
    }
}
