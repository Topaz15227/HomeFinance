using MediatR;
using System;
//using System.Collections.Generic;
//using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.Closings.Commands
{
    public class AddClosingCommand : IRequest<int>
    {
        public DateTime ClosingDate { get; set; }
        public int CardId { get; set; }
        public string ClosingName { get; set; }
        public decimal ClosingAmount { get; set; }
        //public List<Closing> Closings { get; set; }
    }
}
