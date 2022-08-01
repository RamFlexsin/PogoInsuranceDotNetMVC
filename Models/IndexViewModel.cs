using System;
using System.Collections.Generic;

namespace PogoInsurance.Models
{
    public class IndexViewModel
    {
        #region Index View Properties
        public string PrimaryZipcode { get; set; }
        public string TypeofWork { get; set; }
        #endregion

        #region Coverage-Option View Properties
        public List<CoverageOptions> Lookingfor { get; set; }
        #endregion

        #region Business Basic View Properties
        public string SelectedBusiness { get; set; }
        public string SelectedItem { get; set; }
        public List<BusinessStructure> SelectedList { get; set; }
        public List<BusinessStructure> BusinessStructure { get; set; }
        public DateTime? BusinessStartDate { get; set; }
        public int IndustryExperience { get; set; }
        public string FEIN { get; set; }
        public string HaveFEIN { get; set; }
        public string SSN { get; set; }
        public decimal EsimatedRevenue { get; set; }
        public decimal AnnualPayroll { get; set; }
        #endregion

        #region The Team View Properties
        public int NumberofOwners{ get; set; }
        public int NumberofEmployees { get; set; }
        public string SubcontractorsHire { get; set; }
        #endregion

        #region Contact Information View Properties
        public ContactDetails contactDetails { get; set; }  
        public bool IsOwner { get; set; }
        public string BusinessName { get; set; }
        public bool IsUseDBAName { get; set; }
        public string DBAName { get; set; }
        #endregion

    }

    public class CoverageOptions
    {
        public string Data { get; set; }
        public string DataTitle { get; set; }
        public string DataId { get; set; }
        public bool ChkAnswer{ get; set; }
    }
    public class BusinessStructure
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class ContactDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

}
