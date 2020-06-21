using eShopSolution.Data.Enums;
using System;

namespace eShopSolution.Data.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public int ExternalTransactionId { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public string Result { get; set; }
        public string Message { get; set; }
        public string Provider { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
    }
}
