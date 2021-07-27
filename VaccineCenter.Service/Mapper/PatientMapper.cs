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
    public class PatientMapper : IMapper<Patient, PatientModel, PatientForm>
    {
        private AccountMapper AccountMapper = new AccountMapper();
        public PatientModel MapEntityToModel(Patient entity)
        {
            return new PatientModel
            {
                Id = entity.Id,
                Address = entity.Address,
                BirthDate = entity.BirthDate,
                MedicationIndications = entity.MedicationIndications,
                NationalRegistrationNumber = entity.NationalRegistrationNumber,
                CommunicationId = entity.CommunicationId,
                AccountId = entity.AccountId,
                Account = AccountMapper.MapEntityToModel(entity.Account)
            };
        }

        public Patient MapFormToEntity(PatientForm form)
        {
            return new Patient
            {
                Address = form.Address,
                BirthDate = form.BirthDate,
                MedicationIndications = form.MedicationIndications,
                NationalRegistrationNumber = form.NationalRegistrationNumber,
                CommunicationId = form.CommunicationId,
                AccountId = form.AccountId
            };
        }

        public Patient MapModelToEntity(PatientModel model)
        {
            return new Patient
            {
                Id = model.Id,
                Address = model.Address,
                BirthDate = model.BirthDate,
                MedicationIndications = model.MedicationIndications,
                NationalRegistrationNumber = model.NationalRegistrationNumber,
                CommunicationId = model.CommunicationId,
                AccountId = model.AccountId
            };
        }

        public PatientForm MapModelToForm(PatientModel model)
        {
            return new PatientForm
            {
                Address = model.Address,
                BirthDate = model.BirthDate,
                MedicationIndications = model.MedicationIndications,
                NationalRegistrationNumber = model.NationalRegistrationNumber,
                CommunicationId = model.CommunicationId,
                AccountId = model.AccountId
            };
        }
    }
}
