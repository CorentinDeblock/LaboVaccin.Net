using Microsoft.EntityFrameworkCore;
using ServiceASP.Bases;
using ServiceASP.template;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;
using VaccineCenter.Services.Mapper;

namespace VaccineCenter.Services
{
    public class PatientService : IntServices<DataContext, Patient, PatientModel, PatientForm>
    {
        public PatientService(DataContext dc) : base(dc, new PatientMapper())
        {
        }

        protected override DbSet<Patient> GetDbSet(DataContext dc)
        {
            return dc.Patients;
        }
    }
}
