using System;
using System.Collections.Generic;

namespace HomeFinance.Application.StorePays.Queries
{
    public class StorePayListViewModel
    {
        public int RowCount { get; set; }
        public List<ViewStorePayModel> ListData { get; set; }
    }

    public class ViewStorePayModel
    {
        public int Id { get; set; }
        public string CardName { get; set; }
        public DateTime PayDate { get; set; }
        public string StoreName { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public bool Active { get; set; }
    }
}
