using System.Collections.Generic;

namespace PogoInsurance.Models
{
    public class QuoteModel
    {
        public int ApplicationID { get; set; }
        public bool IsPartialQuote { get; set; }
        public string StateCode { get; set; }
        public string ProductCode { get; set; }
        public string BusinessEntity { get; set; }
        public string Limit { get; set; }
        public string InsuredCompanyName { get; set; }
        public string EffectiveDate { get; set; }
        public int YearsInBusiness { get; set; }
        public string DescriptionofOperation { get; set; }
        public bool HasSubcontractor { get; set; }
        public int NumberOfEmployees { get; set; }
        public int NumberOfOwners { get; set; }
        public string FEIN { get; set; }
        public bool IsFein { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Owner> Owners { get; set; }
        public List<Questionanswer> QuestionAnswers { get; set; }
    }

    public class Address
    {
        public int AddressIndex { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string Zip { get; set; }
        public int AddressTypeID { get; set; }
        public bool IsPrimaryAddress { get; set; }
    }

    public class Owner
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClassCode { get; set; }
        public string DateofBirth { get; set; }
        public string SSN { get; set; }
        public bool IsIncluded { get; set; }
        public string Email { get; set; }
        public string TitlePosition { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string BeneficiaryFirstName { get; set; }
        public string BeneficiaryLastName { get; set; }
        public string BeneficiaryRelationship { get; set; }
        public string OwnershipPercentage { get; set; }
        public bool AddAccident { get; set; }
        public int AddressIndex { get; set; }
        public int OwnerPayroll { get; set; }
    }

    public class Questionanswer
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public string Explanation { get; set; }
    }

}
