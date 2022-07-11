using System;
using System.Collections.Generic;

namespace PogoInsurance.Models
{
    public class OwnerDetailModel
    {
        public string PartnershipPercent { get; set; }
        public IEnumerable<LocationList> LocationLists { get; set; }
        public List<OwnerDetail> OwnerDetails { get; set; }
    }
    public class LocationList
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
    public class OwnerDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TypeOfWork { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string OwnerPayroll { get; set; }
        public string DateOfBirth { get; set; }
        public int LocationId { get; set; }
        public int TitleId { get; set; }
    }
}
