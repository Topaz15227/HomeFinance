using System;
using System.Collections.Generic;

namespace HomeFinance.Application.StorePays.Queries
{
    public class ArchiveListViewModel
    {
        public int RowCount { get; set; }
        public List<ArchiveViewModel> ArchiveListData { get; set; }
    }

    public class ArchiveViewModel
    {
        public int Id { get; set; }
        public string CardName { get; set; }
        public DateTime PayDate { get; set; }
        public string StoreName { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public DateTime ClosingDate { get; set; }
        public int ClosingId { get; set; }
    }
}
