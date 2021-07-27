using Microsoft.EntityFrameworkCore;
using ServiceASP.Bases;
using ServiceASP.template;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Services.Mapper;

namespace VaccineCenter.Services
{
    public class VaccinService : IntServices<DataContext, Vaccin, VaccinModel, VaccinForm>
    {
        public VaccinService(DataContext dc) : base(dc, new VaccinMapper())
        {
        }

        protected override DbSet<Vaccin> GetDbSet(DataContext dc)
        {
            return dc.Vaccins;
        }
    }
}
