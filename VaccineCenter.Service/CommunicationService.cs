using Microsoft.EntityFrameworkCore;
using ServiceASP.Bases;
using ServiceASP.template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;
using VaccineCenter.Services.Mapper;

namespace VaccineCenter.Services
{
    public class CommunicationService : IntServices<DataContext, Communication, CommunicationModel, CommunicationForm>
    {
        public CommunicationService(DataContext dc) : base(dc, new CommunicationMapper())
        {
        }

        protected override DbSet<Communication> GetDbSet(DataContext dc)
        {
            return dc.Communications;
        }
    }
}
