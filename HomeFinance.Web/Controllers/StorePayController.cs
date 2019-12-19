using System.Threading.Tasks;
using HomeFinance.Application.StorePays.Commands;
using Microsoft.AspNetCore.Mvc;
using HomeFinance.Application.StorePays.Queries;

namespace HomeFinance.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class StorePayController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetSummary()
        {
            var data = await Mediator.Send(new GetSummaryQuery());

            return Ok(data);
        }

        [HttpGet("/api/storepay/getstorepays/{id}")]
        public async Task<IActionResult> GetStorePays(int id)
        {
            var data = await Mediator.Send(new GetStorePaysQuery { CardId = id });

            return Ok(data);
        }

        [HttpGet("/api/storepay/getpaysbystore/{id}")]
        public async Task<IActionResult> GetPaysByStore(int id)
        {
            var data = await Mediator.Send(new GetStorePaysByStoreQuery { StoreId = id });

            return Ok(data);
        }

        [HttpGet("/api/[controller]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await Mediator.Send(new GetStorePayByIdQuery { Id = id });

            return Ok(data);
        }


        [HttpPut("/api/[controller]/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]UpdateStorePayCommand data)
        {
            var result = await Mediator.Send(data);

            return Ok(result);
        }

        [HttpPost("/api/[controller]")]
        public async Task<IActionResult> Post([FromBody]AddStorePayCommand data)
        {
            var result = await Mediator.Send(data);

            return Ok(result);
        }

        //[HttpGet("/api/storepay/getstorepaysbyclosing/{id}")]
        //public async Task<IActionResult> GetStorePaysByClosing(int id)
        //{
        //    var data = await Mediator.Send(new GetStorePaysByClosingQuery { ClosingId = id });

        //    return Ok(data);
        //}

        [HttpGet]
        public async Task<IActionResult> GetStorePaysByClosing(int closingId, string sortBy = "Id",  string sortOrder = "asc", 
            int pageNumber = 1, int pageSize = 10)
        {
            var data = await Mediator.Send(new GetStorePaysByClosingQuery
            { ClosingId = closingId,
                SortOrder = sortOrder,
                SortBy = sortBy,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return Ok(data);
        }

        [HttpPost] //???
        public async Task<IActionResult> GetStorePayList(GetStorePayListQuery query)
        {
            var data = await Mediator.Send(query);

            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetStorePayList(int cardId =0, string filter ="", string sortBy="Id",
            string sortOrder = "asc", int pageNumber = 1, int pageSize=10)
        {
            var data = await Mediator.Send(new GetStorePayListQuery
            {
                CardId = cardId,
                Filter = filter,
                SortOrder = sortOrder,
                SortBy = sortBy,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return Ok(data.ListData);
        }

        [HttpGet("/api/storepay/getcardpay/{id}")]
        public async Task<IActionResult> GetCardPay(int id)
        {
            var value = await Mediator.Send(new GetCardPayQuery { CardId = id });

            return Ok(value);
        }

        [HttpGet]
        public async Task<IActionResult> GetArchiveList(int cardId = 0, string filter = "", string sortBy = "Id",
         string sortOrder = "asc", int pageNumber = 1, int pageSize = 10)
        {
            var data = await Mediator.Send(new GetArchiveListQuery
            {
                CardId = cardId,
                Filter = filter,
                SortOrder = sortOrder,
                SortBy = sortBy,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return Ok(data);
        }


    }
}