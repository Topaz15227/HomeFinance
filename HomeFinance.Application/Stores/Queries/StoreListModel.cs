using HomeFinance.Domain.Entities;
using System.Collections.Generic;

namespace HomeFinance.Application.Stores.Queries
{
    public class StoreListModel
    {
        public int RowCount { get; set; }
        public List<Store> StoreListData { get; set; }
    }
}
