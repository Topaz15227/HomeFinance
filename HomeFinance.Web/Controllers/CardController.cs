using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeFinance.Application.Cards.Queries;
using HomeFinance.Application.Cards.Commands;

namespace HomeFinance.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CardController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetCards()
        {
            var data = await Mediator.Send(new GetCardsQuery());

            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCardList()
        {
            var data = await Mediator.Send(new GetCardListQuery());

            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCardExtendedList()
        {
            var data = await Mediator.Send(new GetCardExtendedListQuery());

            return Ok(data);
        }

        [HttpGet("/api/[controller]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await Mediator.Send(new GetCardByIdQuery { Id = id });

            return Ok(data);
        }

        [HttpPut("/api/[controller]/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]UpdateCardCommand data)
        {
            var result = await Mediator.Send(data);

            return Ok(result);
        }

        [HttpPost("/api/[controller]")]
        public async Task<IActionResult> Post([FromBody]AddCardCommand data)
        {
            var result = await Mediator.Send(data);

            return Ok(result);
        }


    }
}