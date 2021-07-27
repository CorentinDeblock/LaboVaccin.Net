using Microsoft.EntityFrameworkCore;
using ServiceASP.Bases;
using ServiceASP.template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;
using VaccineCenter.Services.Mapper;

namespace VaccineCenter.Services
{
    public class StaffService : IntServices<DataContext, Staff, StaffModel, StaffForm>
    {
        public StaffService(DataContext dc) : base(dc, new StaffMapper())
        {
        }

        protected override StaffModel MapEntityToModel(Staff entity, CRUDAction action = CRUDAction.Conversion)
        {
            StaffModel model = base.MapEntityToModel(entity, action);
            model.Workspace = new WorkspaceMapper().MapEntityToModel(entity.Workspace);
            return model;
        }

        protected override DbSet<Staff> GetDbSet(DataContext dc) => dc.Staffs;
        protected override IQueryable<Staff> PrepareQuery(DbSet<Staff> Entity)
        {
            return base.PrepareQuery(Entity)
                .Include(s => s.Workspace);
        }
    }
}
