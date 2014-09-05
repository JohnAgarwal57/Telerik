namespace Atm.Models
{
    using System;

    public class TransactionsHistory
    {
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Ammount { get; set; }
    }
}
