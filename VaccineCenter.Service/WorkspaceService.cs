using Microsoft.EntityFrameworkCore;
using ServiceASP.Bases;
using ServiceASP.template;
using System.Linq;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;
using VaccineCenter.Services.Mapper;

namespace VaccineCenter.Services
{
    public class WorkspaceService : IntServices<DataContext, Workspace, WorkspaceModel, WorkspaceForm>
    {
        public WorkspaceService(DataContext dc) : base(dc, new WorkspaceMapper())
        {
        }

        protected override DbSet<Workspace> GetDbSet(DataContext dc) => dc.Workspaces;
    }
}
