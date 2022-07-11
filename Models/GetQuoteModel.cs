using System;
using System.Collections.Generic;

namespace PogoInsurance.Models
{
    public class GetQuoteModel
    {
        #region Get Quote View Properties
        public string SelectedCompensation { get; set; }
        public List<Compensation> Compensations { get; set; }
        public GeneralLibility GeneralLibility { get; set; }
        public BusinessDetail BusinessDetail { get; set; }
        public decimal PolicyAmount { get; set; }
        public string Tenure { get; set; }
        public DateTime PolicyStartDate { get; set; }

        #endregion
    }
    public class Compensation
    {
        public string CompensationId { get; set; }
        public string CompensationTitle { get; set; }
        public string CompensationDescription { get; set; }
        public string CompensationLimits { get; set; }
        public decimal CompensationAmount { get; set; }
    }
    public class GeneralLibility
    {
        public string LibilityId { get; set; }
        public string LibilityTitle { get; set; }
        public string LibilityDescription { get; set; }
        public string LibilityLimits { get; set; }
    }
    public class BusinessDetail
    {
        public string BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessAddress { get; set; }
        public string Employees { get; set; }
        public string RatingPayroll { get; set; }
    }

}
