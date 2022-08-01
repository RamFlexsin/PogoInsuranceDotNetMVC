using PogoInsurance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PogoApp_MVC.Utilities
{
    public class CommonDataList
    {
        public List<CoverageOptions> CoverageDataList()
        {
            List<CoverageOptions> coverageOptions = new List<CoverageOptions>
            {
                new CoverageOptions
                {
                    DataId = "Cov01",
                    ChkAnswer = false,
                    DataTitle = "General Liability",
                    Data = "Protects your business against third-party bodily injury, property damage, and claims of libel, slander, and copyright infringement."
                },
                new CoverageOptions
                {
                    DataId = "Cov02",
                    ChkAnswer = false,
                    DataTitle = "Business Owner's Policy",
                    Data = "BOPs combine business property insurance with your general liability policy to save you money."
                },
                new CoverageOptions
                {
                    DataId = "Cov03",
                    ChkAnswer = false,
                    DataTitle = "Workers' Compensation",
                    Data = "Helps cover medical and loss of income benefits if you or one of your employees gets a work-related injury or illness. It can also help if they decide to sue."
                },
                new CoverageOptions
                {
                    DataId = "Cov04",
                    ChkAnswer = false,
                    DataTitle = "Professional Liability (E & O)",
                    Data = "Helps protect you from claims of professional negligence, even if you've done nothing wrong."
                },
                new CoverageOptions
                {
                    DataId = "Cov05",
                    ChkAnswer = false,
                    DataTitle = "Business Auto Liability",
                    Data = "Helps protect you from claims of professional negligence, even if you've done nothing wrong."
                },
                new CoverageOptions
                {
                    DataId = "Cov06",
                    ChkAnswer = false,
                    DataTitle = "Business Property",
                    Data = "Covers the place where you do business- whether you own it, lease it, or work out of your home. Also covers personal property (like tools and equipment) used in your business."
                },
                new CoverageOptions
                {
                    DataId = "Cov07",
                    ChkAnswer = false,
                    DataTitle = "Cyber Liability",
                    Data = "Protects your business from data breaches, leaked personal information, and identity theft when you handle sensitive customer data (even credit card information)."
                },
                new CoverageOptions
                {
                    DataId = "Cov08",
                    ChkAnswer = false,
                    DataTitle = "Inland Marine",
                    Data = "Helps cover business property, assets and equipment while it's away from you business premise, in transit, or at temporary storage locations."
                },
                new CoverageOptions
                {
                    DataId = "Cov09",
                    ChkAnswer = false,
                    DataTitle = "Umbrella (Excess Liability)",
                    Data = "Extra liability insurance that protects you from major claims and lawsuits. It gives you coverage above the limits of your other insurance policies."
                },
                new CoverageOptions
                {
                    DataId = "Cov10",
                    ChkAnswer = false,
                    DataTitle = "Other / I'm not sure",
                    Data = "We can help you find the right coverage."
                }
            };
            return coverageOptions;
        }
        public List<BusinessStructure> BusinessStructure()
        {
            List<BusinessStructure> businessStructure = new List<BusinessStructure>();
            businessStructure.Add(new BusinessStructure { Id = "IN", Name = "Sole Proprietor (Individual)", });
            businessStructure.Add(new BusinessStructure { Id = "PT", Name = "Partnership", });
            businessStructure.Add(new BusinessStructure { Id = "LL", Name = "Limited Liability Company (LLC)", });
            businessStructure.Add(new BusinessStructure { Id = "CP", Name = "Corporation (S Corp)", });
            businessStructure.Add(new BusinessStructure { Id = "LP", Name = "Limited Partnership", });
            businessStructure.Add(new BusinessStructure { Id = "OT", Name = "Other", });
            return businessStructure;
        }
        public List<Compensation> CompensationList()
        {
            List<Compensation> compensationList = new List<Compensation>
            {
                new Compensation
                {
                    CompensationId="SLX",
                    CompensationTitle="Solo X",
                    CompensationDescription="Owner(s) excluded from WC coverage   |   Accident policy included",
                    CompensationLimits="100k/$500k/$100k",
                    CompensationAmount=1052.22M
                },
                new Compensation
                {
                    CompensationId="SLI",
                    CompensationTitle="Solo I",
                    CompensationDescription="Owner(s) included for workers' comp coverage",
                    CompensationLimits="100k/$500k/$100k",
                    CompensationAmount=1845.44M
                },
                //new Compensation
                //{
                //    CompensationId="EMP",
                //    CompensationTitle="Employers",
                //    CompensationDescription="Workers' comp policy | Financing Options",
                //    CompensationLimits="100k/$500k/$100k",
                //    CompensationAmount=1845.44M
                //},
                new Compensation
                {
                    CompensationId="PLS",
                    CompensationTitle="Plus",
                    CompensationDescription="Workers' comp policy | Financing Options",
                    CompensationLimits="100k/$500k/$100k",
                    CompensationAmount=1845.44M
                }

            };
            return compensationList;
        }

        public List<StateList> StateList()
        {
            List<StateList> stateLists = new List<StateList>
            {
                new StateList { StateCode = "", StateName = "Select" }
               ,new StateList { StateCode = "AL", StateName = "Alabama" }
               ,new StateList { StateCode = "AK", StateName = "Alaska" }
               ,new StateList { StateCode = "AZ", StateName = "Arizona" }
               ,new StateList { StateCode = "AR", StateName = "Arkansas" }
               ,new StateList { StateCode = "CA", StateName = "California" }
               ,new StateList { StateCode = "CO", StateName = "Colorado" }
               ,new StateList { StateCode = "CT", StateName = "Connecticut" }
               ,new StateList { StateCode = "DE", StateName = "Delaware" }
               ,new StateList { StateCode = "DC", StateName = "District of Columbia" }
               ,new StateList { StateCode = "FL", StateName = "Florida" }
               ,new StateList { StateCode = "GA", StateName = "Georgia" }
               ,new StateList { StateCode = "HI", StateName = "Hawaii" }
               ,new StateList { StateCode = "ID", StateName = "Idaho" }
               ,new StateList { StateCode = "IL", StateName = "Illinois" }
               ,new StateList { StateCode = "IN", StateName = "Indiana" }
               ,new StateList { StateCode = "IA", StateName = "Iowa" }
               ,new StateList { StateCode = "KS", StateName = "Kansas" }
               ,new StateList { StateCode = "KY", StateName = "Kentucky" }
               ,new StateList { StateCode = "LA", StateName = "Louisiana" }
               ,new StateList { StateCode = "ME", StateName = "Maine" }
               ,new StateList { StateCode = "MD", StateName = "Maryland" }
               ,new StateList { StateCode = "MA", StateName = "Massachusetts" }
               ,new StateList { StateCode = "MI", StateName = "Michigan" }
               ,new StateList { StateCode = "MN", StateName = "Minnesota" }
               ,new StateList { StateCode = "MS", StateName = "Mississippi" }
               ,new StateList { StateCode = "MO", StateName = "Missouri" }
               ,new StateList { StateCode = "MT", StateName = "Montana" }
               ,new StateList { StateCode = "NE", StateName = "Nebraska" }
               ,new StateList { StateCode = "NV", StateName = "Nevada" }
               ,new StateList { StateCode = "NH", StateName = "New Hampshire" }
               ,new StateList { StateCode = "NJ", StateName = "New Jersey" }
               ,new StateList { StateCode = "NM", StateName = "New Mexico" }
               ,new StateList { StateCode = "NY", StateName = "New York" }
               ,new StateList { StateCode = "NC", StateName = "North Carolina" }
               ,new StateList { StateCode = "ND", StateName = "North Dakota" }
               ,new StateList { StateCode = "OH", StateName = "Ohio" }
               ,new StateList { StateCode = "OK", StateName = "Oklahoma" }
               ,new StateList { StateCode = "OR", StateName = "Oregon" }
               ,new StateList { StateCode = "PA", StateName = "Pennsylvania" }
               ,new StateList { StateCode = "RI", StateName = "Rhode Island" }
               ,new StateList { StateCode = "SC", StateName = "South Carolina" }
               ,new StateList { StateCode = "SD", StateName = "South Dakota" }
               ,new StateList { StateCode = "TN", StateName = "Tennessee" }
               ,new StateList { StateCode = "TX", StateName = "Texas" }
               ,new StateList { StateCode = "UT", StateName = "Utah" }
               ,new StateList { StateCode = "VT", StateName = "Vermont" }
               ,new StateList { StateCode = "VA", StateName = "Virginia" }
               ,new StateList { StateCode = "WA", StateName = "Washington" }
               ,new StateList { StateCode = "WV", StateName = "West Virginia" }
               ,new StateList { StateCode = "WI", StateName = "Wisconsin" }
               ,new StateList { StateCode = "WY", StateName = "Wyoming" }
            };
            return stateLists;
        }
    }
    public class StateList
    {
        public string StateCode { get; set; }
        public string StateName { get; set; }
    }
}