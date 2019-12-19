using System;
using System.Collections.Generic;
using System.Text;

namespace HomeFinance.Domain.Entities
{
    public class Store
    {
        public Store()
        {
            StorePays = new HashSet<StorePay>();
        }

        public int Id { get; set; }
        public string StoreName { get; set; }
        public bool? Active { get; set; }

       public ICollection<StorePay> StorePays { get; private set; }
    }
}
