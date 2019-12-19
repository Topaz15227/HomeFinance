using MediatR;
using System;

namespace HomeFinance.Application.StorePays.Commands
{
    public class UpdateStorePayCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DateTime PayDate { get; set; }
        public int CardId { get; set; }
        public int StoreId { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public int? ClosingId { get; set; }
        public bool? Active { get; set; }
    }
}