using System;
using System.Collections.Generic;

namespace HomeFinance.Application.Closings.Queries
{
    public class ClosingListViewModel
    {
        public int RowCount { get; set; }
        public List<ClosingViewModel> ClosingListData { get; set; }
    }

    public class ClosingViewModel
    {
        public int Id { get; set; }
        public string CardName { get; set; }
        public DateTime ClosingDate { get; set; }
        public decimal ClosingAmount { get; set; }
        public string ClosingName { get; set; }
    }
}
