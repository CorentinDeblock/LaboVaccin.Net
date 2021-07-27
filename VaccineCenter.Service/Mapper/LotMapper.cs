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
    public class LotMapper : IMapper<Lot, LotModel, LotForm>
    {
        public LotModel MapEntityToModel(Lot entity)
        {
            return new LotModel
            {
                Id = entity.Id,
                LotId = entity.LotId,
                VaccinId = entity.VaccinId
            };
        }

        public Lot MapFormToEntity(LotForm form)
        {
            return new Lot
            {
                LotId = form.LotId,
                VaccinId = form.VaccinId
            };
        }

        public Lot MapModelToEntity(LotModel model)
        {
            return new Lot
            {
                Id = model.Id,
                LotId = model.LotId,
                VaccinId = model.VaccinId
            };
        }

        public LotForm MapModelToForm(LotModel model)
        {
            return new LotForm
            {
                LotId = model.LotId,
                VaccinId = model.VaccinId
            };
        }
    }
}
