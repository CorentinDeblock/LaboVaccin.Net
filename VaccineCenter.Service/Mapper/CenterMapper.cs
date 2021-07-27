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
    public class CenterMapper : IMapper<Center, CenterModel, CenterForm>
    {
        WorkspaceMapper WorkspaceMapper = new WorkspaceMapper();
        VaccinInfoMapper VaccinMapper = new VaccinInfoMapper();
        ScheduleMapper ScheduleMapper = new ScheduleMapper();
        LogMapper logMapper = new LogMapper();
        public CenterModel MapEntityToModel(Center entity)
        {
            List<WorkspaceModel> workspaces = entity.Workspace.Select(WorkspaceMapper.MapEntityToModel).ToList();

            return new CenterModel
            {
                Id = entity.Id,
                Address = entity.Address,
                Name = entity.Name,
                InActivityId = entity.InActivityId,
                Log = entity.Log.Select(logMapper.MapEntityToModel).ToList(),
                Schedule = entity.Schedule.Select(ScheduleMapper.MapEntityToModel).ToList(),
                Vaccin = entity.Vaccin.Select(VaccinMapper.MapEntityToModel).ToList(),
                Workspace = workspaces,
                Responsible = FindResponsible(workspaces[0])
            };
        }

        public Center MapFormToEntity(CenterForm form)
        {
            return new Center
            {
                Address = form.Address,
                Name = form.Name,
                InActivityId = form.InActivityId
            };
        }

        public Center MapModelToEntity(CenterModel model)
        {
            return new Center
            {
                Id = model.Id,
                Address = model.Address,
                Name = model.Name,
                InActivityId = model.InActivityId,
                Log = model.Log.Select(logMapper.MapModelToEntity).ToList(),
                Vaccin = model.Vaccin.Select(VaccinMapper.MapModelToEntity).ToList(),
                Schedule = model.Schedule.Select(ScheduleMapper.MapModelToEntity).ToList(),
                Workspace = model.Workspace.Select(WorkspaceMapper.MapModelToEntity).ToList()
            };
        }

        public CenterForm MapModelToForm(CenterModel model)
        {
            return new CenterForm
            {
                Address = model.Address,
                Name = model.Name
            };
        }

        private StaffModel FindResponsible(WorkspaceModel workspace)
        {
            foreach(StaffModel staff in workspace.Staffs)
            {
                if (staff.Responsible)
                    return staff;
            }
            return null;
        }
    }
}
