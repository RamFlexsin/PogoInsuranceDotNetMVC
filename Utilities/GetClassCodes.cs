using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PogoApp_MVC.Utilities
{
    public class GetClassCodes
    {
        public bool Status { get; set; }
        public List<string> Message { get; set; }
        public List<Datum> Data { get; set; }
    }

    public class Datum
    {
        public string ClassCode { get; set; }
        public string Description { get; set; }
    }


    public class RequestClassCodes
    {
        public string ProductCode { get; set; }
        public string StateCode { get; set; }
        public string BusinessEntity { get; set; }
    }


}