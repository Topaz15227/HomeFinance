using System;

namespace HomeFinance.Domain.Entities
{
    public class ViewStorePays
    {
        public int Id { get; set; }
        public string CardName { get; set; }
        public DateTime PayDate { get; set; }
        public string StoreName { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public DateTime? ClosingDate { get; set; }
        public bool Active { get; set; }
        public int CardId { get; set; }
        public int StoreId { get; set; }
        public int? ClosingId { get; set; }
    }
}
