using Microsoft.EntityFrameworkCore;
using ServiceASP.Bases;
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
    public class VaccinInfoService : IntServices<DataContext, VaccinInfo, VaccinInfoModel, VaccinInfoForm>
    {
        public VaccinInfoService(DataContext dc) : base(dc, new VaccinInfoMapper())
        {
        }

        protected override DbSet<VaccinInfo> GetDbSet(DataContext dc)
        {
            return dc.VaccinInfos;
        }

        protected override IQueryable<VaccinInfo> PrepareQuery(DbSet<VaccinInfo> Entity)
        {
            return base.PrepareQuery(Entity).Include(vi => vi.Vaccin);
        }
    }
}
