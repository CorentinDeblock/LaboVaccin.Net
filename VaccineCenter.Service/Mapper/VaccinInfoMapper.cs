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
    public class VaccinInfoMapper : IMapper<VaccinInfo, VaccinInfoModel, VaccinInfoForm>
    {
        private VaccinMapper vaccinMapper = new VaccinMapper();
        public VaccinInfoModel MapEntityToModel(VaccinInfo entity)
        {
            return new VaccinInfoModel
            {
                Id = entity.Id,
                QuantityAvailable = entity.QuantityAvailable,
                VaccinId = entity.VaccinId,
                Vaccin = vaccinMapper.MapEntityToModel(entity.Vaccin)
            };
        }

        public VaccinInfo MapFormToEntity(VaccinInfoForm form)
        {
            throw new NotImplementedException();
        }

        public VaccinInfo MapModelToEntity(VaccinInfoModel model)
        {
            return new VaccinInfo
            {
                Id = model.Id,
                QuantityAvailable = model.QuantityAvailable,
                VaccinId = model.VaccinId,
                Vaccin = vaccinMapper.MapModelToEntity(model.Vaccin)
            };
        }

        public VaccinInfoForm MapModelToForm(VaccinInfoModel model)
        {
            throw new NotImplementedException();
        }
    }
}
