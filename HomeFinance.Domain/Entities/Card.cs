using System;
using System.Collections.Generic;
using System.Text;

namespace HomeFinance.Domain.Entities
{
    public class Card
    {
        public Card()
        {
            StorePays = new HashSet<StorePay>();
            Closings = new HashSet<Closing>();
        }

        public int Id { get; set; }
        public string CardName { get; set; }
        public string CardDescription { get; set; }
        public string CardNumber { get; set; }
        public string ClosingName { get; set; }
        public bool? Active { get; set; }

        public ICollection<StorePay> StorePays { get; private set; }
        public ICollection<Closing> Closings { get; private set; }
    }
}
