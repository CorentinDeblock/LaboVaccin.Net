using ServiceASP.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;

namespace VaccineCenter.Services.Mapper
{
    public class ScheduleForm { }
    public class ScheduleMapper : IMapper<Schedule, ScheduleModel, ScheduleForm>
    {
        public ScheduleModel MapEntityToModel(Schedule entity)
        {
            return new ScheduleModel
            {
                Name = entity.Name,
                OpenAt = entity.OpenAt,
                CloseAt = entity.CloseAt
            };
        }

        public Schedule MapFormToEntity(ScheduleForm form)
        {
            throw new NotImplementedException();
        }

        public Schedule MapModelToEntity(ScheduleModel model)
        {
            return new Schedule
            {
                Name = model.Name,
                OpenAt = model.OpenAt,
                CloseAt = model.CloseAt
            };
        }

        public ScheduleForm MapModelToForm(ScheduleModel model)
        {
            throw new NotImplementedException();
        }
    }
}
