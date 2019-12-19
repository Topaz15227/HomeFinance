using System;

namespace HomeFinance.Domain.Entities
{
    public class ViewClosings
    {
        public int Id { get; set; }
        public string CardName { get; set; }
        public DateTime ClosingDate { get; set; }
        public string ClosingName { get; set; }
        public decimal ClosingAmount { get; set; }
        public int CardId { get; set; }
    }
}