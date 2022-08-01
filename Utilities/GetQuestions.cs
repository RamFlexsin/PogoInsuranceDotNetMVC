using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PogoApp_MVC.Utilities
{
    public class GetQuestions
    {
        public bool Status { get; set; }
        public List<string> Message { get; set; }
        public List<Datum_Ques> Data { get; set; }
    }

    public class Datum_Ques
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public bool ForceHardDecline { get; set; }
    }
    public class RequestQuestions
    {
        public string ProductCode { get; set; }
        public string StateCode { get; set; }
    }
}