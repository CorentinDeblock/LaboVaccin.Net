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
    public class InActivityService : IntServices<DataContext, InActivity, InActivityModel, InActivityForm>
    {
        public InActivityService(DataContext dc) : base(dc, new InActivityMapper())
        {
        }

        protected override InActivity MapModelToEntity(InActivityModel model, CRUDAction action = CRUDAction.Conversion)
        {
            InActivity inActivity = base.MapModelToEntity(model, action);
            if (model.Center != null)
                inActivity.Center = new CenterMapper().MapModelToEntity(model.Center);
            return inActivity;
        }
        protected override DbSet<InActivity> GetDbSet(DataContext dc) => dc.InActivitties;
    }
}
