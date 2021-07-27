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
    public class CenterService : IntServices<DataContext, Center, CenterModel, CenterForm>
    {
        InActivityMapper iaMapper = new InActivityMapper();
        public CenterService(DataContext dc) : base(dc, new CenterMapper())
        {
           
        }

        protected override CenterModel MapEntityToModel(Center entity, CRUDAction action = CRUDAction.Conversion)
        {
            CenterModel model = base.MapEntityToModel(entity, action);
            model.InActivity = iaMapper.MapEntityToModel(entity.InActivity);
            return model;
        }

        protected override Center MapModelToEntity(CenterModel model, CRUDAction action = CRUDAction.Conversion)
        {
            Center entity = base.MapModelToEntity(model, action);
            entity.InActivity = iaMapper.MapModelToEntity(model.InActivity);
            return entity;
        }

        protected override DbSet<Center> GetDbSet(DataContext dc) => dc.Centers;
        protected override IQueryable<Center> PrepareQuery(DbSet<Center> Entity)
        {
            return base.PrepareQuery(Entity)
                    .Include(c => c.Vaccin)
                        .ThenInclude(v => v.Vaccin)
                    .Include(c => c.InActivity)
                    .Include(c => c.Schedule)
                    .Include(c => c.Log)
                        .ThenInclude(c => c.Lot)
                    .Include(c => c.Planifications)
                    .Include(c => c.Workspace)
                        .ThenInclude(w => w.Staffs)
                            .ThenInclude(s => s.Account);
        }
    }
}
