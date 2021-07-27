using Microsoft.EntityFrameworkCore;
using ServiceASP.template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;
using VaccineCenter.Services.Mapper;

namespace VaccineCenter.Services
{
    public class LotService : IntServices<DataContext, Lot, LotModel, LotForm>
    {
        public LotService(DataContext dc) : base(dc, new LotMapper())
        { }
        protected override DbSet<Lot> GetDbSet(DataContext dc)
        {
            return dc.Lots;
        }
    }
}
