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
    public class CommunicationMapper : IMapper<Communication, CommunicationModel, CommunicationForm>
    {
        public CommunicationModel MapEntityToModel(Communication entity)
        {
            return new CommunicationModel
            {
                Id = entity.Id,
                Email = entity.Email,
                Phone = entity.Phone,
            };
        }

        public Communication MapFormToEntity(CommunicationForm form)
        {
            return new Communication
            {
                Email = form.Email,
                Phone = form.Phone,
            };
        }

        public Communication MapModelToEntity(CommunicationModel model)
        {
            return new Communication
            {
                Id = model.Id,
                Email = model.Email,
                Phone = model.Phone,
            };
        }

        public CommunicationForm MapModelToForm(CommunicationModel model)
        {
            return new CommunicationForm
            {
                Email = model.Email,
                Phone = model.Phone,
                PatientId = model.PatientId
            };
        }
    }
}
