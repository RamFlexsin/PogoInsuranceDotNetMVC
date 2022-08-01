using Newtonsoft.Json;
using PogoInsurance.Models;
using System.Web.Mvc;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System;
using PogoApp_MVC.Utilities;
using System.Net.Http;
using Newtonsoft.Json.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PogoInsurance.Controllers
{
    public class IndexController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            // storing static data in model for UI 
            var indexViewModel = new IndexViewModel();
            indexViewModel.PrimaryZipcode = "46121";
            indexViewModel.TypeofWork = "Hello Business";
            return View(indexViewModel);
        }

        [HttpPost]
        public ActionResult Index(IndexViewModel form)
        {
            // getting previously stored data in IndeViewModel 
            Session["IndexModel"] = JsonConvert.SerializeObject(form);
            return RedirectToAction("coverageoptions");
        }
        [HttpGet]
        public ActionResult coverageoptions()
        {
            if (Session["IndexModel"] == null)
            {
                return RedirectToAction("Index");
            }
            // storing static data in model for UI 
            var indexViewModel = JsonConvert.DeserializeObject<IndexViewModel>(Session["IndexModel"].ToString());
            CommonDataList utility = new CommonDataList();
            indexViewModel.Lookingfor = utility.CoverageDataList();
            return View(indexViewModel);
        }

        [HttpPost]
        public ActionResult coverageoptionsPost(IndexViewModel idx)
        {
            if (Session["IndexModel"] == null)
            {
                return RedirectToAction("Index");
            }
            // getting previously stored data in IndeViewModel 
            var index = JsonConvert.DeserializeObject<IndexViewModel>(Session["IndexModel"].ToString());
            index.Lookingfor = idx.Lookingfor.Where(a => a.ChkAnswer == true).ToList();
            Session["IndexModel"] = JsonConvert.SerializeObject(index);
            return RedirectToAction("businessbasics");
        }

        [HttpGet]
        public ActionResult businessbasics()
        {
            if (Session["IndexModel"] == null)
            {
                return RedirectToAction("Index");
            }
            // storing static data in model for UI 
            var index = JsonConvert.DeserializeObject<IndexViewModel>(Session["IndexModel"].ToString());
            CommonDataList utility = new CommonDataList();
            index.BusinessStructure = utility.BusinessStructure();
            index.SelectedList = utility.BusinessStructure();
            index.SelectedBusiness = string.Empty;
            Session["IndexModel"] = JsonConvert.SerializeObject(index);
            return View(index);

        }

        [HttpPost]
        public ActionResult businessbasics(IndexViewModel idx)
        {
            if (Session["IndexModel"] == null)
            {
                return RedirectToAction("Index");
            }
            // getting previously stored data in IndeViewModel 
            var index = JsonConvert.DeserializeObject<IndexViewModel>(Session["IndexModel"].ToString());
            index.BusinessStructure = index.BusinessStructure.Where(a => a.Id == idx.SelectedBusiness).ToList();
            index.SelectedList = index.SelectedList.Where(a => a.Id == idx.SelectedItem).ToList();
            index.BusinessStartDate = idx.BusinessStartDate;
            index.EsimatedRevenue = idx.EsimatedRevenue;
            index.FEIN = idx.FEIN;
            index.HaveFEIN = idx.HaveFEIN;
            index.SSN = idx.SSN;
            index.AnnualPayroll = idx.AnnualPayroll;
            Session["IndexModel"] = JsonConvert.SerializeObject(index);
            return RedirectToAction("TheTeam");
        }

        [HttpGet]
        public ActionResult TheTeam()
        {
            if (Session["IndexModel"] == null)
            {
                return RedirectToAction("Index");
            }
            // storing static data in model for UI 
            var index = JsonConvert.DeserializeObject<IndexViewModel>(Session["IndexModel"].ToString());
            index.NumberofEmployees = 1;
            index.NumberofOwners = 1;
            Session["IndexModel"] = JsonConvert.SerializeObject(index);
            return View(index);
        }
        [HttpPost]
        public ActionResult TheTeam(IndexViewModel idx)
        {
            if (Session["IndexModel"] == null)
            {
                return RedirectToAction("Index");
            }
            // getting previously stored data in IndeViewModel 
            var index = JsonConvert.DeserializeObject<IndexViewModel>(Session["IndexModel"].ToString());
            index.NumberofEmployees = idx.NumberofEmployees;
            index.NumberofOwners = idx.NumberofOwners;
            index.SubcontractorsHire = idx.SubcontractorsHire;
            Session["IndexModel"] = JsonConvert.SerializeObject(index);
            return RedirectToAction("ContactInformation");
        }

        [HttpGet]
        public ActionResult ContactInformation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactInformation(IndexViewModel idx)
        {
            if (Session["IndexModel"] == null)
            {
                return RedirectToAction("Index");
            }
            // getting previously stored data in IndeViewModel 
            var index = JsonConvert.DeserializeObject<IndexViewModel>(Session["IndexModel"].ToString());
            var contact = new ContactDetails();
            contact.FirstName = idx.contactDetails.FirstName;
            contact.LastName = idx.contactDetails.LastName;
            contact.Phone = idx.contactDetails.Phone;
            contact.Email = idx.contactDetails.Email;

            index.contactDetails = contact;
            index.BusinessName = idx.BusinessName;
            index.IsOwner = idx.IsOwner;
            index.DBAName = idx.DBAName;
            index.IsUseDBAName = idx.IsUseDBAName;
            var indexdata = JsonConvert.SerializeObject(index);
            Session["IndexModel"] = indexdata;
            var utility = new Utility();
            //utility.WriteFile("IndexModel", indexdata);
            return RedirectToAction("Quote");
        }

        [HttpGet]
        public ActionResult Quote()
        {
            //// getting previously stored data in IndeViewModel 
            //var index = HttpContext.Session.GetObject<IndexViewModel>("IndexModel");

            // storing static data in model for UI 


            var libility = new GeneralLibility();
            libility.LibilityTitle = "General Liability";
            libility.LibilityLimits = "1,000,000";
            libility.LibilityId = "Lib001";
            libility.LibilityDescription = "We'll email you when this quote is ready. This will be a separate quote and separate purchase.";

            var businessdetail = new BusinessDetail();
            businessdetail.BusinessAddress = "Bake Shop 2501 Maplewood Rd. Richmond, VA 23223";
            businessdetail.BusinessId = "Bus001";
            businessdetail.BusinessName = "Hannah's Treats";
            businessdetail.Employees = "02";
            businessdetail.RatingPayroll = "5500";

            var quoteModel = new GetQuoteModel();
            quoteModel.Tenure = "per year";
            quoteModel.PolicyStartDate = System.DateTime.Today.Date.AddYears(1);
            quoteModel.BusinessDetail = businessdetail;
            quoteModel.GeneralLibility = libility;
            CommonDataList commonDataList = new CommonDataList();
            quoteModel.Compensations = commonDataList.CompensationList();
            quoteModel.SelectedCompensation = "";
            quoteModel.PolicyAmount = 1050.22M;
            // storing data in session for furthor use.
            Session["QuoteModel"] = JsonConvert.SerializeObject(quoteModel);
            return View(quoteModel);

        }
        [HttpPost]
        public ActionResult Quote(GetQuoteModel QM)
        {
            if (Session["QuoteModel"] == null)
            {
                return RedirectToAction("Index");
            }
            // getting previously stored data in QuoteModel 
            var quoteModel = JsonConvert.DeserializeObject<GetQuoteModel>(Session["QuoteModel"].ToString());
            quoteModel.Compensations = quoteModel.Compensations.Where(a => a.CompensationId == QM.SelectedCompensation).ToList();
            Session["QuoteModel"] = JsonConvert.SerializeObject(quoteModel);
            var utility = new Utility();
            //utility.WriteFile("QuoteModel", JsonConvert.SerializeObject(quoteModel));
            return RedirectToAction("BusinessLocation");
        }

        [HttpGet]
        public ActionResult BusinessLocation()
        {
            var index = JsonConvert.DeserializeObject<IndexViewModel>(Session["IndexModel"].ToString());
            var business = new BusinessLocationModel();
            business.PrimaryZipCode = index.PrimaryZipcode;
            CommonDataList commonDataList = new CommonDataList();
            ViewBag.StateList = commonDataList.StateList();
            return View(business);
        }

        [HttpPost]
        public ActionResult BusinessLocation(BusinessLocationModel businessLocation)
        {
            Session["BusinessLocationModel"] = JsonConvert.SerializeObject(businessLocation);
            var utility = new Utility();
            //utility.WriteFile("BusinessLocationModel", JsonConvert.SerializeObject(businessLocation));
            return RedirectToAction("WorkerComp");
        }

        [HttpGet]
        public ActionResult WorkerComp()
        {
            List<EmployersLiabilityLimits> limitList = new List<EmployersLiabilityLimits>
            {
                new EmployersLiabilityLimits{
                    LimitId="L001",
                    Limit="$100K/$100K/$100K",
                },
                new EmployersLiabilityLimits{
                    LimitId="L002",
                    Limit="$500K/$500K/$500K",
                },
                new EmployersLiabilityLimits{
                    LimitId="L003",
                    Limit="$1M/$1M/$1M",
                }
            };
            var workerCompCoverageModel = new WorkerCompCoverageModel();
            workerCompCoverageModel.EmployersLiabilityLimits = limitList;
            workerCompCoverageModel.CoveragePolicySelected = string.Empty;
            workerCompCoverageModel.EmployersLiabilityLimitSelected = string.Empty;
            Session["WorkerCompCoverageModel"] = JsonConvert.SerializeObject(workerCompCoverageModel);
            return View(workerCompCoverageModel);
        }

        [HttpPost]
        public ActionResult WorkerComp(WorkerCompCoverageModel worker)
        {
            if (Session["WorkerCompCoverageModel"] == null)
            {
                return RedirectToAction("Index");
            }
            var quoteModel = JsonConvert.DeserializeObject<WorkerCompCoverageModel>(Session["WorkerCompCoverageModel"].ToString());
            quoteModel.EmployersLiabilityLimits = quoteModel.EmployersLiabilityLimits.Where(a => a.LimitId == worker.EmployersLiabilityLimitSelected).ToList();
            quoteModel.EmployersLiabilityLimitSelected = worker.EmployersLiabilityLimitSelected;
            quoteModel.CoveragePolicySelected = worker.CoveragePolicySelected;
            Session["WorkerCompCoverageModel"] = JsonConvert.SerializeObject(quoteModel);
            var utility = new Utility();
            //utility.WriteFile("WorkerCompCoverageModel", JsonConvert.SerializeObject(quoteModel));

            return RedirectToAction("OwnersDetail");
        }
        [HttpGet]
        public ActionResult OwnersDetail()
        {
           
            var OwnersDetail = new OwnerDetailModel();
            var index = JsonConvert.DeserializeObject<IndexViewModel>(Session["IndexModel"].ToString());
            var businessLocationModel = JsonConvert.DeserializeObject<BusinessLocationModel>(Session["BusinessLocationModel"].ToString());
            var quoteModel = JsonConvert.DeserializeObject<GetQuoteModel>(Session["QuoteModel"].ToString());
            List<LocationList> locationLists = new List<LocationList>
            {
                new LocationList{LocationId=0,LocationName="Select"},
                new LocationList{LocationId=1,LocationName="Noida"},
                new LocationList{LocationId=2,LocationName="Delhi"},
                new LocationList{LocationId=3,LocationName="Gaziabad"},
                new LocationList{LocationId=4,LocationName="Agra"},
                new LocationList{LocationId=5,LocationName="Lucknow"},
                new LocationList{LocationId=6,LocationName="Meerut"},
            };
            if (index.BusinessStructure[0].Id == "LL")
            {
                List<TitleList> titles = new List<TitleList>
            {

                new TitleList{Value="Manager", Title= "Manager" },
                new TitleList{Value="Member", Title= "Member" },
            };
                OwnersDetail.Titles = titles;
            }
            else
            {
                List<TitleList> titles = new List<TitleList>
            {
                 new TitleList{Value="Owner", Title= "Owner" },
                new TitleList{Value="Manager", Title= "Manager" },
                new TitleList{Value="Member", Title= "Member" },
                new TitleList{Value="President", Title= "President" },
                new TitleList{Value="Vice President", Title= "Vice President" },
                new TitleList{Value="Secretary", Title= "Secretary" },
                new TitleList{Value="Treasurer", Title= "Treasurer" },
                new TitleList{Value="Other", Title= "Other" }
            };
                OwnersDetail.Titles = titles;
            }
            OwnersDetail.Titles.Insert(0, new TitleList { Value = "", Title = "Select" });
            List<OwnerDetail> ownerDetails = new List<OwnerDetail>();

            OwnerDetail owner = new OwnerDetail();
            if (index.IsOwner)
            {
                owner.FirstName = index.contactDetails.FirstName.ToString();
                owner.LastName = index.contactDetails.LastName.ToString();
                owner.Phone = index.contactDetails.Phone.ToString();
                owner.Email = index.contactDetails.Email.ToString();
                ownerDetails.Add(owner);
            }

            ViewBag.Owner = owner;
            OwnersDetail.OwnerDetails = ownerDetails;
            ViewBag.LocationList = locationLists;
            ViewBag.titles = OwnersDetail.Titles;
            OwnersDetail.LocationLists = locationLists;
            Utility utility = new Utility();
            var classcodes = utility.GetGetClassCodes(index.BusinessStructure.Select(z=>z.Id).FirstOrDefault(), quoteModel.Compensations.Select(s=>s.CompensationId).FirstOrDefault(), businessLocationModel.PrimaryState);
            OwnersDetail.TypeOfWork = classcodes.Data;
            classcodes.Data.Insert(0, new Datum { ClassCode = "", Description = "Select" });
            ViewBag.TypeOfWork = classcodes.Data;
            Session["OwnerDetailModel"] = JsonConvert.SerializeObject(OwnersDetail);

            return View(OwnersDetail);
        }

        [HttpPost]
        public ActionResult OwnersDetail(FormCollection form)
        {
           
            if (Session["OwnerDetailModel"] == null)
            {
                return RedirectToAction("Index");
            }
            List<OwnerDetail> ownerDetails = new List<OwnerDetail>();
            OwnerDetailModel ownerDetailModel = new OwnerDetailModel();
            var quoteModel = JsonConvert.DeserializeObject<OwnerDetailModel>(Session["OwnerDetailModel"].ToString());
            int totalOwner = int.Parse(form["hdnRows"].ToString());
            float totalpercentage = 0;
            for (int i = 1; i <= totalOwner; i++)
            {
                OwnerDetail owner = new OwnerDetail();
                owner.FirstName = form["FirstName" + i + ""].ToString();
                owner.LastName = form["LastName" + i + ""].ToString();
                owner.Phone = form["Phone" + i + ""].ToString();
                owner.Email = form["Email" + i + ""].ToString();
                owner.TypeOfWork = form["TypeOfWork" + i + ""].ToString();
                owner.Location = form["ddlLocation" + i + ""].ToString();
                owner.Title = form["ddlTitle" + i + ""].ToString();
                owner.OwnerPayroll = form["OwnerPayroll" + i + ""].ToString();
                owner.DateOfBirth = form["DateOfBirth" + i + ""].ToString();
                owner.LocationId = int.Parse(form["ddlLocation" + i + ""].ToString());
                owner.TitleId = form["ddlTitle" + i + ""].ToString();
                owner.PartnershipPercent = form["PartnershipPercent" + i + ""].ToString();
                totalpercentage += float.Parse(form["PartnershipPercent" + i + ""].ToString());
                ownerDetails.Add(owner);
            }
            //if(totalpercentage<100)
            //{
            //    ViewBag.TypeOfWork = quoteModel.TypeOfWork;
            //    return View(quoteModel); 
            //}
            ownerDetailModel.OwnerDetails = ownerDetails;
            quoteModel.OwnerDetails = ownerDetailModel.OwnerDetails;
            Session["OwnerDetailModel"] = JsonConvert.SerializeObject(quoteModel);

            var utility = new Utility();
            //utility.WriteFile("OwnerDetailModel", JsonConvert.SerializeObject(quoteModel));
            return RedirectToAction("Employees");
        }

        [HttpGet]
        public ActionResult Employees()
        {
            IEnumerable<LocationList> locationLists = new List<LocationList>
            {
                new LocationList{LocationId=1,LocationName="Noida"},
                new LocationList{LocationId=2,LocationName="Delhi"},
                new LocationList{LocationId=3,LocationName="Gaziabad"},
                new LocationList{LocationId=4,LocationName="Agra"},
                new LocationList{LocationId=5,LocationName="Lucknow"},
                new LocationList{LocationId=6,LocationName="Meerut"},
            };
            var employee = new EmployeeModel();
            employee.LocationLists = locationLists;
            ViewBag.LocationList = locationLists;
            List<JobType> jobTypes = new List<JobType> {
            new JobType{ DataId="J001",DataTitle="Clerical Office Employees (NOC)"},
            new JobType{ DataId="J002",DataTitle="Outside Sales"},
            new JobType{ DataId="J003",DataTitle="Other"},
            };
            employee.JobType = jobTypes;
            Session["EmployeeModel"] = JsonConvert.SerializeObject(employee);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Employees(EmployeeModel emp)
        {
            if (Session["EmployeeModel"] == null)
            {
                return RedirectToAction("Index");
            }
            var employee = JsonConvert.DeserializeObject<EmployeeModel>(Session["EmployeeModel"].ToString());
            employee.LocationLists = employee.LocationLists.Where(a => a.LocationId == emp.Location).ToList();
            employee.Duties = emp.Duties;
            employee.FullTimeEmployee = emp.FullTimeEmployee;
            employee.PartTimeEmployee = emp.PartTimeEmployee;
            employee.EmployeePayroll = emp.EmployeePayroll;
            employee.JobType = emp.JobType.Where(a => a.ChkAnswer == true).ToList();
            employee.TypeofWork = emp.TypeofWork;
            employee.Location = emp.Location;
            Session["EmployeeModel"] = JsonConvert.SerializeObject(employee);

            var utility = new Utility();
            //utility.WriteFile("EmployeeModel", JsonConvert.SerializeObject(employee));
            return RedirectToAction("AdditionalWorkers");
        }
        [HttpGet]
        public ActionResult AdditionalWorkers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdditionalWorkers(AdditionalWorkersModel additionalWorkers)
        {
            Session["AdditionalWorkersModel"] = JsonConvert.SerializeObject(additionalWorkers);

            var utility = new Utility();
            //utility.WriteFile("AdditionalWorkersModel", JsonConvert.SerializeObject(additionalWorkers));
            return RedirectToAction("Operations");
        }
        [HttpGet]
        public ActionResult Operations()
        {
            var quoteModel = JsonConvert.DeserializeObject<GetQuoteModel>(Session["QuoteModel"].ToString());

            return View();
        }
        [HttpPost]
        public ActionResult Operations(OperationsModel model)
        {

            var utility = new Utility();
            //utility.WriteFile("OperationsModel", JsonConvert.SerializeObject(model));
            Session["OperationsModel"] = JsonConvert.SerializeObject(model);
            return RedirectToAction("InsuranceHistory");
        }
        [HttpGet]
        public ActionResult InsuranceHistory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsuranceHistory(InsuranceHistoryModel model)
        {
            var utility = new Utility();
            //utility.WriteFile("InsuranceHistoryModel", JsonConvert.SerializeObject(model));
            Session["InsuranceHistoryModel"] = JsonConvert.SerializeObject(model);
            return RedirectToAction("CheckoutReview");
        }

        [HttpGet]
        public ActionResult CheckoutReview()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckoutReview(CheckoutReviewModel model)
        {
            Session["CheckoutReviewModel"] = JsonConvert.SerializeObject(model);
            return View();
        }

    }

}
