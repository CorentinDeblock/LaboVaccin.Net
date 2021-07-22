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
                AccountId = entity.AccountId,
                Account = Mapper.MapEntityToModel(entity.Account)
            };
        }

        public Staff MapFormToEntity(StaffForm form)
        {
            return new Staff
            {
                Grade = form.Grade,
                INAMI = form.INAMI
            };
        }

        public StaffForm MapModelToForm(StaffModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
