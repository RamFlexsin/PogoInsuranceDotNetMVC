namespace PogoInsurance.Models
{
    public class BusinessLocationModel
    {
        public string PrimaryStreet { get; set; }
        public string PrimaryCity { get; set; }
        public string PrimaryState { get; set; }
        public string PrimaryZipCode { get; set; }
        public bool IsMaillingAddress { get; set; }
        public string MailingStreet { get; set; }
        public string MailingCity { get; set; }
        public string MailingState { get; set; }
        public string MailingZipCode { get; set; }
    }
   
}
