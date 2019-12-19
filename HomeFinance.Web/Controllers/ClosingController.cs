using System.Threading.Tasks;
using HomeFinance.Application.Closings.Commands;
using Microsoft.AspNetCore.Mvc;
using HomeFinance.Application.Closings.Queries;

namespace HomeFinance.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ClosingController : BaseController
    {

        [HttpGet("/api/closing/getclosingview/{id}")]
        public async Task<IActionResult> GetClosingView(int id)
        {
            var data = await Mediator.Send(new GetClosingViewByIdQuery { Id = id });

            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetClosingList(int cardId = 0, string sortBy = "Id",
            string sortOrder = "asc", int pageNumber = 1, int pageSize = 10)
        {
            var data = await Mediator.Send(new GetClosingsQuery
            {
                CardId = cardId,
                SortOrder = sortOrder,
                SortBy = sortBy,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return Ok(data);
        }

        [HttpPost("/api/[controller]")]
        public async Task<IActionResult> Post([FromBody]AddClosingCommand data)
        {
            var result = await Mediator.Send(data);

            return Ok(result);
        }

        [HttpGet("/api/closing/getnextclosingnumber/{id}")]
        public async Task<IActionResult> GetNextClosingNumber(int id)
        {
            var data = await Mediator.Send(new GetNextClosingNumberQuery { CardId = id });

            return Ok(data);
        }

    }
}