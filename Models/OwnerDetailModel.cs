using PogoApp_MVC.Utilities;
using System;
using System.Collections.Generic;

namespace PogoInsurance.Models
{
    public class OwnerDetailModel
    {
        public List<LocationList> LocationLists { get; set; }
        public List<TitleList> Titles { get; set; }
        public List<Datum> TypeOfWork { get; set; }
        public List<OwnerDetail> OwnerDetails { get; set; }
    }
    public class LocationList
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
   
    public class TitleList
    {
        public string Value { get; set; }
        public string Title { get; set; }
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
        public string TitleId { get; set; }
        public string PartnershipPercent { get; set; }
    }
}
