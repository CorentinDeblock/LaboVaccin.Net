using Microsoft.EntityFrameworkCore;
using ServiceASP.Bases;
using System;
using System.Collections.Generic;
using System.Text;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;
using VaccineCenter.Services.Mapper;

namespace VaccineCenter.Services
{
    class StaffService : BaseServices<DataContext,Staff, StaffModel, StaffForm, int>
    {
        public StaffService(DataContext dc) : base(dc, new StaffMapper())
        {
        }

        protected override DbSet<Staff> GetDbSet(DataContext dc) => dc.Staffs;
    }
}
