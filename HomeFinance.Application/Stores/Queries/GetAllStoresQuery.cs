using MediatR;
using System.Collections.Generic;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.Stores.Queries
{
    public class GetAllStoresQuery : IRequest<List<Store>>
    {
    }
}
