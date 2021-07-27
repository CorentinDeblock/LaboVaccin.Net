using ServiceASP.Bases;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;

namespace VaccineCenter.Services.Mapper
{
    public class InActivityMapper : IMapper<InActivity, InActivityModel, InActivityForm>
    {
        public InActivityModel MapEntityToModel(InActivity entity)
        {
            return new InActivityModel
            {
                Id = entity.Id,
                Opening = entity.Opening,
                Closing = entity.Closing
            };
        }

        public InActivity MapFormToEntity(InActivityForm form)
        {
            return new InActivity
            {
                Opening = form.Opening,
                Closing = form.Closing
            };
        }

        public InActivity MapModelToEntity(InActivityModel model)
        {
            return new InActivity
            {
                Id = model.Id,
                Opening = model.Opening,
                Closing = model.Closing
            };
        }

        public InActivityForm MapModelToForm(InActivityModel model)
        {
            return new InActivityForm
            {
                Opening = model.Opening,
                Closing = model.Closing
            };
        }
    }
}