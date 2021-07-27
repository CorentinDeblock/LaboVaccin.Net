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
    public class LogService : IntServices<DataContext, Log, LogModel, LogForm>
    {
        public LogService(DataContext dc) : base(dc, new LogMapper())
        {
        }
        protected override DbSet<Log> GetDbSet(DataContext dc)
        {
            return dc.Logs;
        }
        protected override IQueryable<Log> PrepareQuery(DbSet<Log> Entity)
        {
            return base.PrepareQuery(Entity)
                .Include(l => l.Lot)
                .Include(l => l.VaccinInfo)
                    .ThenInclude(vi => vi.Vaccin);
        }
    }
}
