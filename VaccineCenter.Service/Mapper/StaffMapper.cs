using ServiceASP.Bases;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;

namespace VaccineCenter.Services.Mapper
{
    public class StaffMapper : IMapper<Staff, StaffModel, StaffForm>
    {
        private AccountMapper Mapper = new AccountMapper();

        public StaffModel MapEntityToModel(Staff entity)
        {
            return new StaffModel
            {
                Id = entity.Id,
                Grade = entity.Grade,
                INAMI = entity.INAMI,
                Responsible = entity.Responsible,
                AccountId = entity.AccountId,
                
                Account = Mapper.MapEntityToModel(entity.Account)
            };
        }

        public Staff MapFormToEntity(StaffForm form)
        {
            return new Staff
            {
                Grade = form.Grade,
                INAMI = form.INAMI,
                AccountId = form.AccountId,
                WorkspaceId = form.WorkspaceId
            };
        }

        public Staff MapModelToEntity(StaffModel model)
        {
            return new Staff
            {
                Id = model.Id,
                Grade = model.Grade,
                INAMI = model.INAMI,
                Responsible = model.Responsible,
                AccountId = model.AccountId,
                Account = Mapper.MapModelToEntity(model.Account)
            };
        }

        public StaffForm MapModelToForm(StaffModel model)
        {
            return new StaffForm
            {
                Grade = model.Grade,
                INAMI = model.INAMI,
                AccountId = model.AccountId,
                WorkspaceId = model.WorkspaceId
            };
        }
    }
}
