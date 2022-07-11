using System;
using System.Collections.Generic;

namespace PogoInsurance.Models
{
    public class QuoteReponseModel
    {
        public int Reference { get; set; }
        public DateTime Created_at { get; set; }
        public string Expiry_date { get; set; }
        public Decision Decision { get; set; }
        public List<Cover> Covers { get; set; }
        public List<object> Decline_reasons { get; set; }
    }

    public class Decision
    {
        public string Status { get; set; }
        public Premiums Premiums { get; set; }
    }

    public class Premiums
    {
        public Gross Gross { get; set; }
        public Net Net { get; set; }
        public Commission Commission { get; set; }
        public Wc_Premium Wc_premium { get; set; }
        public Accident_Premium Accident_premium { get; set; }
        public Total_Tax Total_tax { get; set; }
        public Total_Fees Total_fees { get; set; }
        public List<object> Taxes { get; set; }
        public List<Fee> Fees { get; set; }
    }

    public class Gross
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }

    public class Net
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }

    public class Commission
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }

    public class Wc_Premium
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }

    public class Accident_Premium
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }

    public class Total_Tax
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }

    public class Total_Fees
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }

    public class Fee
    {
        public string Name { get; set; }
        public Value Value { get; set; }
    }

    public class Value
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }

    public class Cover
    {
        public string Name { get; set; }
        public List<Limit> Limits { get; set; }
        public Premiums1 Premiums { get; set; }
        public List<object> Decline_reasons { get; set; }
        public List<object> Excesses { get; set; }
    }

    public class Premiums1
    {
        public Gross1 Gross { get; set; }
        public Net1 Net { get; set; }
        public Commission1 Commission { get; set; }
        public Wc_Premium1 Wc_premium { get; set; }
        public Accident_Premium1 Accident_premium { get; set; }
        public Total_Tax1 Total_tax { get; set; }
        public List<object> Taxes { get; set; }
    }

    public class Gross1
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }

    public class Net1
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }

    public class Commission1
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }

    public class Wc_Premium1
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }

    public class Accident_Premium1
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }

    public class Total_Tax1
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }

    public class Limit
    {
        public string Name { get; set; }
        public Value1 Value { get; set; }
    }

    public class Value1
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }


}
