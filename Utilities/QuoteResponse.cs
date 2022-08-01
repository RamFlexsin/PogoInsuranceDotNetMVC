using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PogoApp_MVC.Utilities
{
    public class QuoteResponse
    {
        public int reference { get; set; }
        public DateTime created_at { get; set; }
        public string expiry_date { get; set; }
        public Decision decision { get; set; }
        public List<Cover> covers { get; set; }
        public List<string> decline_reasons { get; set; }
    }

    public class Decision
    {
        public string status { get; set; }
        public Premiums premiums { get; set; }
    }

    public class Premiums
    {
        public Gross gross { get; set; }
        public Net net { get; set; }
        public Commission commission { get; set; }
        public Wc_Premium wc_premium { get; set; }
        public Accident_Premium accident_premium { get; set; }
        public Total_Tax total_tax { get; set; }
        public Total_Fees total_fees { get; set; }
        public List<string> taxes { get; set; }
        public List<Fee> fees { get; set; }
    }

    public class Gross
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Net
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Commission
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Wc_Premium
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Accident_Premium
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Total_Tax
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Total_Fees
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Fee
    {
        public string name { get; set; }
        public Value value { get; set; }
    }

    public class Value
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Cover
    {
        public string name { get; set; }
        public List<Limit>limits { get; set; }
        public Premiums1 premiums { get; set; }
        public List<string> decline_reasons { get; set; }
        public List<string> excesses { get; set; }
    }

    public class Premiums1
    {
        public Gross1 gross { get; set; }
        public Net1 net { get; set; }
        public Commission1 commission { get; set; }
        public Wc_Premium1 wc_premium { get; set; }
        public Accident_Premium1 accident_premium { get; set; }
        public Total_Tax1 total_tax { get; set; }
        public List<string> taxes { get; set; }
        //public object[] taxes { get; set; }
    }

    public class Gross1
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Net1
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Commission1
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Wc_Premium1
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Accident_Premium1
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Total_Tax1
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Limit
    {
        public string name { get; set; }
        public Value1 value { get; set; }
    }

    public class Value1
    {
        public string amount { get; set; }
        public string currency { get; set; }
    }

}