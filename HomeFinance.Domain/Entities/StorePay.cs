using System;
using System.Collections.Generic;
using System.Text;

namespace HomeFinance.Domain.Entities
{
    public class StorePay
    {
        public int Id { get; set; }
        public DateTime PayDate { get; set; }
        public int CardId { get; set; }
        public int StoreId { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public int? ClosingId { get; set; }
        public bool? Active { get; set; }

        public Card Card { get; set; }
        public Store Store { get; set; }
        public Closing Closing { get; set; }
    }
}
