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
    public class VaccinForm { }
    public class VaccinMapper : IMapper<Vaccin, VaccinModel, VaccinForm>
    {
        public VaccinModel MapEntityToModel(Vaccin entity)
        {
            return new VaccinModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Vaccin MapFormToEntity(VaccinForm form)
        {
            throw new NotImplementedException();
        }

        public Vaccin MapModelToEntity(VaccinModel model)
        {
            return new Vaccin
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public VaccinForm MapModelToForm(VaccinModel model)
        {
            throw new NotImplementedException();
        }
    }
}
