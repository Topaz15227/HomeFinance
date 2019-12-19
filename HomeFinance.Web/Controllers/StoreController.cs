using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HomeFinance.Application.Stores.Queries;
using HomeFinance.Application.Stores.Commands;

namespace HomeFinance.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class StoreController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetStoreList()
        {
            var data = await Mediator.Send(new GetStoreListQuery());

            return Ok(data);
        }

        [HttpGet("/api/[controller]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await Mediator.Send(new GetStoreByIdQuery { Id = id });

            return Ok(data);
        }

        //[HttpPatch("/api/[controller]/{id}")]
        //public async Task<IActionResult> Patch(int id, [FromBody]UpdateStoreCommand data)
        //{
        //    var result = await Mediator.Send(data);

        //    return Ok(result);
        //}

        [HttpPut("/api/[controller]/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]UpdateStoreCommand data)
        {
            var result = await Mediator.Send(data);

            return Ok(result);
        }

        [HttpPost("/api/[controller]")]
        public async Task<IActionResult> Post([FromBody]AddStoreCommand data)
        {
            var result = await Mediator.Send(data);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetStores(string sortBy = "Id", string sortOrder = "asc",
            int pageNumber = 1, int pageSize = 10)
        {
            var data = await Mediator.Send(new GetStoresQuery
            {
                SortOrder = sortOrder,
                SortBy = sortBy,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStores()
        {
            var data = await Mediator.Send(new GetAllStoresQuery());

            return Ok(data);
        }
    }
}
