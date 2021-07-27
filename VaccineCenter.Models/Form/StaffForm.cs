using System;
using System.Collections.Generic;
using System.Text;
using VaccineCenter.DAL.Enum;

namespace VaccineCenter.Models.Form
{
    public class StaffForm : AccountForm
    {
        public StaffGrade Grade { get; set; }
        public string INAMI { get; set; }
        public List<CenterModel> Centers { get; set; }

        public int CenterId { get; set; }
        public int AccountId { get; set; }
        public int WorkspaceId { get; set; }
    }
}
