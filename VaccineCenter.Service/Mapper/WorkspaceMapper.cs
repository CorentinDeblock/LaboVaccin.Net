using ServiceASP.Bases;
using System.Linq;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;

namespace VaccineCenter.Services.Mapper
{
    public class WorkspaceMapper : IMapper<Workspace, WorkspaceModel, WorkspaceForm>
    {
        public WorkspaceModel MapEntityToModel(Workspace entity)
        {
            return new WorkspaceModel
            {
                Id = entity.Id,
                Address = entity.Address,
                Name = entity.Name,
                CenterId = entity.CenterId,
                Staffs = entity.Staffs != null ? entity.Staffs.Select(new StaffMapper().MapEntityToModel).ToList() : null
            };
        }

        public Workspace MapFormToEntity(WorkspaceForm form)
        {
            return new Workspace
            {
                Address = form.Address,
                Name = form.Name
            };
        }

        public Workspace MapModelToEntity(WorkspaceModel model)
        {
            return new Workspace
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                CenterId = model.CenterId
            };
        }

        public WorkspaceForm MapModelToForm(WorkspaceModel model)
        {
            return new WorkspaceForm
            {
                Address = model.Address,
                Name = model.Name,
                ResponsibleId = model.ResponsibleId
            };
        }
    }
}