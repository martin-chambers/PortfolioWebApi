using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioWebAPI.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public enum TransactionType { Buy, Sell, Dividend_Paid_To_Cash, Dividend_Scheduled}
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public int Shares { get; set; }
        public decimal Price { get; set; }
        public decimal CashValue { get; set; }
        public decimal Commission { get; set; }

    }
}