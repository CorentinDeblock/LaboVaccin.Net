using ServiceASP.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;

namespace VaccineCenter.Services.Mapper
{
    public class LogMapper : IMapper<Log, LogModel, LogForm>
    {
        private LotMapper LotMapper = new LotMapper();
        private VaccinInfoMapper VaccinInfoMapper = new VaccinInfoMapper();

        public LogModel MapEntityToModel(Log entity)
        {
            return new LogModel
            {
                Id = entity.Id,
                Date = entity.Date,
                Description = entity.Description,
                Quantity = entity.Quantity,
                LogType = entity.LogType,
                VaccinInfo = entity.VaccinInfo != null ? VaccinInfoMapper.MapEntityToModel(entity.VaccinInfo) : null,
                Lot = entity.Lot != null ? LotMapper.MapEntityToModel(entity.Lot) : null
            };
        }

        public Log MapFormToEntity(LogForm form)
        {
            return new Log
            {
                Date = form.Date,
                Description = form.Description,
                LogType = form.LogType,
                Quantity = form.Quantity,
                CenterId = form.CenterId,
                LotId = form.LotId,
                VaccinInfoId = form.VaccinInfoId
            };
        }

        public Log MapModelToEntity(LogModel model)
        {
            return new Log
            {
                Id = model.Id,
                Date = model.Date,
                Description = model.Description,
                Quantity = model.Quantity,
                LogType = model.LogType,
                VaccinInfo = model.VaccinInfo != null ? VaccinInfoMapper.MapModelToEntity(model.VaccinInfo) : null,
                Lot = model.Lot != null ? LotMapper.MapModelToEntity(model.Lot) : null
            };
        }

        public LogForm MapModelToForm(LogModel model)
        {
            return new LogForm
            {
                Date = model.Date,
                Description = model.Description,
                Quantity = model.Quantity,
                LogType = model.LogType,
                CenterId = model.CenterId,
                VaccinInfoId = model.VaccinInfoId,
                LotId = model.VaccinInfoId
            };
        }
    }
}
