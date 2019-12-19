using System;
using System.Collections.Generic;
using System.Text;

namespace HomeFinance.Domain.Entities
{
    public class Closing
    {
        public Closing()
        {
            StorePays = new HashSet<StorePay>();
        }

        public int Id { get; set; }
        public DateTime ClosingDate { get; set; }
        public int CardId { get; set; }
        public string ClosingName { get; set; }
        public decimal ClosingAmount { get; set; }

        public ICollection<StorePay> StorePays { get; set; }

        public Card Card { get; set; }
    }
}
