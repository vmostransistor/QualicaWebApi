using System;

namespace Qualica.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public string Reference { get; set; }
        public DateTime Transaction_date { get; set; }
        public double Amount { get; set; }
        public Guid From_Account { get; set; }
        public Guid To_Account { get; set; }
    }
}
