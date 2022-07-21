using System;

namespace WebApplication1.Models
{
    public class Customer
    {
        public Int64 CustomerID { get; set; }

        public decimal Score { get; set; }

    }
    public class CustomerExt: Customer
    {
        public Int64 Rank { get; set; }


    }
}
