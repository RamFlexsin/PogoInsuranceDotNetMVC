using Newtonsoft.Json;
using PogoInsurance.Models;
using System.Web.Mvc;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PogoInsurance.Controllers
{
    public class IndexController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            // storing static data in model for UI 
            var indexViewModel = new IndexViewModel();
            indexViewModel.PrimaryZipcode=46121;
            indexViewModel.TypeofWork="Hello Business";
            return View(indexViewModel);
        }

        [HttpPost]
        public ActionResult Index(IndexViewModel form)
        {
            // getting previously stored data in IndeViewModel 
            Session["IndexModel"]=JsonConvert.SerializeObject(form);
            return RedirectToAction("coverageoptions");
        }
        [HttpGet]
        public ActionResult coverageoptions()
        {
            if(Session["IndexModel"]==null)
            {
                return RedirectToAction("Index");
            }
            // storing static data in model for UI 
            var indexViewModel = JsonConvert.DeserializeObject<IndexViewModel>(Session["IndexModel"].ToString());
            List<CoverageOptions> coverageOptions = new List<CoverageOptions>();
            for (int i = 0; i <= 3; i++)
            {
                var list = new CoverageOptions
                {
                    DataId="Chk"+i,
                    ChkAnswer=false,
                    DataTitle="General Liability",
                    Data="Protects your business against third-party bodily injury, property damage, and claims of libel, slander, and copyright infringement."
                };
                coverageOptions.Add(list);
            }
            indexViewModel.Lookingfor=coverageOptions;
            return View(indexViewModel);
        }

        [HttpPost]
        public ActionResult coverageoptionsPost(IndexViewModel idx)
        {
            if (Session["IndexModel"]==null)
            {
                return RedirectToAction("Index");
            }
            // getting previously stored data in IndeViewModel 
            var index = JsonConvert.DeserializeObject<IndexViewModel>(Session["IndexModel"].ToString());
            index.Lookingfor=idx.Lookingfor.Where(a => a.ChkAnswer==true).ToList();
            Session["IndexModel"]= JsonConvert.SerializeObject(index);
            return RedirectToAction("businessbasics");
        }

        [HttpGet]
        public ActionResult businessbasics()
        {
            if (Session["IndexModel"]==null)
            {
                return RedirectToAction("Index");
            }
            // storing static data in model for UI 
            var index = JsonConvert.DeserializeObject<IndexViewModel>(Session["IndexModel"].ToString());
            List<BusinessStructure> businessStructure = new List<BusinessStructure>();
            businessStructure.Add(new BusinessStructure { Id="radio1", Name="Sole Proprietor (Individual)", });
            businessStructure.Add(new BusinessStructure { Id="radio2", Name="Partnership", });
            businessStructure.Add(new BusinessStructure { Id="radio3", Name="Limited Liability Company (LLC)", });
            businessStructure.Add(new BusinessStructure { Id="radio4", Name="Corporation (S Corp)", });
            index.BusinessStructure=businessStructure;
            index.SelectedList=businessStructure;
            index.SelectedBusiness=string.Empty;
            Session["IndexModel"]= JsonConvert.SerializeObject(index);
            return View(index);

        }

        [HttpPost]
        public ActionResult businessbasics(IndexViewModel idx)
        {
            if (Session["IndexModel"]==null)
            {
                return RedirectToAction("Index");
            }
            // getting previously stored data in IndeViewModel 
            var index = JsonConvert.DeserializeObject<IndexViewModel>(Session["IndexModel"].ToString());
            index.BusinessStructure=index.BusinessStructure.Where(a => a.Id==idx.SelectedBusiness).ToList();
            index.SelectedList=index.SelectedList.Where(a => a.Id==idx.SelectedItem).ToList();
            index.BusinessStartDate=idx.BusinessStartDate;
            index.EsimatedRevenue=idx.EsimatedRevenue;
            index.FEIN=idx.FEIN;
            Session["IndexModel"]= JsonConvert.SerializeObject(index);
            return RedirectToAction("TheTeam");
        }

        [HttpGet]
        public ActionResult TheTeam()
        {
            if (Session["IndexModel"]==null)
            {
                return RedirectToAction("Index");
            }
            // storing static data in model for UI 
            var index = JsonConvert.DeserializeObject<IndexViewModel>(Session["IndexModel"].ToString());
            index.NumberofEmployees=2;
            index.NumberofOwners=1;
            Session["IndexModel"]= JsonConvert.SerializeObject(index);
            return View(index);
        }
        [HttpPost]
        public ActionResult TheTeam(IndexViewModel idx)
        {
            if (Session["IndexModel"]==null)
            {
                return RedirectToAction("Index");
            }
            // getting previously stored data in IndeViewModel 
            var index = JsonConvert.DeserializeObject<IndexViewModel>(Session["IndexModel"].ToString());
            index.NumberofEmployees=idx.NumberofEmployees;
            index.NumberofOwners=idx.NumberofOwners;
            index.SubcontractorsHire=idx.SubcontractorsHire;
            Session["IndexModel"]= JsonConvert.SerializeObject(index);
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
            if (Session["IndexModel"]==null)
            {
                return RedirectToAction("Index");
            }
            // getting previously stored data in IndeViewModel 
            var index = JsonConvert.DeserializeObject<IndexViewModel>(Session["IndexModel"].ToString());
            var contact = new ContactDetails();
            contact.FirstName=idx.contactDetails.FirstName;
            contact.LastName=idx.contactDetails.LastName;
            contact.Phone=idx.contactDetails.Phone;
            contact.Email=idx.contactDetails.Email;

            index.contactDetails=contact;
            index.BusinessName=idx.BusinessName;
            index.IsOwner=idx.IsOwner;
            index.DBAName=idx.DBAName;
            index.IsUseDBAName=idx.IsUseDBAName;

            Session["IndexModel"]= JsonConvert.SerializeObject(index);
            return RedirectToAction("Quote");
        }

        [HttpGet]
        public ActionResult Quote()
        {
            //// getting previously stored data in IndeViewModel 
            //var index = HttpContext.Session.GetObject<IndexViewModel>("IndexModel");

            // storing static data in model for UI 
            List<Compensation> compensationList = new List<Compensation>
            {
                new Compensation
                {
                    CompensationId="C0001",
                    CompensationTitle="Solo X",
                    CompensationDescription="Owner(s) excluded from WC coverage   |   Accident policy included",
                    CompensationLimits="100k/$500k/$100k",
                    CompensationAmount=1052.22M
                },
                new Compensation
                {
                    CompensationId="C0002",
                    CompensationTitle="Solo I",
                    CompensationDescription="Owner(s) included for workers' comp coverage",
                    CompensationLimits="100k/$500k/$100k",
                    CompensationAmount=1845.44M
                },
                new Compensation
                {
                    CompensationId="C0003",
                    CompensationTitle="Employers",
                    CompensationDescription="Workers' comp policy | Financing Options",
                    CompensationLimits="100k/$500k/$100k",
                    CompensationAmount=1845.44M
                }

            };

            var libility = new GeneralLibility();
            libility.LibilityTitle="General Liability";
            libility.LibilityLimits="1,000,000";
            libility.LibilityId="Lib001";
            libility.LibilityDescription="We'll email you when this quote is ready. This will be a separate quote and separate purchase.";

            var businessdetail = new BusinessDetail();
            businessdetail.BusinessAddress="Bake Shop 2501 Maplewood Rd. Richmond, VA 23223";
            businessdetail.BusinessId="Bus001";
            businessdetail.BusinessName="Hannah's Treats";
            businessdetail.Employees="02";
            businessdetail.RatingPayroll="5500";

            var quoteModel = new GetQuoteModel();
            quoteModel.Tenure="per year";
            quoteModel.PolicyStartDate=System.DateTime.Today.Date.AddYears(1);
            quoteModel.BusinessDetail=businessdetail;
            quoteModel.GeneralLibility=libility;
            quoteModel.Compensations=compensationList;
            quoteModel.SelectedCompensation="";
            quoteModel.PolicyAmount=1050.22M;
            // storing data in session for furthor use.
            Session["QuoteModel"]= JsonConvert.SerializeObject(quoteModel);
            return View(quoteModel);

        }
        [HttpPost]
        public ActionResult Quote(GetQuoteModel QM)
        {
            if (Session["QuoteModel"]==null)
            {
                return RedirectToAction("Index");
            }
            // getting previously stored data in QuoteModel 
            var quoteModel = JsonConvert.DeserializeObject<GetQuoteModel>(Session["QuoteModel"].ToString());
            quoteModel.Compensations=quoteModel.Compensations.Where(a => a.CompensationId==QM.SelectedCompensation).ToList();
            Session["QuoteModel"]= JsonConvert.SerializeObject(quoteModel);
            return RedirectToAction("BusinessLocation");
        }

        [HttpGet]
        public ActionResult BusinessLocation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BusinessLocation(BusinessLocationModel businessLocation)
        {
            Session["BusinessLocationModel"]= JsonConvert.SerializeObject(businessLocation);
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
            workerCompCoverageModel.EmployersLiabilityLimits=limitList;
            workerCompCoverageModel.CoveragePolicySelected=string.Empty;
            workerCompCoverageModel.EmployersLiabilityLimitSelected=string.Empty;
            Session["WorkerCompCoverageModel"]= JsonConvert.SerializeObject(workerCompCoverageModel);
            return View(workerCompCoverageModel);
        }

        [HttpPost]
        public ActionResult WorkerComp(WorkerCompCoverageModel worker)
        {
            if (Session["WorkerCompCoverageModel"]==null)
            {
                return RedirectToAction("Index");
            }
            var quoteModel = JsonConvert.DeserializeObject<WorkerCompCoverageModel>(Session["WorkerCompCoverageModel"].ToString());
            quoteModel.EmployersLiabilityLimits=quoteModel.EmployersLiabilityLimits.Where(a => a.LimitId==worker.EmployersLiabilityLimitSelected).ToList();
            quoteModel.EmployersLiabilityLimitSelected=worker.EmployersLiabilityLimitSelected;
            quoteModel.CoveragePolicySelected=worker.CoveragePolicySelected;
            Session["WorkerCompCoverageModel"]=JsonConvert.SerializeObject(quoteModel);
            return RedirectToAction("OwnersDetail");
        }
        [HttpGet]
        public ActionResult OwnersDetail()
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
            var OwnersDetail = new OwnerDetailModel();
            OwnersDetail.LocationLists=locationLists;
            ViewBag.LocationList=locationLists;
            Session["OwnerDetailModel"]= JsonConvert.SerializeObject(OwnersDetail);
            return View(OwnersDetail);
        }

        [HttpPost]
        public ActionResult OwnersDetail(FormCollection form)
        {
            if (Session["OwnerDetailModel"]==null)
            {
                return RedirectToAction("Index");
            }
            List<OwnerDetail> ownerDetails = new List<OwnerDetail>();
            OwnerDetailModel ownerDetailModel = new OwnerDetailModel();
            var quoteModel = JsonConvert.DeserializeObject<OwnerDetailModel>(Session["OwnerDetailModel"].ToString());
            int totalOwner = int.Parse(form["hdnRows"].ToString());
            for (int i = 1; i <= totalOwner; i++)
            {
                OwnerDetail owner = new OwnerDetail();
                owner.FirstName = form["FirstName"+i+""].ToString();
                owner.LastName  = form["LastName"+i+""].ToString();
                owner.Phone  = form["Phone"+i+""].ToString();
                owner.Email  = form["Email"+i+""].ToString();
                owner.TypeOfWork  = form["TypeOfWork"+i+""].ToString();
                owner.Location  = form["ddlLocation"+i+""].ToString();
                owner.Title  = form["ddlTitle"+i+""].ToString();
                owner.OwnerPayroll  = form["OwnerPayroll"+i+""].ToString();
                owner.DateOfBirth  = form["DateOfBirth"+i+""].ToString();
                owner.LocationId  = int.Parse(form["ddlLocation"+i+""].ToString());
                owner.TitleId  = int.Parse(form["ddlTitle"+i+""].ToString());
                ownerDetails.Add(owner);
            }
            ownerDetailModel.PartnershipPercent = form["PartnershipPercent"].ToString();
            ownerDetailModel.OwnerDetails=ownerDetails;
            quoteModel.OwnerDetails=ownerDetailModel.OwnerDetails;
            quoteModel.PartnershipPercent=ownerDetailModel.PartnershipPercent;
            Session["OwnerDetailModel"]= JsonConvert.SerializeObject(quoteModel);
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
            employee.LocationLists=locationLists;
            ViewBag.LocationList=locationLists;
            List<JobType> jobTypes = new List<JobType> {
            new JobType{ DataId="J001",DataTitle="Clerical Office Employees (NOC)"},
            new JobType{ DataId="J002",DataTitle="Outside Sales"},
            new JobType{ DataId="J003",DataTitle="Other"},
            };
            employee.JobType=jobTypes;
            Session["EmployeeModel"]= JsonConvert.SerializeObject(employee);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Employees(EmployeeModel emp)
        {
            if (Session["EmployeeModel"]==null)
            {
                return RedirectToAction("Index");
            }
            var employee = JsonConvert.DeserializeObject<EmployeeModel>(Session["EmployeeModel"].ToString());
            employee.LocationLists=employee.LocationLists.Where(a => a.LocationId==emp.Location).ToList();
            employee.Duties=emp.Duties;
            employee.FullTimeEmployee=emp.FullTimeEmployee;
            employee.PartTimeEmployee=emp.PartTimeEmployee;
            employee.EmployeePayroll=emp.EmployeePayroll;
            employee.JobType=emp.JobType.Where(a => a.ChkAnswer==true).ToList();
            employee.TypeofWork=emp.TypeofWork;
            employee.Location=emp.Location;
            Session["EmployeeModel"]= JsonConvert.SerializeObject(employee);
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
            Session["AdditionalWorkersModel"]= JsonConvert.SerializeObject(additionalWorkers);
            return RedirectToAction("Operations");
        }
        [HttpGet]
        public ActionResult Operations()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Operations(OperationsModel model)
        {

            Session["OperationsModel"]= JsonConvert.SerializeObject(model);
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
            Session["InsuranceHistoryModel"]= JsonConvert.SerializeObject(model);
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
            Session["CheckoutReviewModel"]= JsonConvert.SerializeObject(model);
            return View();
        }

    }

}
