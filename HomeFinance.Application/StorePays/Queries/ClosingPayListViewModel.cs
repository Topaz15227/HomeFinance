using System;
using System.Collections.Generic;

namespace HomeFinance.Application.StorePays.Queries
{
    public class ClosingPayListViewModel
    {
        public int RowCount { get; set; }
        public List<ViewClosingPayModel> ClosingPayListData { get; set; }
    }

    public class ViewClosingPayModel
    {
        public int Id { get; set; }
        public DateTime PayDate { get; set; }
        public string StoreName { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
    }
}
