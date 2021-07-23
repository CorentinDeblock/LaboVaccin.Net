using Microsoft.EntityFrameworkCore;
using ServiceASP.Bases;
using ServiceASP.template;
using System;
using System.Collections.Generic;
using System.Text;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;
using VaccineCenter.Services.Mapper;

namespace VaccineCenter.Services
{
    public class StaffService : IntServices<DataContext, Staff, StaffModel, StaffForm>
    {
        public StaffService(DataContext dc) : base(dc, new StaffMapper())
        {
        }

        protected override DbSet<Staff> GetDbSet(DataContext dc) => dc.Staffs;
    }
}
