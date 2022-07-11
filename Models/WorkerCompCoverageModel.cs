using System.Collections.Generic;

namespace PogoInsurance.Models
{
    public class WorkerCompCoverageModel
    {
        public string EmployersLiabilityLimitSelected { get; set; }
        public List<EmployersLiabilityLimits> EmployersLiabilityLimits { get; set; }
        public string CoveragePolicySelected { get; set; }

    }
    public class EmployersLiabilityLimits
    {
        public string LimitId { get; set; }
        public string Limit { get; set; }
    }
}
