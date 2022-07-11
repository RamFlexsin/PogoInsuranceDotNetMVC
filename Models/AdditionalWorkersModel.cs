namespace PogoInsurance.Models
{
    public class AdditionalWorkersModel
    {
        public string Subcontractor { get; set; }
        public string Certificate { get; set; }
        public string UninsuredSubcontractors { get; set; }
        public string IsSeasonalEmployees { get; set; }
        public string IsDonatedLabor { get; set; }
        public string IsOwnerRelative { get; set; }
        public string IsOutAgeRange { get; set; }
        public string IsRequirePhysicals { get; set; }
    }

    public class OperationsModel
    {
        public string IsApplyYourBusiness { get; set; }
        public FromBUsiness FromBUsiness { get; set; }
        public string IsWorkUnderground { get; set; }
        public string IsRequirePhysicals { get; set; }

    }
    public class FromBUsiness
    {
        public bool IsHandicaps { get; set; }
        public bool IsTravelForBusiness { get; set; }
        public bool IsPredominantly { get; set; }
        public bool IsEngageinAdditionalBusiness { get; set; }
        public string ExplainBusiness { get; set; }
        public bool IsSafetyProgram { get; set; }
        public bool IsPerformOtherBusiness { get; set; }
        public string IsPolicyEffect { get; set; }
        public bool NoneOfAbove { get; set; }
    }
}
