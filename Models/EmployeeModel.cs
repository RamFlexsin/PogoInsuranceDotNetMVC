using System.Collections.Generic;

namespace PogoInsurance.Models
{
    public class EmployeeModel
    {
        public string TypeofWork { get; set; }
        public string Duties { get; set; }
        public int Location { get; set; }
        public int FullTimeEmployee { get; set; }
        public int PartTimeEmployee { get; set; }
        public string EmployeePayroll { get; set; }
        public List<JobType> JobType { get; set; }
        public IEnumerable<LocationList> LocationLists { get; set; }
    }
    public class JobType
    {
        public string DataTitle { get; set; }
        public string DataId { get; set; }
        public bool ChkAnswer { get; set; }
    }
}
